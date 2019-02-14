using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_s_Game_Of_Life
{
    class Game
    {
        public enum GameStates {Alive, Stable, Loop, Dead};
        private const int prevGenerationsCount = 10;

        private bool[,] generation;
        private bool[][,] prevGenerations;
        private int rowsCount;
        private int colomnsCount;
        private int alives;
        private bool isDead;
        private bool[] isLoop;
        private bool isStable;

        public Game(int rowsCount, int colomnsCount)
        {
            this.rowsCount = rowsCount;
            this.colomnsCount = colomnsCount;
            generation = new bool[rowsCount, colomnsCount];
            prevGenerations = new bool[prevGenerationsCount][,];
            PrevGenerationsCleare();
            isDead = false;
            isLoop = new bool[prevGenerationsCount];
            isStable = false;
            alives = 0;
        }

        public GameStates State
        {
            get {
                if (isDead)
                    return GameStates.Dead;
                if (isStable)
                    return GameStates.Stable;
                foreach (bool val in isLoop)
                    if (val)
                        return GameStates.Loop;
                return GameStates.Alive;
            }
        }

        public int Alives { get => alives; }
        public int Length { get => GameMap.Length; }

        public int RowsCount { get => rowsCount; }
        public int ColomnsCount { get => colomnsCount; }

        public bool this[int row, int colomn]
        {
            get => generation[row, colomn];
            set {
                generation[row, colomn] = value;
                PrevGenerationsCleare();
            }
        }

        public bool this[System.Drawing.Point location]
        {
            get => generation[location.Y, location.X];
            set {
                generation[location.Y, location.X] = value;
                PrevGenerationsCleare();
            }
        }

        public bool[,] GameMap
        {
            get => generation;
            set {
                generation = value;
                rowsCount = generation.GetLength(0);
                colomnsCount = generation.GetLength(1);
                alives = 0;
                foreach (bool cell in generation)
                    if (cell)
                        alives++;
                PrevGenerationsCleare();
            }
        }

        private void PrevGenerationsCleare()
        {
            for (int i = 0; i < prevGenerations.Length; i++)
                prevGenerations[i] = new bool[rowsCount, colomnsCount];
        }

        public void Random()
        {
            generation = new bool[rowsCount, colomnsCount];
            Random random = new Random();
            for (int i = 0; i < rowsCount; i++)
                for (int j = 0; j < colomnsCount; j++) {
                    if (random.Next() % 2 == 0)
                        generation[i, j] = true;
                }
        }

        public void NextGeneration()
        {
            bool[,] nextGeneration = new bool[rowsCount, colomnsCount];
            isDead = true;
            for (int i = 0; i < prevGenerationsCount; i++)
                isLoop[i] = true;
            isStable = true;
            alives = 0;

            for (int i = 0; i < rowsCount; i++)
                for (int j = 0; j < colomnsCount; j++) {
                    nextGeneration[i, j] = IsAlive(i, j);

                    if (isStable && nextGeneration[i, j] != generation[i, j])
                        isStable = false;
                for(int k = 0; k< prevGenerationsCount; k++) {
                            if (nextGeneration[i, j] != prevGenerations[k][i, j])
                                isLoop[k] = false;
                        }
                    if (isDead && nextGeneration[i, j])
                        isDead = false;
                }
            for (int i = prevGenerations.Length - 2; i >= 0; i--)
                prevGenerations[i + 1] = prevGenerations[i];
            prevGenerations[0] = generation;
            generation = nextGeneration;
        }

        private bool IsAlive(int row, int colomn)
        {
            int neighborsCount = NeighborsCount(row, colomn);

            if (!generation[row, colomn] && neighborsCount == 3) {
                alives++;
                return true;
            }
            if (generation[row, colomn] && (neighborsCount == 2 || neighborsCount == 3)) {
                alives++;
                return true;
            }
            return false;
        }

        private int NeighborsCount(int row, int colomn)
        {
            int count = 0;

            // отнимаем 1 для избежания особого случая на границе -1|0
            row = (row - 1 < 0) ? rowsCount - 1 : row - 1;
            colomn = (colomn - 1 < 0) ? colomnsCount - 1 : colomn - 1;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)  {
                    if (i == 1 && j == 1)
                        continue;
                    if (generation[(row + i)%rowsCount, (colomn + j) % colomnsCount])
                        count++;
                }

            return count;
        }
    }
}

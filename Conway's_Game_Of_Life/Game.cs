using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_s_Game_Of_Life
{
    class Game
    {
        private bool[,] generation;
        private bool[,] prevGeneration;
        private int rowsCount;
        private int colomnsCount;
        private int alives;
        private bool isDead;
        private bool isLoop;
        private bool isStable;

        public Game(int rowsCount, int colomnsCount)
        {
            generation = new bool[rowsCount, colomnsCount];
            prevGeneration = new bool[rowsCount, colomnsCount];
            this.rowsCount = rowsCount;
            this.colomnsCount = colomnsCount;
            isDead = false;
            isLoop = false;
            isStable = false;
            alives = 0;
        }

        public bool IsDead { get => isDead; }
        public bool IsLoop { get => isLoop; }
        public bool IsStable { get => isStable; }
        public int Alives { get => alives; }
        public int Length { get => GameMap.Length; }

        public int RowsCount { get => rowsCount; }
        public int ColomnsCount { get => colomnsCount; }

        public bool this[int row, int colomn]
        {
            get => generation[row, colomn];
            set {
                generation[row, colomn] = value;
                prevGeneration = new bool[rowsCount, colomnsCount];
            }
        }

        public bool this[System.Drawing.Point location]
        {
            get => generation[location.X, location.Y];
            set {
                generation[location.X, location.Y] = value;
                prevGeneration = new bool[rowsCount, colomnsCount];
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
            }
        }
        public bool[,] OldMap
        {
            get => prevGeneration;
            
        }

        public void NextGeneration()
        {
            bool[,] nextGeneration = new bool[rowsCount, colomnsCount];
            isDead = true;
            isLoop = true;
            isStable = true;
            alives = 0;

            for (int i = 0; i < rowsCount; i++)
                for (int j = 0; j < colomnsCount; j++) {
                    nextGeneration[i, j] = IsAlive(i, j);

                    if (nextGeneration[i, j] != generation[i, j])
                        isStable = false;
                    if (nextGeneration[i, j] != prevGeneration[i, j])
                        isLoop = false;
                    if (nextGeneration[i, j])
                        isDead = false;
                }
            prevGeneration = generation;
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

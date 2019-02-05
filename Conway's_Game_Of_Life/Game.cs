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
        }

        public bool IsDead { get => isDead; }
        public bool IsLoop { get => isLoop; }
        public bool IsStable { get => isStable; }

        public bool[,] GameMap
        {
            get => generation;
            set {
                generation = value;
                rowsCount = generation.GetLength(0);
                colomnsCount = generation.GetLength(1);
                prevGeneration = new bool[rowsCount, colomnsCount];
            }
        }

        public void NextGeneration()
        {
            bool[,] nextGeneration = new bool[rowsCount, colomnsCount];
            isDead = true;
            isLoop = true;
            isStable = true;

            for (int i = 0; i < rowsCount; i++)
                for (int j = 0; j < colomnsCount; j++) {
                    int neighborsCount = NeighborsCount(i, j);
                    nextGeneration[i, j] = false;

                    if (!generation[i, j] && neighborsCount == 3) {
                        nextGeneration[i, j] = true;
                        isDead = false;
                    }
                    if (generation[i, j] && (neighborsCount == 2 || neighborsCount == 3)) {
                        nextGeneration[i, j] = true;
                        isDead = false;
                    }

                    if (nextGeneration[i, j] != generation[i, j])
                        isStable = false;
                    if (nextGeneration[i, j] != prevGeneration[i, j])
                        isLoop = false;
                }
            prevGeneration = generation;
            generation = nextGeneration;
        }

        private int NeighborsCount(int row, int colomn)
        {
            int count = 0;

            // отнимаем 1 для избежания особого случая на границе -1|0
            row = (row - 1 < 0) ? rowsCount - 1 : row - 1;
            colomn = (colomn - 1 < 0) ? colomnsCount - 1 : colomn - 1;

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)  {
                    if (i == 1 && j == 1)
                        continue;
                    if (generation[(row + i)%rowsCount, (colomn + j) % colomnsCount])
                        count++;
                }

            return count;
        }
    }
}

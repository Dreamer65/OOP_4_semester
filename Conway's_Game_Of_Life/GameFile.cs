﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Conway_s_Game_Of_Life
{
    static class GameFile
    {
        private static byte[] IntToByteArray(int value)
        {
            byte[] result = new byte[sizeof(int)];
            for (int i = sizeof(int) - 1; i > 0; i--)  {
                result[i] = (byte)(value & byte.MaxValue);
                value = value >> 8;
            }
            return result;
        }

        private static int[] ByteArrayToIntArray(byte[] array)
        {
            List<int> result = new List<int>();
            int element;
            int bufSize;
            int count = array.Length;
            int j = 0;
            while (count > 0) {
                element = 0;
                if (array.Length < sizeof(int))
                    bufSize = array.Length;
                else
                    bufSize = sizeof(int);
                for (int i = 0; i < bufSize; i++) {
                    element = element << 8;
                    element = element | array[sizeof(int)*j+i];
                }
                element = element << ((sizeof(int) - bufSize) * 8);
                result.Add(element);
                count -= bufSize;
                j++;
            }
            return result.ToArray();
        }

        public static void SaveGameMap(string filename, Game game)
        {
            const int bufferSize = sizeof(int);
            FileStream file = new FileStream(filename, FileMode.Create);
            file.Write(IntToByteArray(game.RowsCount), 0, bufferSize);
            file.Write(IntToByteArray(game.ColomnsCount), 0, bufferSize);

            int digitsCount = 0;
            int buf = 0;

            for (int i = 0; i < game.RowsCount; i++)
                for (int j = 0; j < game.ColomnsCount; j++) {
                    if (game[i, j])
                        buf += 1;
                    buf = buf << 1;
                    digitsCount++;
                    if (digitsCount >= bufferSize * 8) {
                        file.Write(IntToByteArray(buf), 0, bufferSize);
                        digitsCount = 0;
                        buf = 0;
                    }
                }
            if (digitsCount != 0) {
                buf = buf << bufferSize * 8 - digitsCount - 1;
                file.Write(IntToByteArray(buf), 0, bufferSize);
            }
            file.Close();
        }

        public static Game LoadGameMap(string filename)
        {
            const int bufferSize = sizeof(int);
            FileStream file = new FileStream(filename, FileMode.Open);
            byte[] buf = new byte[2 * bufferSize];
            file.Read(buf, 0, 2 * bufferSize);
            int[] RowsAndColomns = ByteArrayToIntArray(buf);

            buf = new byte[(int)(file.Length - file.Position)];
            file.Read(buf, 0, (int)(file.Length - file.Position));
            file.Close();

            int[] intMap = ByteArrayToIntArray(buf);
            Game game = new Game(RowsAndColomns[0], RowsAndColomns[1]);

            game.GameMap = IntArrayToBoolMap(intMap, RowsAndColomns[0], RowsAndColomns[1]);

            return game;
        }

        private static bool[,] IntArrayToBoolMap(int[] intMap, int rows, int colomns)
        {
            bool[,] map = new bool[rows, colomns];
            int currentNumber = 0;
            int currentBit = int.MinValue;
            byte bitCount = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < colomns; j++) {
                    if(bitCount >= sizeof(int) * 8) {
                        bitCount = 0;
                        currentNumber++;
                        currentBit = int.MinValue;
                    }
                    if (currentNumber >= intMap.Length)
                        return map;
                    if ((intMap[currentNumber]&currentBit) != 0) 
                        map[i, j] = true;
                    currentBit = currentBit >> 1;
                    bitCount++;
                }
            return map;
        }
    }
}

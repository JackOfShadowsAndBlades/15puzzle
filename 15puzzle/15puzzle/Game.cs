using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15puzzle
{
    class Game
    {
        public int[,] Field;
        private int dimensions;
        private int tmpI = 0, tmpJ = 0, _tmpI = 0, _tmpJ = 0;
        private Dictionary<int, int> dictionary = new Dictionary<int, int>();

        public Game(params int[] SomeArray)
        {
            int count = 0;

            if (!IsCorrectData(SomeArray))
            {
                throw new ArgumentException("Значения введенных данных некорректны");
            }

            dimensions = (int)Math.Sqrt(SomeArray.Length);
            Field = new int[dimensions, dimensions];

            for (int i = 0; i < dimensions; i++)
            {
                for (int j = 0; j < dimensions; j++)
                {
                    if (SomeArray[count] == 0)
                    {
                        tmpI = i;
                        tmpJ = j;
                        Field[i, j] = SomeArray[count];
                        dictionary.Add(0, count);
                        count++;
                    }
                    else
                    {
                        Field[i, j] = SomeArray[count];
                        dictionary.Add(Field[i, j], count);
                        count++;
                    }
                }
            }
        }


        public int this[int x, int y]
        {
            get
            {
                return Field[x, y];
            }
            set
            {
                Field[x, y] = value;
            }
        }

        public int GetLocation(int value)
        {
            if (value >= 0 && value < Math.Pow(dimensions, 2))  
            {
                return dictionary[value];
            }
            else throw new ArgumentException("Число не найдено");
        }

        public void Shift(int value)
        {
            for (int i = 0; i < dimensions; i++)
            {
                for (int j = 0; j < dimensions; j++)
                {
                    if (Field[i, j] == value)
                    {
                        _tmpI = i;
                        _tmpJ = j;
                    }
                }
            }
            if (Math.Abs(_tmpI - tmpI) + Math.Abs(_tmpJ - tmpJ) == 1)
            {
                Field[tmpI, tmpJ] = Field[_tmpI, _tmpJ];
                dictionary.Remove(0);
                dictionary.Remove(value);
                dictionary.Add(value, tmpI * dimensions + tmpJ);
                dictionary.Add(0, _tmpI * dimensions + _tmpJ);
                tmpI = _tmpI;
                tmpJ = _tmpJ;
                Field[tmpI, tmpJ] = 0;
            }
            else
            {
                throw new ArgumentException("Число нельзя передвинуть");
            }
        }

        private bool IsCorrectData(int[] array)
        {
            bool zeroFlag = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (((array[i] == array[j]) || (array[j] > array.Length - 1)) || (array[i] < 0))
                    {
                        return false;
                    }
                    if (array[i] == 0 || array[j] == 0)
                    {
                        zeroFlag = true;
                    }
                }
            }
            return zeroFlag;
        }

        public void DisplayCurrentState(int[,] array)
        {
            for (int i = 0; i < Math.Sqrt(array.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(array.Length); j++)
                {
                    Console.Write("{0}\t", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

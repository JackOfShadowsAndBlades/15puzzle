using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _15puzzle
{
    class Game
    {
        public int[,] Field;
        private int dimensions;
        private int tmpI = 0, tmpJ = 0, _tmpI = 0, _tmpJ = 0;
        private Dictionary<int, Tuple<int, int>> dictionary = new Dictionary<int, Tuple<int, int>>();

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
                        var coord = Tuple.Create(i, j);
                        dictionary.Add(Field[i, j], coord);
                        count++;
                    }
                    else
                    {
                        Field[i, j] = SomeArray[count];
                        var coord = Tuple.Create(i, j);
                        dictionary.Add(Field[i, j], coord);
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

        public Tuple<int, int> GetLocation(int value)
        {
            if (value >= 0 && value < Math.Pow(dimensions, 2))  
            {
                var coord = Tuple.Create(dictionary[value].Item1, dictionary[value].Item2);
                return coord;
            }
            else throw new ArgumentException("Число не найдено");
        }

        public void Shift(int value)
        {
            _tmpI = dictionary[value].Item1;
            _tmpJ = dictionary[value].Item2;
            if (Math.Abs(_tmpI - tmpI) + Math.Abs(_tmpJ - tmpJ) == 1)
            {
                Field[tmpI, tmpJ] = Field[_tmpI, _tmpJ];
                dictionary.Remove(0);
                dictionary.Remove(value);
                var coordZero = Tuple.Create(tmpI, tmpJ);
                var coordValue = Tuple.Create(_tmpI, _tmpJ);
                dictionary.Add(value, coordZero);
                dictionary.Add(0, coordValue);
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
           for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0 || !array.Contains(i))
                {
                    return false;
                }
            }
            return true;
        }

        public static Game FromCSV(string file)
        {
            string[] csv = File.ReadAllLines(file);
            List<int> list = new List<int>();
            for (int i = 0; i < csv.Count(); i++)
            {
                for (int j = 0; j < csv[i].Split(';').Count(); j++)
                {
                    list.Add(Convert.ToInt32(csv[i].Split(';')[j]));
                }
            }
            return new Game(list.ToArray<int>());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1, 2, 3, 4, 5, 6, 8, 7, 0);
            //Game anothergame = Game.FromCSV("text.csv");
            Console.WriteLine(game.GetLocation(0));
            Console.WriteLine(game.GetLocation(5));
        }
    }
}

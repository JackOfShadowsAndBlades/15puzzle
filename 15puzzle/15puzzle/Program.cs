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
            Game game = new Game(1, 2, 3, 4, 5, 6, 7, 8, 0);
            game.DisplayCurrentState(game.Field);
            game.Shift(8);
            game.DisplayCurrentState(game.Field);
            game.Shift(5);
            game.DisplayCurrentState(game.Field);
            Console.WriteLine(game.GetLocation(5));
            Console.WriteLine(game.GetLocation(0));
        }
    }
}

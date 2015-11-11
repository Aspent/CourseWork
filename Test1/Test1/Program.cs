using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Test1
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Are you superhero?! (Write 'yes')");
            var str = Console.ReadLine();
            string mode;
            if((str == "'yes'") || str == "yes")
            {
                mode = "SuperHero";
            }
            else
            {
                mode = "SuperCancer";
            }

            var resolution = SystemInformation.PrimaryMonitorSize;
            using (var game = new Game(resolution.Width, resolution.Height, mode))
            {
                game.Run();
            }


            Console.WriteLine();
            Console.WriteLine("Now enter something to exit");
                           
            Console.ReadLine();                   
        }
    }
}

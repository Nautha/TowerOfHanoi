using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarolCS;

namespace KarolCS_Erste_Schritte
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hanoi hanoi = new Hanoi(5);

            //hanoi.run();
            moveTower('1', '2', '3', 3);
        }

        static void moveTower(char t1, char t2, char t3, int n) {
            if(n > 0) {
                moveTower(t1, t3, t2, n - 1);
                Console.WriteLine("{0} nach {1} verschieben", t1, t3);
                moveTower(t2, t1, t3, n - 1);
            }
        }


        
    }
}

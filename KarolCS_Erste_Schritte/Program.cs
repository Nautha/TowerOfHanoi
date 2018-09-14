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
            Console.WriteLine("Wie viele Schichten soll der Turm haben?");
            int input = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Das Spiel wird mit {0} Schichten gestratet. Bitte warten.", input);

            Hanoi hanoi = new Hanoi(input);

            
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

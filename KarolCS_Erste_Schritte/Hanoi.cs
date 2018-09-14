using KarolCS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolCS_Erste_Schritte
{
    class Hanoi
    {
        private Welt w;
        //private Roboter robot;
        private Builder bob;

        private int height;
        private int widthMax;

        private int[] startPositions;

        private List<int>[] towers;

        public Hanoi(int height) {
            this.height = height;

            widthMax = height * 2 - 1;

            startPositions = new int[] {0, widthMax + 1, (widthMax + 1) * 2 };

            w = new Welt(3 * widthMax + 4, widthMax + 2, height + 1);
            w.setDelay(-1000);

            bob = new Builder(w);

            towers = new List<int>[] { new List<int>(), new List<int>(), new List<int>() };

            for(int i = 0; i < height; i++) {
                towers[0].Add((height - i) * 2 - 1);
            }
        }

        public void run() {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            bob.buildTower(height);
            towerAlgorithm(0, 1, 2, height);
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine("Bob the Builder hat {0} gebraucht.", ts);
            bob.iWon((3 * widthMax + 4) / 2, (widthMax + 2) / 2);
        }

        private void towerAlgorithm(int t1, int t2, int t3, int n) {
            if(n > 0) {
                towerAlgorithm(t1, t3, t2, n - 1);
                editTowers(t1, t3);
                towerAlgorithm(t2, t1, t3, n - 1);
            }
        }

        private void editTowers(int from, int to) {
            //Console.WriteLine("Move {0} to {1}", from, to);

            int toAdd = towers[from][towers[from].Count - 1];

            bob.moveLayer(startPositions[from], startPositions[to], toAdd, widthMax);

            towers[to].Add(toAdd);

            towers[from].Remove(toAdd);
        }

        public void outputTowers() {
            foreach(int layer in towers[2]) {
                Console.WriteLine(layer);
            }
        }
    }
}

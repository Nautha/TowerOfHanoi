using KarolCS;
using System;
using System.Collections;
using System.Collections.Generic;
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

        private int startPointTower2;
        private int startPointTower3;

        private ArrayList tower1;
        private ArrayList tower2;
        private ArrayList tower3;

        public Hanoi(int height) {
            this.height = height;

            widthMax = height * 2 - 1;

            startPointTower2 = widthMax + 1;
            startPointTower3 = startPointTower2 * 2;

            w = new Welt(3 * widthMax + 4, widthMax + 2, height + 1);
            w.setDelay(-1000);
            //robot = new Roboter(w);
            bob = new Builder(w);

            tower1 = new ArrayList();
            tower2 = new ArrayList();
            tower3 = new ArrayList();

            for(int i = 0; i < height; i++) {
                tower1.Add((height - i) * 2 - 1);
            }
        }

        public void run() {
            bob.buildTower(height);
        }

        private void towerAlgorithm() {

        }
    }
}

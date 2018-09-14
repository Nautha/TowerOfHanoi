using KarolCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolCS_Erste_Schritte
{
    class Builder
    {
        private Roboter robo;

        public Builder(Welt w) {
            robo = new Roboter(w);
        }

        private void turn() {
            robo.LinksDrehen();
            robo.LinksDrehen();
        }

        private void gotoPos(int x, int y) {
            int toWalkX = x - robo.getXPos();
            int toWalkY = y - robo.getYPos();

            if(toWalkX < 0) {
                toWalkX *= -1;
                face('w');
                walk(toWalkX);
            } else {
                face('o');
                walk(toWalkX);
            }

            if(toWalkY < 0) {
                toWalkY *= -1;
                face('n');
                walk(toWalkY);
            } else {
                face('s');
                walk(toWalkY);
            }

            face('o');
        }

        private void face(char direction) {
            while(robo.getBlickrichtung() != direction) {
                robo.LinksDrehen();
            }
        }

        private void walk(int fields) {
            for(int i = 0; i < fields; i++) {
                robo.Schritt();
            }
        }

        private void buildLine(int length) {
            for(int i = 0; i < length; i++) {
                robo.Hinlegen();
                robo.Schritt();
            }
        }

        private void removeLine(int length) {
            for (int i = 0; i < length; i++) {
                robo.Aufheben();
                robo.Schritt();
            }
        }

        private void buildLayer(int width) {
            for(int i = 0; i < width; i++) {
                buildLine(width);
                robo.Schritt();

                if (i % 2 == 0) {
                    robo.RechtsDrehen();
                    robo.Schritt();
                    robo.RechtsDrehen();
                } else {
                    robo.LinksDrehen();
                    robo.Schritt();
                    robo.LinksDrehen();
                }
            }
        }

        public void buildTower(int height) {
            int width = height * 2 - 1;

            face('s');
            robo.Schritt();
            face('o');
            
            for(int i = 0; i < height; i++) {
                buildLayer(width);

                robo.Schritt();
                robo.RechtsDrehen();

                walk(2);

                robo.LinksDrehen();

                width -= 2;
            }

            gotoPos(0, 0);
        }


    }
}

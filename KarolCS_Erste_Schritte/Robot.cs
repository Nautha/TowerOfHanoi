using KarolCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarolCS_Erste_Schritte
{
    class Robot
    {
        private Welt w;
        private Roboter robot;

        public Robot()
        {
            w = new Welt(40, 20, 10);
            w.setDelay(-50000);
            robot = new Roboter(w);
        }

        public void towerOfHanoi(int height)
        {

            buildTower(height);

            goToPos(0,0);

            debuildTower(height);
        }

        public void debuildTower(int height)
        {
            for(int i = 0; i < height; i++)
            {
                while(robot.getBlickrichtung() != 's')
                {
                    robot.RechtsDrehen();
                }

                move(height - i);
                robot.LinksDrehen();
                move(height - (i + 1));

                debuildLayer(i);

                //rebuildLayer(height, i);

                goToPos(0, 0);
            }

            
        }

        public void rebuildLayer(int height, int layer)
        {
            int posTow2 = (height * 2 - 1) + 1;
            int posTow3 = posTow2 * 2;

            int breite = (layer + 1) * 2 - 1;



            if(height % 2 == 0)
            {
                if(layer % 2 == 0)
                {
                    goToPos(posTow3, 0);
                    buildLayer(breite);
                } else
                {
                    goToPos(posTow2, 0);
                    buildLayer(breite);
                }
            } else
            {
                if (layer % 2 == 0)
                {
                    goToPos(posTow2, 0);
                    buildLayer(breite);
                }
                else
                {
                    goToPos(posTow3, 0);
                    buildLayer(breite);
                }
            }
        }

        public void debuildLayer(int layer)
        {
            Console.WriteLine(layer);

            int breite = (layer + 1) * 2 - 1;

            for(int i = 0; i < breite; i++)
            {
                debuildLine(breite);
                robot.Schritt();
                if (i % 2 == 0)
                {
                    robot.RechtsDrehen();
                    robot.Schritt();
                    robot.RechtsDrehen();
                }
                else
                {
                    robot.LinksDrehen();
                    robot.Schritt();
                    robot.LinksDrehen();
                }
            }
        }


        public void move(int num)
        {
            Boolean isNegative = false;

            Console.WriteLine(num);
            if(num < 0)
            {
                isNegative = true;
                num *= -1;
                turn();
            }

            for (int i = 0; i < num; i++)
            {
                robot.Schritt();
            }

            if(isNegative)
            {
                turn();
            }
        }

        public void place(int num)
        {
            for (int i = 0; i < num; i++)
            {
                robot.Hinlegen();
            }
        }

        public void buildLine(int num)
        {
            for (int i = 0; i < num; i++)
            {
                robot.Hinlegen();
                robot.Schritt();
            }
        }

        public void debuildLine(int num)
        {
            for (int i = 0; i < num; i++)
            {
                robot.Aufheben();
                robot.Schritt();
            }
        }

        public void turn()
        {
            robot.LinksDrehen();
            robot.LinksDrehen();
        }

        public void goToPos(int x, int y)
        {
            while (robot.getXPos() != x || robot.getYPos() != y || robot.getBlickrichtung() != 'o')
            {
                Console.WriteLine(robot.getBlickrichtung());

                int toGoX = x - robot.getXPos();
                int toGoY = y - robot.getYPos();

                if(toGoX < 0)
                {
                    while(robot.getBlickrichtung() != 's')
                    {
                        robot.LinksDrehen();
                    }

                    move(toGoX);
                } else
                {
                    toGoX *= -1;

                    while (robot.getBlickrichtung() != 's')
                    {
                        robot.LinksDrehen();
                    }

                    move(toGoX);
                }

                if (toGoY < 0)
                {
                    while (robot.getBlickrichtung() != 'o')
                    {
                        robot.LinksDrehen();
                    }

                    move(toGoY);
                }
                else
                {
                    toGoY *= -1;

                    while (robot.getBlickrichtung() != 'o')
                    {
                        robot.LinksDrehen();
                    }

                    move(toGoY);
                }

                /**
                switch (robot.getBlickrichtung())
                { 

                    case 'n':
                        {
                            //turn();
                            move(y - robot.getYPos());
                            break;
                        }
                    case 'o':
                        {
                            move(x - robot.getXPos());
                            break;
                        }
                    case 's':
                        {
                            move(y - robot.getYPos());
                            break;
                        }
                    case 'w':
                        {
                            move(x - robot.getXPos());
                            break;
                        }
                }
    */

                //Console.WriteLine("(" + robot.getXPos() + "|" + robot.getYPos() + ")");

                robot.RechtsDrehen();
            }


        }

        public void buildLayer(int breite)
        {
            for (int i = 0; i < breite; i++)
            {
                buildLine(breite);
                robot.Schritt();
                if (i % 2 == 0)
                {
                    robot.RechtsDrehen();
                    robot.Schritt();
                    robot.RechtsDrehen();
                }
                else
                {
                    robot.LinksDrehen();
                    robot.Schritt();
                    robot.LinksDrehen();
                }
            }
        }

        public void buildTower(int height)
        {
            int breite = height * 2 - 1;

            robot.Schritt();
            robot.LinksDrehen();

            for (int j = 0; j < height; j++)
            {
                buildLayer(breite);

                robot.Schritt();
                robot.RechtsDrehen();


                move(2);


                robot.LinksDrehen();

                breite -= 2;
            }
        }
    }
}

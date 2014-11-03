using System;
using System.Linq;
using System.Collections.Generic;
using BattleShip.Common;

namespace BattleShip
{
    public class Engine
    {
        protected IRenderer renderer;
        protected IUserInput userInput;
        protected List<Ship> robotShips; // testin
        protected List<Ship> playerShips;
        protected List<Gift> robotGifts;
        protected List<Gift> playerGifts;
        protected List<Sea> seas;
        protected Random randGenerator = new Random();
        private int playerFleet;
        private int robotFleet;
        private IntelligentBot iBoot;

        //constructor
        public Engine(IRenderer renderer, IUserInput userInput)
        {
            this.renderer = renderer;
            this.userInput = userInput;
            this.robotShips = new List<Ship>();
            this.playerShips = new List<Ship>();
            this.playerGifts = new List<Gift>();
            this.robotGifts = new List<Gift>();
            this.seas = new List<Sea>();
            this.playerFleet = 0;
            this.robotFleet = 0;
            this.iBoot = new IntelligentBot();
        }

        //methods for adding to the game object lists
        protected void AddRobotShips(Ship ship)
        {
            this.robotShips.Add(ship);
        }//generates robotShips in ConfigureRobotGameFields
        
        protected void AddPlayerShips(Ship ship)
        {
            this.playerShips.Add(ship);
        }
        
        public void AddPlayerGift(Gift gift)
        {
            this.playerGifts.Add(gift);
        }

        public void AddRobotGift(Gift gift)
        {
            this.robotGifts.Add(gift);
        }
        
        public void AddSea(Sea sea)
        {
            this.seas.Add(sea);
        }//will add two seas in Main (one of player and one of robot)


        protected Ship GenerateShip(int shipLength, int seaLength)
        {
            //randomly generate alignment
            Alignment align;
            if (randGenerator.Next(0, 2) == 0)
            {
                align = Alignment.Vertical;
            }
            else
            {
                align = Alignment.Horizontal;
            }
            //randomly generate StartPosition
            Position start = new Position();
            if (align == Alignment.Vertical)
            {
                start.X = randGenerator.Next(0, seaLength-shipLength);
                start.Y = randGenerator.Next(0, seaLength);
            }
            else
            {
                start.X = randGenerator.Next(0, seaLength);
                start.Y = randGenerator.Next(0, seaLength-shipLength);
            }
            return new Ship(start, shipLength, align);
        }

        //protected Position GenerateRobotShoot()
        //{
        //    Position robotShot=new Position();
        //    robotShot.X=randGenerator.Next(0, seas[0].GetBody().GetLength(0));
        //    robotShot.Y  = randGenerator.Next(0, seas[0].GetBody().GetLength(0));
        //    return robotShot;
        //}

        public void ConfigureGameField(Sea someSea, int shipMaxLength)
        {
            if (shipMaxLength > someSea.GetBody().GetLength(0) - 2)
            {
                throw new OutOfShipLengthException("Exceeded maximal ship length.", someSea.GetBody().GetLength(0) - 2);
            }

            for (int shipLength = shipMaxLength; shipLength >= 2; shipLength--)
            {
                while (true)
                {
                    Ship currentShip;
                    if (someSea is PlayerSea)
                    {
                        string message = string.Format("Ship`s length: {0}. Enter ships parameters in format: \r\nStart position: X Y:\r\nAlignment:",shipLength);
                        renderer.AddMessageToRender(message);
                        renderer.RenderAll();
                        renderer.ClearRenderObjects();
                        currentShip = this.userInput.ReadInputShip(shipLength);
                    }
                    else
                    {
                        currentShip = this.GenerateShip(shipLength, someSea.GetBody().GetLength(0));
                    }

                    Position[] currentShipBody = currentShip.GetBody() as Position[];
                    int freePositions = 0;

                    foreach (var position in currentShipBody)
                    {
                        if (someSea is PlayerSea)
                        {
                            if ((position.X < someSea.GetBody().GetLength(0) && position.Y < someSea.GetBody().GetLength(1)) && (someSea[position.X, position.Y] == State.Empty))
                            {
                                freePositions++;
                            }
                        }
                        else if(someSea[position.X, position.Y] == State.Empty)
                        {
                            freePositions++;
                        }
                    }

                    if (freePositions == shipLength)
                    {
                        foreach (var position in currentShipBody)
                        {
                            someSea[position.X, position.Y] = State.Ship;
                        }

                        if (someSea is PlayerSea)
                        {
                            this.AddPlayerShips(currentShip);
                            string message = string.Format("Ship with length {0} was created",shipLength);
                            renderer.AddMessageToRender(message);
                            renderer.RenderAll();
                            renderer.ClearRenderObjects();
                        }
                        else
                        {
                            this.AddRobotShips(currentShip);
                        }

                        break;
                    }
                    else if (someSea is PlayerSea)
                    {
                        string message = string.Format("Ship with length {0} was NOT created", shipLength);
                        renderer.AddMessageToRender(message);
                        renderer.RenderAll();
                        renderer.ClearRenderObjects();
                    }
                }
            }

            this.AddSea(someSea);
        }

        public virtual void RunGame()
        {
            while (playerFleet<playerShips.Count && robotFleet<robotShips.Count)
            {
                Console.Clear();
                renderer.AddMessageToRender("Oponent sea:" + Environment.NewLine);
                renderer.AddSeaToRender(seas[0]);
                renderer.AddMessageToRender(Environment.NewLine + "Your sea:" + Environment.NewLine);
                renderer.AddSeaToRender(seas[1]);
               
                Position shot;

                renderer.RenderAll();
                renderer.ClearRenderObjects();


                renderer.AddMessageToRender("Insert coordinates to shoot int oponent field:");

                renderer.RenderAll();
                renderer.ClearRenderObjects();

                shot = userInput.ReadShootCommand();
                //shot = this.iBoot.GetNextPosition(seas[0]); // test IntelligentBot
                this.ProcessShot(seas[0], shot);

                shot = this.iBoot.GetNextPosition(seas[1]);
                //shot = GenerateRobotShoot(); // the GenerateRobotShoot(); is commented below
                // iBoot.GetNextPosition(seas[1]);
                this.ProcessShot(seas[1], shot);
              
                System.Threading.Thread.Sleep(50);

            }

            string message;
            if (playerShips.Count==playerFleet)
            {
                message = "COMPUTER WINS!";
            }
            else
            {
                message = "YOU WIN!";
            }
            renderer.ClearRenderObjects();
            Console.Clear();
            renderer.AddMessageToRender(message);
            renderer.RenderAll();
        }

        private void ProcessShot(Sea sea, Position shot)
        {
            List<Ship> fleet= new List<Ship>();
            if (sea is BootSea)
            {
                fleet = robotShips;
            }
            else
            {
                fleet = playerShips;
            }

            
            bool isShip = sea.RespondToHit(shot);
            if (isShip)
            {
                foreach (Ship ship in fleet)
                {
                    foreach (Position position in ship.GetBody())
                    {
                        if (position.Equals(shot))
                        {
                            bool destoroyed = ship.RespondToHit(shot);
                            if (destoroyed)
                            {
                                if (sea is BootSea)
                                {
                                    robotFleet++;
                                }
                                else
                                {
                                    playerFleet++;
                                }
                            }
                        }

                    }
                }
                //    foreach (Gift gift in robotGifts)
                //    {
                //        if (gift.StartPosition.Equals(playerShotPosition))
                //        {
                //            gift.RespondToHit();
                //        }
                //    }
            }

        }
    }
}

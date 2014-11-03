using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Common
{
    public class IntelligentBot
    {
        private Random generator = new Random();
        private static bool targetHit = false;
        private static int addition = 1;
        private static int count = 4;
        private static Position lastHitPosition = new Position(0, 0);
       

        
            public Position GetNextPosition(Sea sea)
            {
                Position robotShotPos = new Position();
          

                if(sea[lastHitPosition.X, lastHitPosition.Y] != State.TargetHit && 
                    targetHit == false)
                {
                    robotShotPos = GetRandomPos(sea);
                   

                    lastHitPosition = robotShotPos; 
                    return robotShotPos;
                }
                    
                else if (sea[lastHitPosition.X , lastHitPosition.Y] == State.TargetHit)
                {
                    targetHit = true;
                    robotShotPos.X = lastHitPosition.X + addition;        
                    robotShotPos.Y = lastHitPosition.Y;

                    if (robotShotPos.X > 9 || robotShotPos.X < 0
                         || sea[robotShotPos.X, robotShotPos.Y] == State.TargetHit)
                    {
                        robotShotPos = GetRandomPos(sea);
                        targetHit = false;
                        count = 4;
                        lastHitPosition = robotShotPos;

                        return robotShotPos;
                    }


                    count--;
                    lastHitPosition = robotShotPos;

                    return robotShotPos;
                }   
   
                else if (targetHit == true && count > 3)
                {
                    robotShotPos.Y = lastHitPosition.Y;
                    robotShotPos.X = lastHitPosition.X + addition;

                    if (robotShotPos.X > 9 || robotShotPos.X < 0
                        || sea[robotShotPos.X, robotShotPos.Y] == State.TargetHit)
                    {
                        robotShotPos = GetRandomPos(sea);
                        targetHit = false;
                        count = 4;
                        lastHitPosition = robotShotPos;

                        return robotShotPos;
                    }

                    
                    count--;

                    lastHitPosition = robotShotPos;

                    return robotShotPos;
                   
                }

                else if (targetHit == true && count <=3 )
                {
                    robotShotPos.X = lastHitPosition.X ;
                    robotShotPos.Y = lastHitPosition.Y + addition;
                    if (robotShotPos.Y > 9 || robotShotPos.Y < 0
                        || sea[robotShotPos.X, robotShotPos.Y] == State.TargetHit)
                    {
                       robotShotPos = GetRandomPos(sea);
                       targetHit = false;
                       count = 4;
                       lastHitPosition = robotShotPos;

                       return robotShotPos;
                    }

                  
                    count--;
                    addition *= -1;

                    if (count==0)
                    {
                        count = 4;
                        targetHit = false;
                    }

                    lastHitPosition = robotShotPos;
                    return robotShotPos;
                }
                else
                {
                    robotShotPos = GetRandomPos(sea);
                    lastHitPosition = robotShotPos;

                    return robotShotPos;
                }

               
                
            }
   
            private Position GetRandomPos(Sea sea)
            {
                
                    Position robotShotPos = new Position();
                    
                    robotShotPos.X = generator.Next(0, 9);
                    robotShotPos.Y = generator.Next(0, 9);


                    while (sea[robotShotPos.X, robotShotPos.Y] == State.MissedHit
                        || sea[robotShotPos.X, robotShotPos.Y] == State.TargetHit)
                    {
                        robotShotPos.X = generator.Next(0, 9);
                        robotShotPos.Y = generator.Next(0, 9);
                    }

            
                    return robotShotPos;
                }
            }

    
}

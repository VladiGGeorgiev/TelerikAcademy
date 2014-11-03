using System;
namespace BattleShip.Common
{
    public class Gift : BattleObject
    {
        public Gift(Position startPosition)
            : base(startPosition)
        {
        }

        public override Array GetBody()
        {
            return new Position[] 
            {
                this.StartPosition 
            };
        }
    }
}

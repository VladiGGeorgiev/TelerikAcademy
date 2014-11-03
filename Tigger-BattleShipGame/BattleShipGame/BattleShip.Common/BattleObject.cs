using System;
namespace BattleShip.Common
{
    public abstract class BattleObject : GameObject
    {
        private Position startPosition; //this will be the top/left coordinate of the object;

        public bool IsDestroyed 
        { 
            get; protected 
            set; 
        }

        public int TotalDamage
        { 
            get; 
            protected set;
        }

        public BattleObject(Position startPosition)
        {
            this.startPosition = startPosition;
            this.IsDestroyed = false;
            this.TotalDamage = 0;
        }

        public Position StartPosition
        {
            get
            {
                return this.startPosition;
            }

            protected set
            {
                this.startPosition = value;
            }
        }

        public override Array GetBody()
        {
            return new Position[]
            {
                this.startPosition
            };
        }

        public override bool RespondToHit(Position position)
        {
            return this.IsDestroyed = true;
        }
    }
}

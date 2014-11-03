namespace BattleShip.Common
{
    using System;

    public class Ship : BattleObject
    {
        protected int length;
        protected Position[] body;

        public Alignment ShipAlignment 
        { 
            get;
            protected set; 
        }

        public override Array GetBody()
        {
            return this.body;
        }

        public int Length
        {
            get 
            { 
                return this.length; 
            }

            set 
            {
                if (value < 2)
                {
                    throw new OutOfShipLengthException("Ship length too short!",2);
                }

                this.length = value;
            }
        }

        public Ship(Position startPosition, int length, Alignment alignment)
            : base(startPosition)
        {
            this.Length = length;
            this.ShipAlignment = alignment;
            this.StartPosition = startPosition;
            this.body = this.CreateShipBody();
        }

        public override bool RespondToHit(Position position)
        {
            this.TotalDamage++;
            if (this.TotalDamage == this.length)
            {
                this.IsDestroyed = true;
            }
            return IsDestroyed;
        }

        private Position[] CreateShipBody()
        {
            Position[] tempBody = new Position[this.length];

            for (int i = 0; i < this.length; i++)
            {
                if (this.ShipAlignment == Alignment.Vertical)
                {
                    tempBody[i] = new Position(this.StartPosition.X + i, this.StartPosition.Y);
                }
                else
                {
                    tempBody[i] = new Position(this.StartPosition.X, this.StartPosition.Y + i);
                }
            }

            return tempBody;
        }
    }
}

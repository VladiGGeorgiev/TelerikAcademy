namespace BattleShip.Common
{
    using System;

    public abstract class Sea : GameObject
    {
        private State[,] stateMatrix;

        public Sea(int rows, int cols)
        {
            this.stateMatrix = new State[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    this[row, col] = State.Empty;
                }
            }

            
        }
        
        public State this[int row, int col]
        {
            get 
            {
                return this.stateMatrix[row, col]; 
            }

            set 
            { 
                this.stateMatrix[row, col] = value; 
            }
        }

        public override Array GetBody()
        {
            return this.stateMatrix;
        }

        public override bool RespondToHit(Position position)
        {
            if (this[position.X, position.Y]==State.Ship)
            {
                this[position.X, position.Y] = State.TargetHit;
                return true;
            }
            else if (this[position.X, position.Y] == State.Empty)
            {
                this[position.X, position.Y] = State.MissedHit;
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}

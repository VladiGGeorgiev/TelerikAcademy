namespace Minesweeper.Common
{
    using System;

    public class Score : IComparable
    {
        private string playerName;
        private int playerPoints;

        public Score(string playerName, int points)
        {
            this.PlayerName = playerName;
            this.PlayerPoints = points;
        }

        /// <summary>
        /// Gets or sets the player points.
        /// </summary>
        /// <value>The player points.</value>
        public int PlayerPoints
        {
            get
            {
                return this.playerPoints;
            }
            set
            {
                this.playerPoints = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        /// <value>The name of the player.</value>
        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
            private set
            {
                this.playerName = value;
            }
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Score))
            {
                throw new ArgumentException("Compare Object is not ScoreRecord!");
            }

            //TODO: Check logic and make it more understandable! 
            int objScore = ((Score)obj).playerPoints;
            return -1 * this.playerPoints.CompareTo(objScore);
        }
    }
}

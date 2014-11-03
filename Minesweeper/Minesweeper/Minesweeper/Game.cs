using Minesweeper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Game
    {
        private int currentScore;
        private List<Score> scores;

        public Game(int rows, int columns, int mines)
        {
            this.scores = new List<Score>();
        }

        /// <summary>
        /// Gets or sets the current score.
        /// </summary>
        /// <value>The current score.</value>
        public int CurrentScore
        {
            get
            {
                return this.currentScore;
            }
            protected set
            {
                this.currentScore = value;
            }
        }


        /// <summary>
        /// Gets or sets the scores.
        /// </summary>
        /// <value>The scores.</value>
        public List<Score> Scores
        {
            get
            {
                return this.scores;
            }
            protected set
            {
                this.scores = value;
            }
        }

        public virtual void Play()
        {
            currentScore = 0;
        }
    }
}

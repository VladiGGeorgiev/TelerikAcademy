namespace Minesweeper.Common
{
    public class Cell
    {
        private char state = '?';
        private bool isRevealed;

        public Cell(char state)
        {
            this.State = state;
            this.IsRevealed = false;
        }

        /// <summary>
        /// Gets or sets the is revealed.
        /// </summary>
        /// <value>The is revealed.</value>
        public bool IsRevealed
        {
            get
            {
                return this.isRevealed;
            }
            set
            {
                this.isRevealed = value;
            }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public char State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }

        public void Reveal()
        {
            this.IsRevealed = true;
        }
    }
}
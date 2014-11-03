namespace Refactoring
{
    using System;

    public class Delta
    {
        private Direction direction;

        static Delta()
        {
            DirectionsCount = Enum.GetValues(typeof(Direction)).Length;
        }

        public Delta(Direction direction)
        {
            this.Direction = direction;
        }

        public static int DirectionsCount { get; private set; }

        public Direction Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                this.direction = value;

                switch (value)
                {
                    case Direction.Southeast:
                        {
                            this.Row = 1;
                            this.Col = 1;
                            break;
                        }

                    case Direction.South:
                        {
                            this.Row = 1;
                            this.Col = 0;
                            break;
                        }

                    case Direction.Southwest:
                        {
                            this.Row = 1;
                            this.Col = -1;
                            break;
                        }

                    case Direction.West:
                        {
                            this.Row = 0;
                            this.Col = -1;
                            break;
                        }

                    case Direction.Northwest:
                        {
                            this.Row = -1;
                            this.Col = -1;
                            break;
                        }

                    case Direction.North:
                        {
                            this.Row = -1;
                            this.Col = 0;
                            break;
                        }

                    case Direction.Northeast:
                        {
                            this.Row = -1;
                            this.Col = 1;
                            break;
                        }

                    default:
                        {
                            this.Row = 0;
                            this.Col = 1;
                            break;
                        }
                }
            }
        }

        public int Row { get; private set; }

        public int Col { get; private set; }

        public void UpdateDirectionClockwise()
        {
            if ((int)this.Direction == DirectionsCount - 1)
            {
                this.Direction = 0;
            }
            else
            {
                this.Direction++;
            }
        }
    }
}

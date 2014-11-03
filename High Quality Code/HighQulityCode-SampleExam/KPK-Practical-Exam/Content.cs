namespace ContentCatalog
{
    using System;
    using ContentCatalog.Enumerations;

    public class Content : IComparable, IContent
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        private string url;

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public ContentType Type { get; set; }

        public string TextRepresentation { get; set; }

        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ContentParameterType.Title];
            this.Author = commandParams[(int)ContentParameterType.Author];
            this.Size = long.Parse(commandParams[(int)ContentParameterType.Size]);
            this.Url = commandParams[(int)ContentParameterType.Url];
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("You can not compare content with null object!");
            }

            Content otherContent = obj as Content;
            if (otherContent == null)
            {
                throw new ArgumentException("Object is not a Content");
            }

            int comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);
            return comparisonResul;
        }

        public override string ToString()
        {
            string output = string.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.Url);
            return output;
        }
    }
}

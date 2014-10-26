namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;

    public class WordDocument : OfficeDocuments, IEditable
    {
        public string Characters { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "chars")
            {
                this.Characters = value;
            }

            base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("chars", this.Characters));
            base.SaveAllProperties(output);
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}

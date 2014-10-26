
namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;

    public class PDFDocument : EncryptableDocument
    {
        public string Pages { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "pages")
            {
                this.Pages = value;
            }

            base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("pages", this.Pages));
            base.SaveAllProperties(output);
        }
    }
}

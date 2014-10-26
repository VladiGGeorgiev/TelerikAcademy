namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;

    public class BinaryDocument : Document
    {
        public string Size { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "size")
            {
                this.Size = value;
            }
            
            base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("size", this.Size));
            base.SaveAllProperties(output);
        }
    }
}

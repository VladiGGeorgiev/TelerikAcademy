namespace DocumentSystem
{
    public abstract class EncryptableDocument : BinaryDocument, IEncryptable
    {
        public bool IsEncrypted { get; protected set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }

        public override string ToString()
        {
            if (IsEncrypted)
            {
                return this.GetType().Name + "[encrypted]";
            }
            else
            {
                return base.ToString();
            }
        }
    }
}

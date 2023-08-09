namespace lab4
{
    internal class EncryptorDecorator : TextTransformerDecorator
    {
        public EncryptorDecorator(ITextTransformation textTransformer) : base(textTransformer)
        {
        }

        public override string Transform(string text)
        {
            string encryptedText = Encrypt(text);
            return base.Transform(encryptedText);
        }

        private static string Encrypt(string text)
        {
            int shift = 3;
            string encryptedText = "";

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char encryptedChar = (char)(((char.ToUpper(c) - 'A' + shift) % 26) + 'A');
                    encryptedText += encryptedChar;
                }
                else
                {
                    encryptedText += c;
                }
            }

            return encryptedText;
        }

        
       
    }
}

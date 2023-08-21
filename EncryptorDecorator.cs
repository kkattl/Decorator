namespace lab4
{
    public class EncryptorDecorator : TextTransformerDecorator
    {
        public EncryptorDecorator(ITextTransformation textTransformer) : base(textTransformer)
        {
        }

        public override string Transform(string text)
        {
            string encryptedText = Encrypt(text);
            return base.Transform(encryptedText);
        }

        public string Encrypt(string plainText, int shift = 3)
        {
            string encryptedText = "";

            foreach (char c in plainText)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    encryptedText += (char)((c - baseChar + shift) % 26 + baseChar);
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

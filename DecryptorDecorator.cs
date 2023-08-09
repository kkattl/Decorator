namespace lab4
{
    internal class DecryptorDecorator : TextTransformerDecorator
    {
        public DecryptorDecorator(ITextTransformation textTransformer) : base(textTransformer)
        {
        }

        public override string Transform(string text)
        {
            string decryptedText = Decrypt(text);
            return decryptedText;
        }

        private static string Decrypt(string text)
        {
            int shift = 3;
            string decryptedText = "";

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char decryptedChar = (char)(((char.ToUpper(c) - 'A' - shift + 26) % 26) + 'A');
                    decryptedText += decryptedChar;
                }
                else
                {
                    decryptedText += c;
                }
            }

            return decryptedText;
        }
    }
}

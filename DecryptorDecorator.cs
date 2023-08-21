namespace lab4
{
    public class DecryptorDecorator : TextTransformerDecorator
    {
        public DecryptorDecorator(ITextTransformation textTransformer) : base(textTransformer)
        {
        }

        public override string Transform(string filePath)
        {
            string encryptedText = base.Transform(filePath); 
            string decryptedText = Decrypt(encryptedText); 
            return decryptedText;
        }
        public string Decrypt(string encryptedText, int shift = 3)
        {
            string decryptedText = "";

            foreach (char c in encryptedText)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    int shiftedValue = (c - baseChar - shift + 26) % 26;
                    decryptedText += (char)(shiftedValue + baseChar);
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

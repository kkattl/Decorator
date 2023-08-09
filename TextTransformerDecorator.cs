namespace lab4
{
    abstract class TextTransformerDecorator : ITextTransformation
    {
        protected ITextTransformation textTransformation;

        public TextTransformerDecorator(ITextTransformation textTransformer)
        {
            this.textTransformation = textTransformer;
        }

        public virtual string Transform(string text)
        {
            return textTransformation.Transform(text);
        }
    }
}
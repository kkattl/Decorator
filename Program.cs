using System;

namespace lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITextTransformation jsonWriter = new TextSaver("output");
            ITextTransformation jsonReader = new TextReader();

           
            ITextTransformation decoratedWriter = new TranslatorDecorator(new EncryptorDecorator(jsonWriter));
            ITextTransformation decoratedReader = new DecryptorDecorator(jsonReader);
            
            string inputText = "Bonjour le monde!";
            string transformedText = decoratedWriter.Transform(inputText);
            
            string readedText = decoratedReader.Transform("output.json");
            Console.WriteLine("Transformed Text: " + transformedText);
            Console.WriteLine("Text: " + readedText);
            Console.ReadKey();
           
        }

      
    
    }
}

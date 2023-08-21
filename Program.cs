using System;
using System.ComponentModel;

namespace lab4
{
    public class Program
    {
        static void Main(string[] args)
        {
            ITextTransformation jsonWriter = new TextSaver("decoratedText");
            ITextTransformation jsonReader = new TextReader();


            ITextTransformation decoratedWriter = new TranslatorDecorator(new EncryptorDecorator(jsonWriter));
            ITextTransformation decoratedReader = new DecryptorDecorator(jsonReader);
            
            string inputText = "Bonjour le monde";
            string transformedText = decoratedWriter.Transform(inputText);

            string readedText = decoratedReader.Transform("decoratedText.json");
            Console.WriteLine("Transformed Text: " + transformedText);
            Console.WriteLine("Text: " + readedText);
            Console.ReadKey();

           
        }

      
    
    }
}

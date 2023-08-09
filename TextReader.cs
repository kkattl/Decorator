using Newtonsoft.Json;
using System;
using System.IO;


namespace lab4
{
    internal class TextReader : ITextTransformation
    {

        public string Transform(string filePath)
        {

            try
            {
                string jsonData = File.ReadAllText(filePath);
                string text = JsonConvert.DeserializeObject<string>(jsonData);
                return text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while reading JSON file: " + ex.Message);
                return null;
            }
        }



    }
}


using Newtonsoft.Json;
using System;
using System.IO;


namespace lab4
{
    public class TextReader : ITextTransformation
    {

        public string Transform(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string jsonData = reader.ReadToEnd();
                        string text = JsonConvert.DeserializeObject<string>(jsonData);
                        return text;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while reading JSON file: " + ex.Message);
                return null;
            }
        }



    }
}


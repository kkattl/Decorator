
using System.IO;
using Newtonsoft.Json;

namespace lab4
{
    public class TextSaver : ITextTransformation
    {
        private string FilePath;
        public TextSaver(string filePath)
        {
            this.FilePath = filePath + ".json";
        }

        public string Transform(string text)
        {

           
            string jsonData = JsonConvert.SerializeObject(text);

            File.WriteAllText(FilePath, jsonData);

            return jsonData; 
        }
    }
}

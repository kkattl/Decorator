using System.Net;
using System;

namespace lab4
{
    internal class TranslatorDecorator : TextTransformerDecorator
    {
        public TranslatorDecorator(ITextTransformation text) : base(text)
        {
        }

        public override string Transform(string text)
        {
            string translatedText = Translate(text);
            return base.Transform(translatedText);
        }

        public String Translate(String word)
        {
            var toLanguage = "en";//English
            var fromLanguage = "fr";//French
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={WebUtility.UrlEncode(word)}";
            using (var webClient = new WebClient())
            {
                webClient.Encoding = System.Text.Encoding.UTF8;
                try
                {
                    var result = webClient.DownloadString(url);
                    result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                    return result;
                }
                catch (Exception)
                {
                    return "Error";
                }
            }
        }
    }
}

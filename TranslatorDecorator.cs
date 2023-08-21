using System.Net;
using System;

namespace lab4
{
    public class TranslatorDecorator : TextTransformerDecorator
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
            var toLanguage = "en";
            var fromLanguage = "fr";
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

using System;

namespace JSONParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = "{\"name\":\"mohammed\"}";
            Input input = new Input(jsonString);
            Tokenizer t = new Tokenizer(input, new Tokenizable[] { 
                // handlers ...
            });

            Token token = t.tokenize();
            while (token != null)
            {
                Console.WriteLine(token.Value);
                token = t.tokenize();
            }
        }
    }
}

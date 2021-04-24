using System;

namespace JSONParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = "{10.0199999999994e-2222222225 \"name\":\"mohammed\"   \"hi\"  }";
            Input input = new Input(jsonString);
            Tokenizer t = new Tokenizer(input, new Tokenizable[] {
                new NumberTokenizer(),
                 new braOpenOpejct(),
                new WhiteSpaceTokenizer(),
                new colon(),
                new StringTokenizer(),
                new braCloseOpejct()

            });

            //Token token = t.tokenize();
            //Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            //while (token != null)
            //{
            //    Console.WriteLine(token.Value + "  " + token.Type);
            //    token = t.tokenize();
            //}

            Console.WriteLine("---------------------------");
            foreach (Token tk in t.all())
            {
                Console.WriteLine(tk.Value + "  " + tk.Type);
            }
        }
    }
}

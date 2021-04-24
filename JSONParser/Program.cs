using JSONParser.JSONParser;
using System;
using System.Collections.Generic;

namespace JSONParser
{
    class Program
    {
        static List<Token> TestCase()
        {
            List<Token> t = new List<Token>();

            //whitespace
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));

            t.Add(new Token(0, 0, "open-bracket", "{"));

            //whitespace
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));

            //string value
            t.Add(new Token(0, 0, "string", "name"));
            t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "string", "mohammed"));

            //whitespace
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));

            //sep
            t.Add(new Token(0, 0, "comma", ","));

            //number value
            t.Add(new Token(0, 0, "string", "num_value"));
            t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "number", "51881.79"));

            //sep
            t.Add(new Token(0, 0, "comma", ","));

            //whitespace
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));

            //number value
            t.Add(new Token(0, 0, "string", "num_value"));
            t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "number", "51881.79"));

            //sep
            t.Add(new Token(0, 0, "comma", ","));

            //bool true
            t.Add(new Token(0, 0, "string", "bool_true"));
            t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "bool", "true"));

            //sep
            t.Add(new Token(0, 0, "comma", ","));

            //bool false
            t.Add(new Token(0, 0, "string", "bool_false"));
            t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "bool", "false"));

            //sep
            t.Add(new Token(0, 0, "comma", ","));

            //null
            t.Add(new Token(0, 0, "string", "null_value"));
            t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "null", "null"));

            //sep
            t.Add(new Token(0, 0, "comma", ","));

            //object
            t.Add(new Token(0, 0, "string", "object_value"));
            t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "open-bracket", "{"));

            //string value
            t.Add(new Token(0, 0, "string", "name"));
            t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "string", "mohammed"));

            //sep
            t.Add(new Token(0, 0, "comma", ","));

            //number value
            t.Add(new Token(0, 0, "string", "num_value"));
            t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "number", "51881.79"));


            t.Add(new Token(0, 0, "close-bracket", "}"));

            //sep
            t.Add(new Token(0, 0, "comma", ","));

            //object-empty
            t.Add(new Token(0, 0, "string", "object_value"));
            t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "open-bracket", "{"));

            t.Add(new Token(0, 0, "close-bracket", "}"));


            //sep
            t.Add(new Token(0, 0, "comma", ","));

            //array
            t.Add(new Token(0, 0, "string", "array_value"));
            t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "open-squ-bra", "["));

            //string value
            //t.Add(new Token(0, 0, "string", "name"));
            //t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "string", "mohammed"));

            //sep
            t.Add(new Token(0, 0, "comma", ","));

            // empty object
            t.Add(new Token(0, 0, "open-bracket", "{"));
            t.Add(new Token(0, 0, "close-bracket", "}"));

            //sep
            t.Add(new Token(0, 0, "comma", ","));

            //number value
            //t.Add(new Token(0, 0, "string", "num_value"));
            //t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "number", "51881.79"));


            t.Add(new Token(0, 0, "close-squ-bra", "]"));

            //sep
            t.Add(new Token(0, 0, "comma", ","));

            //array-empty
            t.Add(new Token(0, 0, "string", "array_value"));
            t.Add(new Token(0, 0, "colon", ":"));
            t.Add(new Token(0, 0, "open-squ-bra", "["));
            t.Add(new Token(0, 0, "close-squ-bra", "]"));

            //sep
            //t.Add(new Token(0, 0, "comma", ","));

            //..
            t.Add(new Token(0, 0, "close-bracket", "}"));


            //whitespace
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));
            t.Add(new Token(0, 0, "whitespace", " "));

            return t;
        }

        static void PrintObject(JsonObject o)
        {
            foreach (var item in o.Value)
            {
                if (item.Value is JsonString) Console.WriteLine($"{item.Key} : {((JsonString)item.Value).Value}");
                else if (item.Value is JsonNumber) Console.WriteLine($"{item.Key} : {((JsonNumber)item.Value).Value}");
                else if (item.Value is JsonBool) Console.WriteLine($"{item.Key} : {((JsonBool)item.Value).Value}");
                else if (item.Value is JsonNull) Console.WriteLine($"{item.Key} : {((JsonNull)item.Value).Value}"); //change to string "null" ?

                else if (item.Value is JsonObject)
                {
                    //PrintObjectValues(item.Value);
                    Console.WriteLine($"[Object] Key = {item.Key}");
                    PrintObject((JsonObject)item.Value);
                }
                else if (item.Value is JsonArray)
                {
                    //PrintObjectValues(item.Value);
                    Console.WriteLine($"[Array] Key = {item.Key}");
                    PrintArray((JsonArray)item.Value);
                }
                else throw new Exception("Unknown JsonValue type");

            }
        }

        static void PrintArray(JsonArray a)
        {
            for (int i = 0; i < a.Value.Length; i++)
            {
                if (a.Value[i] is JsonString) Console.WriteLine($"{((JsonString)a.Value[i]).Value}");
                else if (a.Value[i] is JsonNumber) Console.WriteLine($"{((JsonNumber)a.Value[i]).Value}");
                else if (a.Value[i] is JsonBool) Console.WriteLine($"{((JsonBool)a.Value[i]).Value}");
                else if (a.Value[i] is JsonNull) Console.WriteLine($"{((JsonNull)a.Value[i]).Value}");// print "null" instead?

                else if (a.Value[i] is JsonObject)
                {
                    //PrintObjectValues(item.Value);
                    Console.WriteLine($"[Object]");
                    PrintObject((JsonObject)a.Value[i]);
                }
                else if (a.Value[i] is JsonArray)
                {
                    //PrintObjectValues(item.Value);
                    Console.WriteLine($"[Array]");
                    PrintArray((JsonArray)a.Value[i]);
                }
                else throw new Exception("Unknown JsonValue type");
            }
        }

        static void Main(string[] args)
        {
            string jsonString = "{-0000e-0 \"name\":\"mohammed\"   \"hi\"  }";
            Input input = new Input(jsonString);
            Tokenizer t = new Tokenizer(input, new Tokenizable[] {
                new NumberTokenizer(),
                 new OpenBraceTokenizer(),
                new WhiteSpaceTokenizer(),
                new colonTokenizer(),
                new StringTokenizer(),
                new CloseBraceTokenizer()

            });

            Token token = t.tokenize();
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            while (token != null)
            {
                Console.WriteLine(token.Value + "  " + token.Type);
                token = t.tokenize();
            }

            Console.WriteLine("---------------------------");
            foreach (Token tk in t.all())
            {
                Console.WriteLine(tk.Value + "  " + tk.Type);
            }


            ///*
            // * Test wiht tokens list
            // =========================================================*/
            //var t = TestCase();

            //Parser p = new Parser();

            //JsonObject jo = p.Parse(t);

            ////print
            //PrintObject(jo);

            //Console.WriteLine("\n\n\n\n=================\n\n\n\n");

            /*
             * Test with json string
             * ==========================================================*/
            //string jsonString = "{\"name\":\"fahad\",\"bool_true\":true,\"bool_false\":false,\"null_value\":null,\"num_value\":95095,\"array_value\":[23,\"Hello there\",true,false,null],\"obj_key\":{\"i_am_key_in_sub_obj\":\"i_am_value_in_sub_object\"}}";

            //Parser p2 = new Parser();

            //JsonObject jo2 = p2.Parse(jsonString);

            ////print
            //PrintObject(jo2);

        }
    }
}

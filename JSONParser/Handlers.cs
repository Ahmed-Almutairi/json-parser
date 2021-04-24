using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class IdTokenizer : Tokenizable
    {
        private List<string> keywords;
        public IdTokenizer(List<string> keywords)
        {
            this.keywords = keywords;
        }
        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = t.input.peek();
            //Console.WriteLine(currentCharacter);
            return Char.IsLetter(currentCharacter) || currentCharacter == '_';
        }
        static bool isId(Input input)
        {
            char currentCharacter = input.peek();
            return Char.IsLetterOrDigit(currentCharacter) || currentCharacter == '_';
        }
        public override Token tokenize(Tokenizer t)
        {

            Token token = new Token(t.input.Position, t.input.LineNumber,
                "identifier", t.input.loop(isId));

            return token;
        }
    }
    public class NumberTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.input.peek() == '-' || Char.IsDigit(t.input.peek());
        }
        static string isNumber(Input input)
        {

            input.step();
            string str = "";

            if (input.Character == '-')
            {
                str += input.Character;
                if (input.peek() == '0')
                {
                    input.step();
                    str += input.Character;

                    if (input.peek() == '.')
                    {
                        input.step();
                        str += input.Character;

                        if (Char.IsDigit(input.peek()))
                        {
                            while (Char.IsDigit(input.peek()))
                            {
                                input.step();
                                str += input.Character;

                            }
                        }
                        if (input.peek() == 'e' || input.peek() == 'E')
                        {
                            input.step();
                            str += input.Character;

                            if (input.peek() == '-' || input.peek() == '+')
                            {
                                input.step();
                                str += input.Character;

                                if (Char.IsDigit(input.peek()))
                                {
                                    while (Char.IsDigit(input.peek()))
                                    {
                                        input.step();
                                        str += input.Character;

                                    }
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            else
                                throw new Exception();
                        }
                        else
                            throw new Exception();
                    }
                    else if (input.peek() == 'e' || input.peek() == 'E')
                    {
                        input.step();
                        str += input.Character;

                        if (input.peek() == '-' || input.peek() == '+')
                        {
                            input.step();
                            str += input.Character;

                            if (Char.IsDigit(input.peek()))
                            {
                                while (Char.IsDigit(input.peek()))
                                {
                                    input.step();
                                    str += input.Character;

                                }
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        else
                            throw new Exception();
                    }
                    else
                        throw new Exception();

                }
                else if (Char.IsDigit(input.peek()) && (int)Char.GetNumericValue(input.peek()) > 0 && (int)Char.GetNumericValue(input.peek()) < 10)
                {
                    input.step();
                }
                else
                    throw new Exception();
            }
            if (input.Character == '0')
            {
                str += input.Character;

                if (input.peek() == '.')
                {
                    input.step();
                    str += input.Character;

                    if (Char.IsDigit(input.peek()))
                    {
                        while (Char.IsDigit(input.peek()))
                        {
                            input.step();
                            str += input.Character;

                        }
                    }
                    if (input.peek() == 'e' || input.peek() == 'E')
                    {
                        input.step();
                        str += input.Character;

                        if (input.peek() == '-' || input.peek() == '+')
                        {
                            input.step();
                            str += input.Character;

                            if (Char.IsDigit(input.peek()))
                            {
                                while (Char.IsDigit(input.peek()))
                                {
                                    input.step();
                                    str += input.Character;

                                }
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        else
                            throw new Exception();
                    }
                    else
                        throw new Exception();
                }
                else if (input.peek() == 'e' || input.peek() == 'E')
                {
                    input.step();
                    str += input.Character;

                    if (input.peek() == '-' || input.peek() == '+')
                    {
                        input.step();
                        str += input.Character;

                        if (Char.IsDigit(input.peek()))
                        {
                            while (Char.IsDigit(input.peek()))
                            {
                                input.step();
                                str += input.Character;

                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                        throw new Exception();
                }
                else
                    throw new Exception();

            }
            System.Console.WriteLine((int)Char.GetNumericValue(input.Character));
            if (Char.IsDigit(input.Character) && (int)Char.GetNumericValue(input.Character) > 0 && (int)Char.GetNumericValue(input.Character) < 10)
            {
                str += input.Character;
                while (Char.IsDigit(input.peek()))
                {
                    input.step();
                    str += input.Character;
                }
                if (input.peek() == '.')
                {
                    input.step();
                    str += input.Character;

                    if (Char.IsDigit(input.peek()))
                    {
                        while (Char.IsDigit(input.peek()))
                        {
                            input.step();
                            str += input.Character;

                        }
                    }
                    if (input.peek() == 'e' || input.peek() == 'E')
                    {
                        input.step();
                        str += input.Character;

                        if (input.peek() == '-' || input.peek() == '+')
                        {
                            input.step();
                            str += input.Character;

                            if (Char.IsDigit(input.peek()))
                            {
                                while (Char.IsDigit(input.peek()))
                                {
                                    input.step();
                                    str += input.Character;

                                }
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        else
                            throw new Exception();
                    }
                    else
                        throw new Exception();
                }
            }

            return str;
        }
        public override Token tokenize(Tokenizer t)
        {
            return new Token(t.input.Position, t.input.LineNumber,
                "number", isNumber(t.input));
        }
    }
    public class WhiteSpaceTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return Char.IsWhiteSpace(t.input.peek());
        }
        static bool isWhiteSpace(Input input)
        {
            return Char.IsWhiteSpace(input.peek());
        }
        public override Token tokenize(Tokenizer t)
        {
            return new Token(t.input.Position, t.input.LineNumber,
                "whitespace", t.input.loop(isWhiteSpace));
        }
    }

    public class braOpenOpejct : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.input.peek() == '{';
        }

        public override Token tokenize(Tokenizer t)
        {
            t.input.step();
            return new Token(t.input.Position, t.input.LineNumber,
                "braOpenOpejct", "{");
        }



    }



    public class braCloseOpejct : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.input.peek() == '}';
        }

        public override Token tokenize(Tokenizer t)
        {

            t.input.step();

            return new Token(t.input.Position, t.input.LineNumber,
                "braCloseOpejct", "}");
        }



    }

    public class colon : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.input.peek() == ':';
        }

        public override Token tokenize(Tokenizer t)
        {

            t.input.step();
            return new Token(t.input.Position, t.input.LineNumber,
                "colon", ":");
        }



    }

    public class StringTokenizer : Tokenizable
    {

        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = t.input.peek();
            //Console.WriteLine(currentCharacter);
            return currentCharacter == '"';
        }
        static bool isString(Input input)
        {
            char currentCharacter = input.peek();
            return currentCharacter != '"';
        }
        public override Token tokenize(Tokenizer t)
        {
            t.input.step(); // "
            Token tk = new Token(t.input.Position, t.input.LineNumber,
                "String", t.input.loop(isString));
            t.input.step();
            return tk;
        }
    }

    // public class KeyTokenizer : Tokenizable
    // {
    //     public override bool tokenizable(Tokenizer t)
    //     {
    //         char currentCharacter = t.input.peek();
    //         //Console.WriteLine(currentCharacter);
    //         return currentCharacter == '"' && (t.input.Character == ',' || t.input.Character == '{');
    //     }
    //     static bool isKey(Input input)
    //     {
    //         char currentCharacter = input.peek();
    //         // fix later (if {" hfjjjff"} ) space after first "
    //         return (currentCharacter == ':' || input.Character == ' ') && (input.Character == '"');
    //     }
    //     public override Token tokenize(Tokenizer t)
    //     {

    //         Token token = new Token(t.input.Position, t.input.LineNumber,
    //             "key", t.input.loop(isKey));

    //         return token;
    //     }
    // }

}

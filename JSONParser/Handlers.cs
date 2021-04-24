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
                }
                else
                    throw new Exception();
            }
            else if (input.Character == '0')//65555
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
            else if (Char.IsDigit(input.Character) && (int)Char.GetNumericValue(input.Character) > 0 && (int)Char.GetNumericValue(input.Character) < 10)
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

    public class OpenBraceTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.input.peek() == '{';
        }

        public override Token tokenize(Tokenizer t)
        {
            t.input.step();
            return new Token(t.input.Position, t.input.LineNumber,
                "Open Brace", "{");
        }



    }

    public class CloseBraceTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.input.peek() == '}';
        }

        public override Token tokenize(Tokenizer t)
        {
            t.input.step();
            return new Token(t.input.Position, t.input.LineNumber,
                "Close Brace", "}");
        }



    }

    public class colonTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.input.peek() == ':';
        }

        public override Token tokenize(Tokenizer t)
        {
            t.input.step();
            return new Token(t.input.Position, t.input.LineNumber,
                "Colon", ":");
        }



    }

    public class CommaTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.input.peek() == ',';
        }

        public override Token tokenize(Tokenizer t)
        {

            t.input.step();
            return new Token(t.input.Position, t.input.LineNumber,
                "Comma", ",");
        }
    }

    public class OpenSquareBracketTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.input.peek() == '[';
        }

        public override Token tokenize(Tokenizer t)
        {

            t.input.step();
            return new Token(t.input.Position, t.input.LineNumber,
                "Open Square Bracket", "[");
        }
    }

    public class CloseSquareBracketTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.input.peek() == ']';
        }

        public override Token tokenize(Tokenizer t)
        {

            t.input.step();
            return new Token(t.input.Position, t.input.LineNumber,
                "Close Square Bracket", "]");
        }
    }

    public class boolTokenizer : Tokenizable
    {

        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = t.input.peek();
            //false;
            //true;
            //Console.WriteLine(currentCharacter);
            return currentCharacter == 'f' || currentCharacter == 't';
        }

        public override Token tokenize(Tokenizer t)
        {
            String buffer = "";

            if (t.input.peek() == 'f')
            {
                //f
                buffer += t.input.step().Character;
                //a
                buffer += t.input.step().Character;
                //l
                buffer += t.input.step().Character;
                //s
                buffer += t.input.step().Character;
                //e
                buffer += t.input.step().Character;
                if (buffer != "false") throw new Exception("unexpected token");

            }
            else if (t.input.peek() == 't')
            {
                //t
                buffer += t.input.step().Character;
                //r
                buffer += t.input.step().Character;
                //u
                buffer += t.input.step().Character;
                //e
                buffer += t.input.step().Character;

                if (buffer != "true") throw new Exception("unexpected token");

            }


            Token tk = new Token(t.input.Position, t.input.LineNumber,
                "Bool", buffer);

            return tk;
        }
    }

    public class NullTokenizer : Tokenizable
    {

        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = t.input.peek();
            //Console.WriteLine(currentCharacter);
            //null;
            return currentCharacter == 'n';
        }

        public override Token tokenize(Tokenizer t)
        {
            String buffer = "";
            if (t.input.peek() == 'n')
            {
                //n
                buffer += t.input.step().Character;
                //u
                buffer += t.input.step().Character;
                //l
                buffer += t.input.step().Character;
                //l
                buffer += t.input.step().Character;

                if (buffer != "null") throw new Exception("unexpected token");

            }

            Token tk = new Token(t.input.Position, t.input.LineNumber,
                "Null", buffer);

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

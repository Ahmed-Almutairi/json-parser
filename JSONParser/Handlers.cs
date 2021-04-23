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
            return Char.IsDigit(t.input.peek());
        }
        static bool isDigit(Input input)
        {
            return Char.IsDigit(input.peek());
        }
        public override Token tokenize(Tokenizer t)
        {
            return new Token(t.input.Position, t.input.LineNumber,
                "number", t.input.loop(isDigit));
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

}

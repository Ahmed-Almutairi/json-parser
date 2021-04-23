using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class Token
    {
        public int Position { set; get; }
        public int LineNumber { set; get; }
        public string Type { set; get; }
        public string Value { set; get; }
        public Token(int position, int lineNumber, string type, string value)
        {
            this.Position = position;
            this.LineNumber = lineNumber;
            this.Type = type;
            this.Value = value;
        }
    }
    public abstract class Tokenizable
    {
        public abstract bool tokenizable(Tokenizer tokenizer);
        public abstract Token tokenize(Tokenizer tokenizer);
    }
    public class Tokenizer
    {
        public List<Token> tokens;
        public bool enableHistory;
        public Input input;
        public Tokenizable[] handlers;
        public Tokenizer(string source, Tokenizable[] handlers)
        {
            this.input = new Input(source);
            this.handlers = handlers;
        }
        public Tokenizer(Input source, Tokenizable[] handlers)
        {
            this.input = source;
            this.handlers = handlers;
        }
        public Token tokenize()
        {
            foreach (var handler in this.handlers)
                if (handler.tokenizable(this)) return handler.tokenize(this);
            return null;
        }
        public List<Token> all()
        {
            List<Token> ts = new List<Token>();
            Token t = this.tokenize();

            if(t == null) throw new Exception("Invalid token");

            while (t != null)
            {
                ts.Add(t);
                t = tokenize();

                if (t == null && input.hasMore())
                    throw new Exception("Invalid token");

                    //foreach (var handler in this.handlers)

                    //if (handler.tokenizable(this)) t = handler.tokenize(this);
            }

            return ts;
        }

    }

}

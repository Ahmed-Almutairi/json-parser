using JSONParser.JSONParser;
using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class Parser
    {
        protected string KeyString = "string";
        protected string KeyNumber = "number";
        protected string KeyBool = "bool";
        protected string KeyNull = "null";
        //protected string KeyObject = "object";
        //protected string KeyArray = "array";
        protected string KeyOpenBracket = "open-bracket";
        protected string KeyCloseBracket = "close-bracket";
        protected string KeyOpenSquBra = "open-squ-bra";
        protected string KeyCloseSquBra = "close-squ-bra";
        protected string KeyColon = "colon";
        protected string KeyComma = "comma";
        protected string KeyWhitespace = "whitespace";

        public JsonObject Parse(string jsonString)
        {
            throw new NotImplementedException();

            //Input input = new Input(jsonString);
            //Tokenizer t = new Tokenizer(input, new Tokenizable[] {
            //    // handler
            //});

            //return Parse(t.all());
        }

        public JsonObject Parse(List<Token> tokens)
        {
            //remove whitespaces ?
            RemoveWhitespaces(ref tokens);

            var o = ParseObject(tokens);

            if (tokens.Count > 0) throw new Exception("Invalid json string"); // there may be a } in the middle of the string that will case the parsing process to stop!

            return o;
        }

        protected void RemoveWhitespaces(ref List<Token> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Type == KeyWhitespace)
                {
                    tokens.RemoveAt(i);
                    i = -1;
                }
            }
        }

        protected JsonObject ParseObject(List<Token> t)
        {
            JsonObject obj = new JsonObject();
            List<JsonKeyValue> pairs = new List<JsonKeyValue>();

            //..
            // at least two chars
            if (t.Count < 2 || t[0].Type != KeyOpenBracket) throw new Exception("Missing {");
            t.RemoveAt(0); // remove {

            while (t.Count > 0/* && t[0].Type != KeyCloseBracket*/)
            {
                if (t[0].Type == KeyCloseBracket)
                {
                    //t.RemoveAt(0);
                    break;
                }

                pairs.Add(ParseKeyValue(t));

                // has more key value pairs?
                //if (t.Count == 0) throw new Exception("Expecting }");
                //if (t[0].Type == KeyCloseBracket)
                //{
                //    t.RemoveAt(0);
                //    break;
                //}
                if (t.Count > 0 && (t[0].Type != KeyComma && t[0].Type != KeyCloseBracket))
                    throw new Exception("Eexpecting (,) or (})");

                if (t[0].Type == KeyComma && (t.Count < 2 || t[1].Type == KeyCloseBracket))
                    throw new Exception("Unexpected ,");

                if (t[0].Type == KeyComma)
                    t.RemoveAt(0);
            }

            //..
            if (t.Count == 0 || t[0].Type != KeyCloseBracket) throw new Exception("Missing }");
            t.RemoveAt(0); // remove }

            // return 
            obj.Value = pairs;

            return obj;
        }

        protected JsonKeyValue ParseKeyValue(List<Token> t)
        {
            JsonKeyValue keyValue = new JsonKeyValue();

            //.. key
            if (t.Count == 0 || t[0].Type != KeyString) throw new Exception("Expecting string value");
            keyValue.Key = t[0].Value;
            t.RemoveAt(0);

            //.. :
            if (t.Count == 0 || t[0].Type != KeyColon) throw new Exception("Expecting :");
            t.RemoveAt(0);

            //.. value
            if (t.Count == 0) throw new Exception("Expecting json value");

            //.. value type
            if (t[0].Type == KeyString)
            { keyValue.Value = new JsonString() { Value = t[0].Value }; t.RemoveAt(0); }

            else if (t[0].Type == KeyNumber)
            { keyValue.Value = new JsonNumber() { Value = double.Parse(t[0].Value) }; t.RemoveAt(0); }

            else if (t[0].Type == KeyBool)
            { keyValue.Value = new JsonBool() { Value = (t[0].Value == "true" ? true : false) }; t.RemoveAt(0); }

            else if (t[0].Type == KeyNull)
            { keyValue.Value = new JsonNull(); t.RemoveAt(0); }

            else if (t[0].Type == /*KeyObject*/KeyOpenBracket)
                keyValue.Value = ParseObject(t);

            else if (t[0].Type == /*KeyArray*/KeyOpenSquBra)
                keyValue.Value = ParseArray(t);

            else
                throw new Exception("Unknown JSON value type");

            return keyValue;
        }

        protected JsonArray ParseArray(List<Token> t)
        {
            List<JsonValue> a = new List<JsonValue>();
            JsonArray ja = new JsonArray();

            //..
            if (t.Count == 0 || t[0].Type != KeyOpenSquBra) throw new Exception("Expecting [");
            t.RemoveAt(0);

            while (t.Count > 0)
            {
                if (t[0].Type == KeyCloseSquBra)
                {
                    break;
                }

                //.. value type
                if (t[0].Type == KeyString)
                { a.Add(new JsonString() { Value = t[0].Value }); t.RemoveAt(0); }

                else if (t[0].Type == KeyNumber)
                { a.Add(new JsonNumber() { Value = double.Parse(t[0].Value) }); t.RemoveAt(0); }

                else if (t[0].Type == KeyBool)
                { a.Add(new JsonBool() { Value = (t[0].Value == "true" ? true : false) }); t.RemoveAt(0); }

                else if (t[0].Type == KeyNull)
                { a.Add(new JsonNull()); t.RemoveAt(0); }

                else if (t[0].Type == /*KeyObject*/KeyOpenBracket)
                    a.Add(ParseObject(t));

                else if (t[0].Type == /*KeyArray*/KeyOpenSquBra)
                    a.Add(ParseArray(t));

                else
                    throw new Exception("Unknown JSON value type");

                //remove ,
                if (t.Count == 0) throw new Exception("Expectig ]");
                if (t[0].Type == KeyComma) t.RemoveAt(0); // remove ,
            }

            //..
            if (t.Count == 0 || t[0].Type != KeyCloseSquBra) throw new Exception("Missing ]");
            t.RemoveAt(0); // remove }

            ja.Value = a.ToArray();

            return ja;
        }

    }
}

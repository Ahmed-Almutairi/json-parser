using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser.JSONParser
{
    public class JsonKeyValue
    {
        public string Key { get; set; }
        public JsonValue Value { get; set; }
    }
    public abstract class JsonValue
    {
    }

    public class JsonNumber : JsonValue
    {
        public double Value { get; set; }
    }

    public class JsonString : JsonValue
    {
        public string Value { get; set; }
    }

    public class JsonArray : JsonValue
    {
        public JsonValue[] Value { get; set; }
    }
    public class JsonObject : JsonValue
    {
        public List<JsonKeyValue> Value { get; set; }
    }

    public class JsonBool : JsonValue
    {
        public bool Value { get; set; }
    }
    public class JsonNull : JsonValue
    {
        public object Value { get => null; }
    }
}

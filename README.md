# JSONParser

JSONParser is a .NET library for parsing json strings.

## Getting started

```C#
// 1. use json string directly

Parser parser = new Parser();
JsonObject rootJsonObject = parser.Parse("json_string");

//OR

// 2. get the tokens from the tokenizer and then use the parser to validate the json format

//.. List<Token> tokens = tokenizer.all();
Parser parser = new Parser();
JsonObject rootJsonObject = parser.Parse(tokens);
```

## Student

* Faisel Alsagri
* Ahmed Almutaire
* Riyad Algamde
* Fahad Alkhayyal
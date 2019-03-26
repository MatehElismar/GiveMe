using System;
using C = System.Console;
using System.Collections.Generic;
namespace GiveMe
{
    public static class Consts
    {
        public const string VERSION = "1.0.0";
        private static readonly List<KeyWord> s_keyWords;
        private static readonly List<Pattern> patterns;


        public static List<KeyWord> KeyWords => s_keyWords;
        public static List<Pattern> Patterns => patterns;
        public static List<Error> Errors{ get; set; }
        static Consts()
        {
            // PALABRAS RESERVADAS
                s_keyWords = new List<KeyWord>();
                // methods
                s_keyWords.Add(new KeyWord("show", KeyWordType.Method)); 

                //Operators
                s_keyWords.Add(new KeyWord("+", KeyWordType.OperationMark));//Suma
                s_keyWords.Add(new KeyWord("-", KeyWordType.OperationMark));//Resta
                s_keyWords.Add(new KeyWord("*", KeyWordType.OperationMark));//Multiplicacion
                s_keyWords.Add(new KeyWord("/", KeyWordType.OperationMark));//Division
                s_keyWords.Add(new KeyWord("=", KeyWordType.OperationMark));//Asignacion
                s_keyWords.Add(new KeyWord("==", KeyWordType.OperationMark));//Comparacion
                //Symbols 
                s_keyWords.Add(new KeyWord(";", KeyWordType.Symbol));
                s_keyWords.Add(new KeyWord("->", KeyWordType.Symbol));//Method Mark
                s_keyWords.Add(new KeyWord("\"", KeyWordType.Symbol));//Las dos comillas para identificar las cadenas
                //DataTypes
                s_keyWords.Add(new KeyWord("int", KeyWordType.Type));


            //PATRONES 
            patterns = new List<Pattern>();
            Patterns.Add(new Pattern("ID", "^[a-zA-Z][a-zA-Z0-9]*$"));
            Patterns.Add(new Pattern("NUMBER", @"^\d+$")); 
            Patterns.Add(new Pattern("LITERAL", "\"*\""));

            // ERRORS
            Errors = new List<Error>();
            Errors.Add(new Error(ErrorType.LEXICO, 001, "Invalid Expresion"));
            Errors.Add(new Error(ErrorType.LEXICO, 002, "I was waiting something else"));
        }

        public static void throwError(int line, int code)
        { 
            C.ForegroundColor = ConsoleColor.Red;
             C.WriteLine("Error at line {0} --> {1}",line,  Errors.Find(x => x.CODE == code).Description);
            C.ForegroundColor = ConsoleColor.White;

        }
    }
}
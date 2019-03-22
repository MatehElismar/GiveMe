using System;
using System.Collections.Generic;
namespace GiveMe
{
    public static class Consts
    {
        public const string VERSION = "1.0.0"; 

        public static readonly List<string> ReserverWords;
        public static readonly List<string> OperationSigns;
        public static readonly List<string> ReservedSimbols;

        public enum IDTYPES
        {
            Var,
            ReservedWord,
            Method
        }

        static Consts()
        {
            ReserverWords = new List<string>();
            ReserverWords.Add("Show");

            OperationSigns = new List<string>();
            OperationSigns.Add("+");//Suma
            OperationSigns.Add("-");//Resta
            OperationSigns.Add("*");//Multiplicacion
            OperationSigns.Add("/");//Division
            OperationSigns.Add("=");//Asignacion
            OperationSigns.Add("==");//Comparacion

            ReservedSimbols = new List<string>();
            ReservedSimbols.Add("(");
            ReservedSimbols.Add(")");
            ReservedSimbols.Add(";");
        }
    }
}
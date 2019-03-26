using System;

namespace GiveMe
{
    public enum KeyWordType
    {  
        OperationMark, Method, Type, Symbol
    }
    public class KeyWord
    {
        public KeyWordType Type{ get; set; }
        public string Lexema{ get; set; }

        public KeyWord(string Lexema, KeyWordType Type)
        {
            this.Lexema = Lexema;
            this.Type = Type;
        }

        public override string ToString()
        {
            return string.Format("{0} -> ({1})", this.Lexema, this.Type.ToString());
        }
    }
}
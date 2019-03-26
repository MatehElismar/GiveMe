using System;

namespace GiveMe
{
    public enum ErrorType { LEXICO, SINTACTICO, SEMANTICO }
    public class Error
    {
        public ErrorType Type{ get; set; }
        public int CODE{ get; set; }
        public string Description { get; set; }


        public Error(ErrorType type, int code, string desc)
        {
            this.Type = type;
            this.Description = desc;
            this.CODE = code;
        }
    }
}
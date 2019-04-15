using System;
using System.Collections.Generic;


namespace GiveMe
{
    public enum TokenType { ID, NUMBER, LITERAL, OPERATOR, SYMBOL }
    public class Token
    {
        public TokenType Type{ get; set; }
        public string Value{ get; set; }
        
        public Token(){}
        public Token(TokenType type, string value = "")
        {
            this.Type = type;
            this.Value = value;
        }

        public override string ToString()
        {
            if(Type == TokenType.ID || Type == TokenType.LITERAL)
            {
                return string.Format("({0}, {1}) ", Type.ToString(), Value);
            }
            else
            {
                return string.Format("({0})", Value);
            }

        }

        public static string GetTokenString(List<Token> tokens)
        {
            Console.WriteLine("\n\n      FLUJO DE TOKENS      ");
            Console.WriteLine("========================");

            var tokenString = "";
            foreach (var token in tokens)
            {
                if(token.Value == "END")
                {
                    tokenString+= "\n";
                    continue;
                }
                tokenString+= string.Format("{0} ", token.ToString());
            }
            return tokenString;
        }
    }
}
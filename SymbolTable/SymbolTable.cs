using System;
using System.Collections.Generic;
using C = System.Console;

namespace GiveMe
{
   
    public static class SymbolTable
    { 
        public static List<SymbolTableItem> Items{ get; set; }
        static SymbolTable()
        { 
            Items = new List<SymbolTableItem>();
        }

        new public static void ToString()
        { C.WriteLine("           TABLA DE SIMBOLOS               ");
            C.WriteLine("POS Linea       Tipo          Lexema");
            C.WriteLine("======================================");
            
            var count = -1;
            foreach (var item in Items)
            {
                count++;
                C.CursorLeft = 0;
                C.Write(count);
                C.CursorLeft = 6;
                C.Write(item.Line);
                C.CursorLeft = 11;
                C.Write(item.TokenType);
                C.CursorLeft = 30;
                C.Write(item.Lexema);
                C.CursorTop++;
            }
            C.WriteLine();
        }


        
    }
}
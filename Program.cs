using System; 
using C = System.Console;

namespace GiveMe
{
    class Program
    {
        // En esta funcion recibimos y controlamos los argumentos cuando se llama a la aplicacion. dando o no una respuesta a ellos.
        static void ArgsHandler(string[] args)
        {
            bool infoLexico, infoSintactico, infoSemantico, simbolTable;
            infoLexico = infoSintactico = infoSemantico = simbolTable = false;
            // En caso de que se invoque sin argumento alguno
            if(args.Length == 0)
            {
                C.WriteLine("GiveMe Compilator {0} is working well!!", Consts.VERSION);
                return;
            }


            // Instanciamos un objeto Reader.
            var lexico = new Lexico();
            foreach (var arg in args)
            {
                switch (arg.ToLower())
                {
                    case "--version": C.WriteLine(Consts.VERSION); return; 
                    case "--symbol-table": simbolTable = true; continue; 
                    case "--lexico": infoLexico = true; break; 
                    case "--sintactico": infoSintactico = true; break; 
                    case "--semantico": infoSemantico = true; break; 
                    default: lexico.File = arg; break;
                }    
                
                // if(infoLexico || infoSintactico || infoSemantico) break; 
            }

            // Luego de haber escogido la configuracion deseada por el usuario a traves de los parametros leemos el archivo.
            // if(!lexico && !sintactico && !semantico)
            lexico.Read(); 
            lexico.DeleteSpacesAndComments(); 
            var tokenTree = lexico.GenerateTokenTree(); 

            if(simbolTable)  SymbolTable.ToString();
            if(infoLexico) C.WriteLine("\n\n" + Token.GetTokenString(tokenTree));

            // var sintactico = new Sintactico(tokenTree);
            if(infoSintactico) C.WriteLine("sintactico");

            // var Semantico = new Semantico(tokenTree);
            if(infoSemantico) C.WriteLine("semantico");
        }
        static void Main(string[] args)
        { 

            // Trabajamos los argumentos recibidos
            ArgsHandler(args);

            
            // llAMAMOS AL ANALIZADOR LEXICO  Y LE PASAMOS EL PRIMER PARAMETRO QUE VENGA DE ENTRADA!
            
        }
    }
}
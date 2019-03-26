using System; 
using C = System.Console;

namespace GiveMe
{
    class Program
    {
        // En esta funcion recibimos y controlamos los argumentos cuando se llama a la aplicacion. dando o no una respuesta a ellos.
        static void ArgsHandler(string[] args)
        {
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
                    default: lexico.File = arg; break;
                }    
            }

            // Luego de haber escogido la configuracion deseada por el usuario a traves de los parametros leemos el archivo.
            lexico.Read();
            // lexico.ShowProcessedCode();
            lexico.DeleteSpacesAndComments();
            // lexico.ShowProcessedCode();
            lexico.GenerateTokenTree();
            // generateToken();
                // lexico.matchWord)();
                // lexico.addToSymbolTable();
                // lexico.getToken();
        }
        static void Main(string[] args)
        { 

            // Trabajamos los argumentos recibidos
            ArgsHandler(args);

            
            // llAMAMOS AL ANALIZADOR LEXICO  Y LE PASAMOS EL PRIMER PARAMETRO QUE VENGA DE ENTRADA!
            
        }
    }
}
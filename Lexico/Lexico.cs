using System;
using System.IO;
using C = System.Console;

namespace Lexico
{
    public class Reader
    {

    //PROPERTIES
        // Archivo que se leera!
        public string File { get; set; }

    //CONSTRUCTORS
        public Reader(){}
        public Reader(string file)
        {
            this.File = file;

        }
       
    //INSTANCE METHODS
        public void Read()
        {  
            if(System.IO.File.Exists(this.File))
            {
                using (var source = new StreamReader(this.File))
                { 
                    C.WriteLine("reading file {0}", this.File); 
                    
                }
            }
            else C.WriteLine("No such file or directory\nfatal error: no input files\ncompilation terminated");
        }

    //STATIC METHODS
        // Version Estatica el metodo Read()
        public static void Read(string file)
        {
            C.WriteLine("reading file {0}", file);
        }
    }
}

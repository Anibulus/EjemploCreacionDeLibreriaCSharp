using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace CreacionDeLibrerias
{
    class Program
    {
        static void Main(string[] args)
        {
            //Consigue una lista de los archivos de la carpeta determinada
            FileHelper fh = new FileHelper();
            var respuesta = fh.getFilesSystemObject("../../../");
            foreach (var item in respuesta) 
            {
                Console.WriteLine($"Name: {item.name} - Tipo {item.FileType}");
            }
            Console.ReadLine();


            /**/
            //Si el archivo no existe, que lo haga por si mismo
            var file = new FileStream("./MiArchiv.bin", FileMode.OpenOrCreate);
            WriteLine("Antes de procesar");
            string variable = "alaverga";
            WriteLine($"A esto se le llama interpolacion de cadenas {variable}");
            ProcesarArchivoAsync(file);
            file.Close();
            WriteLine("Después de procesar");
            ReadLine();

            //usar codigo de esta manera ASERGURA que el espacio sea liberado
            using (FileStream file2 = File.Open("./FileNo.txt", FileMode.OpenOrCreate))
            {
                WriteLine("Pero solo sirve en algunos casos");
            }
        }

        /// <summary>
        /// Escribe dentro del archivo una cadena ty para ello
        /// convierte antes la cadena en un array de bytes
        /// el cual se controla de manera asincrona.
        /// Se recomienda tener en el nombre Async por estandar
        /// 
        /// Siempre que se usa async se debe colocar await
        /// </summary>
        /// <param name="file"></param>
        private static async void ProcesarArchivoAsync(FileStream file)
        {
            string msg = "Hola mundo";
            byte[] escrito = Encoding.UTF8.GetBytes(msg);
            WriteLine("Escribiendo..");
            for (int i = 0; i < 100000; i++)
            {
                await file.WriteAsync(escrito, 0, escrito.Length);
            }
            WriteLine("Ya escribio");
        }
    }//Fin de la clase
}

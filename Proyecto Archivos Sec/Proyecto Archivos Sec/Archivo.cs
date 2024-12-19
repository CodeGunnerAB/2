using System;                      // Importa funciones básicas de .NET
using System.Collections.Generic;  // Importa funcionalidades de listas y colecciones
using System.Linq;                 // Permite realizar consultas con LINQ
using System.Text;                 // Permite manipular cadenas de texto
using System.Threading.Tasks;      // Permite el uso de tareas asíncronas
using System.IO;                   // Importa clases para trabajar con archivos


namespace Proyecto_Archivos_Sec
{
    class Archivo
    {
        // Declaración de variables miembro
        string narch;           // Almacena el nombre del archivo.
        FileStream stream;      // Permite manejar la secuencia del archivo.
        BinaryWriter writer1;   // Escribe datos en el archivo en formato binario.
        BinaryReader reader1;   // Lee datos del archivo en formato binario.

        // Constructor de la clase ----------------------------------------------------------
        public Archivo()
        {
            narch = ""; // Inicializa el nombre del archivo como una cadena vacía.
        }

        //------------------------------------------------------------------------------------

        // Método para abrir un archivo para escritura (grabación) 
        public void Abrir_Grab(string narch1)
        {
            narch = narch1; // Asigna el nombre del archivo.
            // Abre el archivo con permisos de creación y escritura.
            stream = new FileStream(narch, FileMode.CreateNew, FileAccess.Write);
            // Inicializa el escritor binario para escribir en el archivo.
            writer1 = new BinaryWriter(stream);
        }

        // Método para grabar un número entero en el archivo.
        public void Grabar(int n)
        {
            writer1.Write(n); // Escribe el número entero en el archivo.
        }

        // Método para grabar una cadena en el archivo.
        //public void GrabarCadena(string cad)
        //{
        //    writer1.Write(cad); // Escribe la cadena en el archivo.
        //}

        // Método para cerrar el archivo después de grabar.
        public void Cerrar_Grab()
        {
            writer1.Close(); // Cierra el escritor binario.
            stream.Close();  // Cierra la secuencia del archivo.
        }

        //------------------------------------------------------------------------------------
        // Método para abrir un archivo para lectura.
        public void Abrir_Leer(string narch1)
        {
            narch = narch1; // Asigna el nombre del archivo.
            // Abre el archivo con permisos de solo lectura.
            stream = new FileStream(narch, FileMode.Open, FileAccess.Read);
            // Inicializa el lector binario para leer datos del archivo.
            reader1 = new BinaryReader(stream);
        }

        // Método para leer un número entero del archivo.
        public int leer()
        {
            int n; // Variable para almacenar el número leído.
            n = reader1.ReadInt32(); // Lee un entero de 32 bits.
            return n; // Retorna el número leído.
        }

        // Método para leer una cadena del archivo.
        //public string leerCadena()
        //{
        //    string cad; // Variable para almacenar la cadena leída.
        //    cad = reader1.ReadString(); // Lee una cadena del archivo.
        //    return cad; // Retorna la cadena leída.
        //}

        // Método para cerrar el archivo después de leer.
        public void Cerrar_Leer()
        {
            reader1.Close(); // Cierra el lector binario.
            stream.Close();  // Cierra la secuencia del archivo.
        }

        //------------------------------------------------------------------------------------

        // Método para verificar si se llegó al final del archivo.
        public bool Verif_Fin()
        {
            // Compara la posición actual con la longitud total del archivo.
            return stream.Position == stream.Length;
        }

        //------------------------------------------------------------------------------------

        // Ejercicio 1: Seleccionar elementos primos de un archivo.
        public void Ejer1(string narch1, string narch2, Archivo a2)
        {
            entero na = new entero(); // Crea una instancia de la clase entero.
            Abrir_Leer(narch1);       // Abre el archivo para lectura.
            a2.Abrir_Grab(narch2);    // Abre el segundo archivo para grabación.

            // Itera mientras no se haya llegado al final del archivo.
            while (!Verif_Fin())
            {
                na.cargar(leer()); // Carga un número entero desde el archivo.
                if (na.VerifPri()) // Verifica si el número es primo.
                    a2.Grabar(na.descargar()); // Graba el número primo en el segundo archivo.
            }

            Cerrar_Leer();    // Cierra el archivo de lectura.
            a2.Cerrar_Grab(); // Cierra el archivo de grabación.
        }



        // Ejercicio 2: Verificar si los datos del archivo están ordenados con rigor (Parámetro rigor).
        public bool Ejer2(string narch1, int rigor)
        {
            Abrir_Leer(narch1); // Abre el archivo para lectura.
            int t; // Almacena el valor inicial.
            int i = rigor; // Incremento para verificar el orden.
            bool b = true; // Bandera para determinar si está ordenado.

            t = leer(); // Lee el primer valor del archivo.

            // Itera mientras no llegue al final del archivo y la bandera sea verdadera.
            while (!Verif_Fin() && b == true)
            {
                if (t + i != leer()) // Comprueba si el siguiente valor mantiene el rigor.
                {
                    b = false; // Si no cumple, cambia la bandera a falso.
                }
                i = i + rigor; // Incrementa el paso.
            }

            Cerrar_Leer(); // Cierra el archivo.
            return b;      // Retorna si los datos están ordenados o no.
        }

        // Ejercicio 3: Unir dos archivos ordenados en un tercer archivo.
        public void Ejer3(string narch1, string narch2, string narch3, Archivo a2, Archivo a3)
        {
            // Abre el primer archivo para lectura.
            Abrir_Leer(narch1);
            // Abre el segundo archivo para lectura.
            a2.Abrir_Leer(narch2);
            // Abre el tercer archivo para grabación.
            a3.Abrir_Grab(narch3);

            // Instancia para manejar valores del primer archivo.
            entero na1 = new entero();
            // Instancia para manejar valores del segundo archivo.
            entero na2 = new entero();

            // Variables auxiliares para almacenar los valores actuales de cada archivo.
            int i = 0, j = 0;
            // Banderas para verificar si hay más datos por leer en cada archivo.
            bool b1 = true, b2 = true;

            // Lee el primer valor del primer archivo.
            if (!Verif_Fin())
            {
                na1.cargar(leer()); // Carga el valor del archivo en la variable 'na1'.
                i = na1.descargar(); // Descarga el valor de 'na1' en la variable 'i'.
            }
            else
            {
                b1 = false; // Si no hay más datos, desactiva la bandera 'b1'.
            }

            // Lee el primer valor del segundo archivo.
            if (!a2.Verif_Fin())
            {
                na2.cargar(a2.leer()); // Carga el valor del archivo en la variable 'na2'.
                j = na2.descargar(); // Descarga el valor de 'na2' en la variable 'j'.
            }
            else
            {
                b2 = false; // Si no hay más datos, desactiva la bandera 'b2'.
            }

            // Combina ambos archivos ordenadamente.
            while (b1 || b2) // Mientras haya datos en al menos uno de los archivos.
            {
                if (b1 && (!b2 || i <= j)) // Verifica si el valor de 'i' debe ser grabado primero.
                {
                    a3.Grabar(i); // Graba el valor de 'i' en el tercer archivo.
                    if (!Verif_Fin())
                    {
                        na1.cargar(leer()); // Carga el siguiente valor en 'na1'.
                        i = na1.descargar(); // Descarga el valor de 'na1' en la variable 'i'.
                    }
                    else
                    {
                        b1 = false; // Si no hay más datos, desactiva la bandera 'b1'.
                    }
                }
                else if (b2) // Si no se graba desde el archivo 1, se graba desde el archivo 2.
                {
                    a3.Grabar(j); // Graba el valor de 'j' en el tercer archivo.
                    if (!a2.Verif_Fin())
                    {
                        na2.cargar(a2.leer()); // Carga el siguiente valor en 'na2'.
                        j = na2.descargar(); // Descarga el valor de 'na2' en la variable 'j'.
                    }
                    else
                    {
                        b2 = false; // Si no hay más datos, desactiva la bandera 'b2'.
                    }
                }
            }

            // Cierra todos los archivos.
            Cerrar_Leer(); // Cierra el primer archivo.
            a2.Cerrar_Leer(); // Cierra el segundo archivo.
            a3.Cerrar_Grab(); // Cierra el tercer archivo donde se grabó la fusión.
        }

     

        //Ejercicio 6 repechaje SB

        // Método para purar un archivo ordenado
        public void PurarArchivo(string narch1, string narch2, Archivo a2)
        {
            // Abre los archivos para lectura y grabación.
            Abrir_Leer(narch1);      // Archivo 1 (entrada)
            a2.Abrir_Grab(narch2);   // Archivo 2 (salida purada)

            // Instancias para manejar valores de los archivos.
            entero na1 = new entero();

            // Variables auxiliares para almacenar valores actuales.
            int i = 0;
            bool b1 = true; // Bandera para verificar si hay más datos por leer.

            // Leer el primer valor del archivo.
            if (!Verif_Fin()) { na1.cargar(leer()); i = na1.descargar(); } else { b1 = false; }

            // Proceso para purar los elementos.
            while (b1)
            {
                a2.Grabar(i); // Graba el primer valor o el último único que se haya encontrado.

                // Lee el siguiente valor, pero solo graba si es diferente al anterior.
                do
                {
                    if (!Verif_Fin()) { na1.cargar(leer()); } else { b1 = false; break; }
                } while (na1.descargar() == i); // Salta los valores duplicados.

                i = na1.descargar(); // Actualiza el valor actual para el próximo ciclo.
            }

            // Cierra todos los archivos.
            Cerrar_Leer();
            a2.Cerrar_Grab();
        }


    }
}

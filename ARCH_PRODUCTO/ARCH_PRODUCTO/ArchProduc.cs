﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ARCH_PRODUCTO
{
    class ArchProduc
    {
        private string Narch;
        private FileStream stream;
        private BinaryWriter writer1;
        private BinaryReader reader1;

        int cod;
        string desc;
        char tipo;
        byte conti;
        double cant;
        double costo;
        bool est;

        public ArchProduc()
        {
            Narch = "";
        }

        public void Abrir_Grabar(string Narch1)
        {
            Narch = Narch1;
            stream = new FileStream(Narch, FileMode.CreateNew, FileAccess.Write);
            writer1 = new BinaryWriter(stream);

        }

        // Abrir para leer
        public void Abrir_Leer(string Narch1) // abrir para leer
        {
            Narch = Narch1;
            stream = new FileStream(Narch, FileMode.Open, FileAccess.Read);
            reader1 = new BinaryReader(stream);
        }

        // Abrir para dar de Baja
        public void Abrir_Bajas(string Narch1)
        {
            Narch = Narch1;
            stream = new FileStream(Narch, FileMode.Open, FileAccess.ReadWrite);
            reader1 = new BinaryReader(stream);
            writer1 = new BinaryWriter(stream);
        }

        //abrir modificar
        public void Abrir_m(string Narch1)
        {
            Narch = Narch1;
            stream = new FileStream(Narch, FileMode.Open, FileAccess.ReadWrite);
            reader1 = new BinaryReader(stream);
            writer1 = new BinaryWriter(stream);
        }
        //Abrir para Adicionar
        public void Abrir_Adicionar(string Narch1)
        {
            Narch = Narch1;
            stream = new FileStream(Narch, FileMode.Append, FileAccess.Write);
            writer1 = new BinaryWriter(stream);

        }

        //????
        public void Abrir_OpRandom(string Narch1)
        {
            Narch = Narch1;
            stream = new FileStream(Narch, FileMode.Open, FileAccess.ReadWrite);
            reader1 = new BinaryReader(stream);
            writer1 = new BinaryWriter(stream);
            

        }
        public void Grabar(int cod, string desc, char tipo, byte conti, double cant, double costo, bool est)
        {
            //bool est = true;
            desc = desc.PadRight(26, ' ').Substring(0, 26);
            writer1.Write(cod);
            writer1.Write(desc);
            writer1.Write(tipo);
            writer1.Write(conti);
            writer1.Write(cant);
            writer1.Write(costo);
            writer1.Write(est);
        }
        public void GrabarR(int cod, string desc, char tipo, byte conti, double cant, double costo, bool est, int nr)
        {
            nr = (nr - 1) * 50;
            stream.Seek(nr, SeekOrigin.Begin);
            desc = desc.PadRight(26, ' ').Substring(0, 26);
            writer1.Write(cod);
            writer1.Write(desc);
            writer1.Write(tipo);
            writer1.Write(conti);
            writer1.Write(cant);
            writer1.Write(costo);
            writer1.Write(est);
        }
        //Cerrar Grabacion
        public void Cerrar_Grabar()
        {
            writer1.Close();
            stream.Close();
        }
        // Leer
        public void Leer(ref int cod, ref string desc, ref char tipo, ref byte conti, ref double cant, ref double costo, ref bool est)
        {
            cod = reader1.ReadInt32();
            desc = reader1.ReadString();
            tipo = reader1.ReadChar();
            conti = reader1.ReadByte();
            cant = reader1.ReadDouble();
            costo = reader1.ReadDouble();
            est = reader1.ReadBoolean();

        }
        public void LeerR(ref int cod, ref string desc, ref char tipo, ref byte conti, ref double cant, ref double costo, ref bool est, int nr)
        {
            nr = (nr - 1) * 50;
            stream.Seek(nr, SeekOrigin.Begin);
            cod = reader1.ReadInt32();
            desc = reader1.ReadString();
            tipo = reader1.ReadChar();
            conti = reader1.ReadByte();
            cant = reader1.ReadDouble();
            costo = reader1.ReadDouble();
            est = reader1.ReadBoolean();

        }
        // Cerrar
        public void Cerrar_Leer()
        {
            reader1.Close();
            stream.Close();
        }
        public void Cerrar_Bajas()
        {
            stream.Position = stream.Length;
            reader1.Close();
            writer1.Close();
            stream.Close();
        }
        // Verificar Fin
        public bool Verif_Fin()
        {
            return stream.Position == stream.Length;
        }
        public int Nreg()
        {
            return (int)stream.Length / 50;
        }

 
        public void Cerrar_OpRan()
        {
            stream.Position = stream.Length;
            reader1.Close();
            writer1.Close();
            stream.Close();
        }

        ///  OPERACIONES
        ///  1.  
        public void Seleccionar_productos_con_tipo(char tipo1, string Narch1, string Narch2, ArchProduc a2)
        {
            this.Abrir_Leer(Narch1);
            a2.Abrir_Grabar(Narch2);


            while (!Verif_Fin())
            {
                this.Leer(ref cod, ref desc, ref tipo, ref conti, ref cant, ref costo, ref est);
                
                if (est == true & (tipo == tipo1))
                {
                    a2.Grabar(cod, desc, tipo, conti, cant, costo, est);
                }
            }

            this.Cerrar_Leer();
            a2.Cerrar_Grabar();
        }

        ///  2.  
        public double Calcular_el_costo_total_de_productos(string Narch1)
        {
            double costoTotal = 0;
            this.Abrir_Leer(Narch1);
            while (!Verif_Fin())
            {
                this.Leer(ref cod, ref desc, ref tipo, ref conti, ref cant, ref costo, ref est);

                if (est == true)
                {
                    costoTotal = costoTotal + (costo * cant);
                }
            }
            this.Cerrar_Leer();
            return costoTotal;
        }
        ///  3. 
        public void OrdContinente(string narch1, ArchProduc p2, string narch2)
        {
            Tabla t1 = new Tabla();
            int i = 0;
            Reg r1;
            r1.nr = 0;
            r1.dato = 0;  // agregado
            r1.cad = "";
            Abrir_Leer(narch1);
            while (!Verif_Fin())
            {
                i++;
                Leer(ref cod, ref desc, ref tipo, ref conti, ref cant, ref costo, ref est);
                if (est == true)
                {
                    r1.nr = i;
                    r1.dato = conti;
                    t1.Cargar(r1);
                }
            }
            Cerrar_Leer();
            t1.Ord();
            Abrir_OpRandom(narch1);
            p2.Abrir_Grabar(narch2);
            for(i=1; i <= t1.RetDim(); i++)
            {
                t1.RetReg(i, ref r1);
                LeerR(ref cod, ref desc, ref tipo, ref conti, ref cant, ref costo, ref est, r1.nr);
                p2.Grabar(cod, desc,  tipo,  conti, cant, costo, est);
            }
            Cerrar_OpRan();
            p2.Cerrar_Grabar();
        }


  
    

        /// -------------------------------------------------------------------------------------------
      

       

        //EJERCICIO 7 REPECHAJE SB

        // Seleccionar registros por un tipo específico y ordenarlos ascendentemente por descripción
        public void SeleccionarPorTipo_OrdAsc(string narch1, string narch2, char tipo1, ArchProduc a2)
        {
           
            Tabla t1 = new Tabla();
            int i = 0;
            Reg r1;
            r1.nr = 0;
            r1.dato = 0;
            r1.cad = ""; 

          
            Abrir_Leer(narch1);
            a2.Abrir_Grabar(narch2);

          
            while (!Verif_Fin())
            {
                i++;
                Leer(ref cod, ref desc, ref tipo, ref conti, ref cant, ref costo, ref est);

                if (tipo == tipo1 && est == true) 
                {
                    
                    r1.nr = i;
                    r1.cad = desc;
                    t1.Cargar(r1);
                }
            }

         
            Cerrar_Leer();

      
            t1.OrdPorCad();
            Abrir_OpRandom(narch1);

      
            for (i = 1; i <= t1.RetDim(); i++)
            {
                t1.RetReg(i, ref r1);
                LeerR(ref cod, ref desc, ref tipo, ref conti, ref cant, ref costo, ref est, r1.nr);
                a2.Grabar(cod, desc, tipo, conti, cant, costo, est);
            }

            Cerrar_OpRan();
            a2.Cerrar_Grabar();
        }


    }
}

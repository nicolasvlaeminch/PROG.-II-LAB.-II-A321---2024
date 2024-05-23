using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace Entidades
{
    public class Shopping
    {
        // Atributos privados
        private int _capacidadMaxima;
        private List<Comercio> _comercios;


        // Propiedades
        public int CapacidadMaxima
        {
            get { return _capacidadMaxima; }
            set { _capacidadMaxima = value; }
        }
        public List<Comercio> Comercios
        {
            get { return _comercios; }
            set { _comercios = value; }
        }

        public double PrecioDeExportadores
        {
            get { return ObtenerPrecio(EComercios.Exportador); }
        }

        public double PrecioDeImportadores
        {
            get { return ObtenerPrecio(EComercios.Importador); }
        }

        public double PrecioTotal
        {
            get { return ObtenerPrecio(EComercios.Ambos); }
        }

        // Constructor privado por defecto
        private Shopping()
        {
            _comercios = new List<Comercio>();
        }

        // Constructor privado sobrecargado
        private Shopping(int capacidadMaxima) : this()
        {
            this._capacidadMaxima = capacidadMaxima;
        }

        // Método público de clase Mostrar
        public static string Mostrar(Shopping shopping)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("************************************************");
            stringBuilder.AppendLine($"Capacidad del Shopping: ${shopping.CapacidadMaxima}");
            stringBuilder.AppendLine($"Total por Importadores: ${shopping.PrecioDeImportadores}");
            stringBuilder.AppendLine($"Total por Exportadores: ${shopping.PrecioDeExportadores}");
            stringBuilder.AppendLine($"Total por Exportadores: ${shopping.PrecioTotal}");
            stringBuilder.AppendLine("************************************************");

            if (shopping.Comercios.Count > 0)
            {
                stringBuilder.AppendLine("Listado de Comercios:");
                stringBuilder.AppendLine("************************************************");
                foreach (Comercio comercio in shopping.Comercios)
                {
                    stringBuilder.AppendLine((string)comercio);
                }
            }

            return stringBuilder.ToString();
        }

        // Sobrecarga de operador implícito para retornar una instancia de Shopping con la capacidad especificada
        public static implicit operator Shopping(int capacidadMaxima)
        {
            return new Shopping(capacidadMaxima);
        }

        // Sobrecarga de operador de igualdad para verificar si un comercio ya se encuentra en el shopping
        public static bool operator ==(Shopping shopping, Comercio comercio)
        {
            return shopping.Comercios.Contains(comercio);
        }

        public static bool operator !=(Shopping shopping, Comercio comercio)
        {
            return !(shopping == comercio);
        }

        // Sobrecarga de operador de adición para agregar un comercio al shopping si hay capacidad disponible y el comercio no está presente
        public static Shopping operator +(Shopping shopping, Comercio comercio)
        {
            if (shopping.Comercios.Count >= shopping.CapacidadMaxima)
            {
                Console.WriteLine("No hay mas lugar en el shopping!!!.");
            }
            else if (shopping == comercio)
            {
                Console.WriteLine("El comercio ya esta en el shopping.");
            }
            else
            {
                shopping.Comercios.Add(comercio);
            }

            return shopping;

        }

        // Meétodo privado y de instancia ObtenerPrecio, retornará el valor (en concepto de alquileres) del shopping de acuerdo con el enumerado que recibe como parámetro
        private double ObtenerPrecio(EComercios tipoComercio)
        {
            double total = 0;

            foreach (Comercio comercio in _comercios)
            {
                switch (tipoComercio)
                {
                    case EComercios.Importador:
                        if (comercio is Importador)
                        {
                            total += comercio.PrecioAlquiler;
                        }
                        break;
                    case EComercios.Exportador:
                        if (comercio is Exportador)
                        {
                            total += comercio.PrecioAlquiler;
                        }
                        break;
                    case EComercios.Ambos:
                        total += comercio.PrecioAlquiler;
                        break;
                    default:
                        throw new ArgumentException("Tipo de comercio no valido.");
                }
            }

            return total;
        }

        // Método estático para guardar la información del shopping y sus comercios en un archivo de texto
        public void GuardarShopping(string rutaArchivo)
        {
            string contenido = Mostrar(this);

            File.WriteAllText(rutaArchivo, contenido);
        }

        // Método estático para serializar y guardar la información del shopping y sus comercios en un archivo XML
        public void SerializarShopping(string rutaArchivo)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Shopping));
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                serializer.Serialize(writer, new Shopping());
            }
        }

        // Método estático para deserializar y leer el archivo XML con la información del shopping y sus comercios
        public static Shopping DeserializarShopping(string rutaArchivo)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Shopping));
            using (StreamReader reader = new StreamReader(rutaArchivo))
            {
                return (Shopping)serializer.Deserialize(reader);
            }
        }

    }
}

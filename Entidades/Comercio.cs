using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Comercio
    {
        protected int _cantidadDeEmpleados;
        protected string _comerciante;
        protected static Random _generadorDeEmpleados = new Random();
        protected string _nombre;
        protected float _precioAlquiler;

        // Constructor de clase
        static Comercio()
        {
            _generadorDeEmpleados = new Random();
        }

        // Constructor vacío
        public Comercio()
        {

        }

        // Constructor sobrecargado
        public Comercio(float precioAlquiler, string nombreComercio, string nombre, string apellido) : this(nombreComercio, new Comerciante(nombre, apellido), precioAlquiler)
        {
        }

        // Constructor sobrecargado
        public Comercio(string nombre, Comerciante comerciante, float precioAlquiler)
        {
            this._nombre = nombre;
            this._comerciante = comerciante; // Aquí se invoca el operador de conversión implícito
            this._precioAlquiler = precioAlquiler;
        }

        // Propiedad CantidadDeEmpleados
        public int CantidadDeEmpleados
        {
            get
            {
                if (_cantidadDeEmpleados == 0)
                {
                    _cantidadDeEmpleados = _generadorDeEmpleados.Next(1, 101);
                }
                return _cantidadDeEmpleados;
            }

            set { _cantidadDeEmpleados = value; }
        }

        // Propiedades públicas de lectura y escritura
        public string Comerciante
        {
            get { return _comerciante; }
            set { _comerciante = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public float PrecioAlquiler
        {
            get { return _precioAlquiler; }
            set { _precioAlquiler = value; }
        }

        // Método privado de instancia Mostrar
        private string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Nombre: {Nombre}");
            stringBuilder.AppendLine($"Comerciante: {Comerciante}");
            stringBuilder.AppendLine($"Cantidad de empleados: {CantidadDeEmpleados}");
            stringBuilder.AppendLine($"Precio Alquiler: {PrecioAlquiler}");

            return stringBuilder.ToString();
        }

        public static bool operator ==(Comercio c1, Comercio c2)
        {
            return c1.Nombre == c2.Nombre && c1._comerciante == c2._comerciante;
        }

        public static bool operator !=(Comercio c1, Comercio c2)
        {
            return !(c1 == c2);
        }

        public static explicit operator string(Comercio comercio)
        {
            return comercio.Mostrar();
        }

        public override bool Equals(object obj)
        {
            return obj is Comercio comercio && comercio == this;
        }

    }
}

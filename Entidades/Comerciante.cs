using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comerciante
    {
        // Atributos privados
        private string _nombre;
        private string _apellido;

        // Propiedades públicas
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        // Constructor vacío
        public Comerciante()
        {
        }

        // Constructor que inicializa los atributos
        public Comerciante(string nombre, string apellido)
        {
            _nombre = nombre;
            _apellido = apellido;
        }

        public static bool operator ==(Comerciante c1, Comerciante c2)
        {
            return c1.Nombre == c2.Nombre && c1.Apellido == c2.Apellido;
        }

        public static bool operator !=(Comerciante c1, Comerciante c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            return obj is Comerciante comerciante && comerciante == this;
        }

        public static implicit operator string(Comerciante comerciante)
        {
            return $"{comerciante.Nombre}, {comerciante.Apellido}";
        }
    }
}

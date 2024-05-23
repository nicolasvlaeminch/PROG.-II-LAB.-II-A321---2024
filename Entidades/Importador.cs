using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Importador : Comercio
    {
        // Atributo propio
        private EPaises _pais;

        // Constructor vacío
        public Importador()
        {
        }

        // Constructor que inicializa el atributo _pais
        public Importador(string nombreComercio, float precioAlquiler, Comerciante comerciante, EPaises paisOrigen) : base(nombreComercio, comerciante, precioAlquiler)
        {
            _pais = paisOrigen;
        }

        public string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine((string)this);
            stringBuilder.AppendLine($"Pais: {_pais}");

            return stringBuilder.ToString();
        }

        // Operador de igualdad sobrecargado
        public static bool operator ==(Importador i1, Importador i2)
        {
            return i1.Nombre == i2.Nombre && i1._pais == i2._pais;
        }

        public static bool operator !=(Importador i1, Importador i2)
        {
            return !(i1 == i2);
        }

        // Operador de conversión implícita
        public static implicit operator EPaises(Importador importador)
        {
            return importador._pais;
        }

    }
}
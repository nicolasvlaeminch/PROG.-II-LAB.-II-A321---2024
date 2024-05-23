using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Exportador : Comercio
    {
        private ETipoProducto _tipo;

        // Constructor vacío
        public Exportador()
        {
        }

        // Constructor que inicializa el atributo _tipo
        public Exportador(string nombreComercio, float precioAlquiler, Comerciante comerciante, ETipoProducto tipo) : base(nombreComercio, comerciante, precioAlquiler)
        {
            _tipo = tipo;
        }

        // Método público de instancia Mostrar
        public string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine((string)this);
            stringBuilder.AppendLine($"Tipo: {_tipo}");

            return stringBuilder.ToString();
        }

        // Operador de igualdad sobrecargado
        public static bool operator ==(Exportador e1, Exportador e2)
        {
            return e1.Nombre == e2.Nombre && e1._tipo == e2._tipo;
        }

        public static bool operator !=(Exportador e1, Exportador e2)
        {
            return !(e1 == e2);
        }

        // Operador de conversión implícita
        public static implicit operator ETipoProducto(Exportador exportador)
        {
            return exportador._tipo;
        }

    }
}

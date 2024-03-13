using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R25_V2
{

    public enum TipoUnidadVenta : byte {Botella, Caja3, Caja6, Caja12}

    public class Bebida : Producto
    {

        // CONSTANTES

        private const string NOMBRE_DEF = "Fino Baena";
        private const string DENOMINACION_DEF = "Montilla Moriles";
        private const TipoUnidadVenta TIPO_DEF = TipoUnidadVenta.Botella;
        private const int CANTIDAD_DEF = 0;




        // MIEMBROS

        private string _denominacionOrigen;
        private TipoUnidadVenta _tipoUnidadesVenta;
        private int _cantidad;

        // CONSTRUCTORES

        public Bebida() : base()
        {
            _nombre = NOMBRE_DEF;
            _denominacionOrigen = DENOMINACION_DEF;
            _tipoUnidadesVenta = TIPO_DEF;   
            _cantidad = CANTIDAD_DEF;
        }

        public Bebida(string name, float precio, string denomination) : this() 
        {
            Nombre = name;
            PrecioBase = precio;
            DenominacionOrigen = denomination;
        }

        // PROPIEDADES

        public string DenominacionOrigen
        {
            get
            {
                return _denominacionOrigen;
            }
            set
            {
                _denominacionOrigen = ValidarCadena(value);
            }
        }

        public TipoUnidadVenta TipoUnidadesVenta
        {
            get
            {
                return _tipoUnidadesVenta;
            }
        }

        public int Cantidad
        {
            get
            {
                return _cantidad;
            }
            set
            {
                ValidarNumero(value);
                _cantidad = value;
            }
        }

        public override string ToString()
        {
            string cadena = "";

            cadena = $"Nombre: ({Nombre}{DenominacionOrigen})\n";
            cadena += $"{PrecioBase} Euros/Botella\n{CalculoIVA} Euros/Botella + IVA\nCantidad: {Cantidad}\n";
            cadena += $"{PrecioCantidad} Euros\n{PrecioCantidadIVA} Euros + IVA";


            return cadena;
        }

        // MÉTODOS

        protected override float calculoIVA()
        {
            return PrecioBase * 1.21f;
        }

        protected override float precioCantidad()
        {
            return PrecioBase * Cantidad;
        }

        protected override float precioCantidadIva()
        {
            return CalculoIVA * Cantidad;
        }
    }
}

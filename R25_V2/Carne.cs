using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R25_V2
{

    public enum TipoUnidad : byte {Kg, Bandeja}

    public class Carne : Producto
    {
        // CONSTANTES

        private const string NOMBRE_DEF = "Pollo";
        private const string Parte_DEF = "Filetes Pechuga";
        private const TipoUnidad UNIDAD_DEF = TipoUnidad.Kg;
        private const byte CANTIDAD_DEF = 0;



        // MIEMBROS

        private TipoUnidad _tipoUnidades;

        private string _parteAnimal;

        private float _cantidad;

        // CONSTRUCTORES

        public Carne() : base()
        {
            _nombre = NOMBRE_DEF;
            _parteAnimal = Parte_DEF;
            _tipoUnidades = UNIDAD_DEF;
            _cantidad = CANTIDAD_DEF;
        }

        public Carne(string name, float price, string part) : this() 
        {   
            Nombre = name;  
            PrecioBase = price;
            ParteAnimal = part;
        }

        // PROPIEDADES

        public TipoUnidad TipoUnidades
        {
            get
            {
                return _tipoUnidades;
            }
        }

        public string ParteAnimal
        {
            get
            {
                return _parteAnimal;
            }
            set
            {
                _parteAnimal = ValidarCadena(value);
            }
        }

        public float Cantidad
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


        // MÉTODOS

        public override string ToString()
        {
            string cadena = "";

            cadena = $"Nombre: ({Nombre}{ParteAnimal})\n";
            cadena += $"{PrecioBase} Euros/Kg\n{CalculoIVA} Euros/Kg + IVA\nCantidad: {Cantidad}\n";
            cadena += $"{PrecioCantidad} Euros\n{PrecioCantidadIVA} Euros + IVA";


            return cadena;
        }

        // PRECIOS

        protected override float precioCantidad()
        {
            return PrecioBase * Cantidad;
        }

        protected override float precioCantidadIva()
        {
            return CalculoIVA * Cantidad;
        }

        protected override float calculoIVA()
        {
            return PrecioBase * 1.10f;
        }



    }
}

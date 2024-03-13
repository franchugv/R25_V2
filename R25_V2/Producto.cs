namespace R25_V2
{
    public abstract class Producto
    {
        // CONSTANTES

        private const string NAME_DEF = "ne";
        private const float PRICE_DEF = -1f;
        private const byte MIN_NUM = 0;


        // MIEMBROS

        protected string _nombre;
        protected float _precioBase;

        // CONSTRUCTORES

        public Producto()
        {
            _nombre = NAME_DEF;
            _precioBase = PRICE_DEF;
        }

        public Producto(string name, float price)
        {
            Nombre = name;
            PrecioBase = price;
        }

        // PROPIEDADES

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = ValidarNombre(value);
            }
        }

        public float PrecioBase
        {
            get
            {
                return _precioBase;
            }
            set
            {
                ValidarNumero(value);
                _precioBase = value;
            }
        }

        public float CalculoIVA
        {
            get
            {
                return calculoIVA();
            }
        }

        public float PrecioBaseIva
        {
            get
            {
                return precioBaseIva();
            }           
        }

        public float PrecioCantidad
        {
            get
            {
                return precioCantidad();
            }
        }

        public float PrecioCantidadIVA
        {
            get
            {
                return precioCantidadIva();
            }
        }

        // MÉTODOS



        private string ValidarNombre(string cadena)
        {
            cadena = cadena.Trim().ToLower();

            if (string.IsNullOrEmpty(cadena)) throw new CadenaVaciaException();

            foreach(char caracter in cadena)
            {
                if (!(char.IsLetterOrDigit(caracter) || char.IsWhiteSpace(caracter))) throw new FormatoIncorrectoException(); 
            }

            return cadena;

        }

        protected static string ValidarCadena(string cadena)
        {
            cadena = cadena.Trim().ToLower();

            if (string.IsNullOrEmpty(cadena)) throw new CadenaVaciaException();

            foreach (char caracter in cadena)
            {
                if (!(char.IsLetter(caracter) || char.IsWhiteSpace(caracter))) throw new FormatoIncorrectoException();
            }

            return cadena;
        }

        protected static void ValidarNumero(float num)
        {            
            if (num < MIN_NUM) throw new NumeroIncorrectoException();
        }

        public virtual string ToString()
        {
            string cadena = "";

            cadena = $"Nombre: {Nombre}";
            cadena += $"{PrecioBase} Euros/Unidad\n{CalculoIVA} Euros/Unidad + IVA";

            return cadena;
        }



        // CALCULO PRECIOS

        protected abstract float calculoIVA();

        private float precioBaseIva()
        {
            return PrecioBase + CalculoIVA;
        }

        protected abstract float precioCantidad();

        protected abstract float precioCantidadIva();

    }

    public class CadenaVaciaException : Exception
    {
        public CadenaVaciaException() : base("CadenaVacía") { }
        public CadenaVaciaException(string mensaje) : base(mensaje) { }
    }

    public class FormatoIncorrectoException : Exception
    {
        public FormatoIncorrectoException() : base("Formato Incorrecto") { }

        public FormatoIncorrectoException(string message) : base(message) { }
    }

    public class NumeroIncorrectoException : Exception
    {
        public NumeroIncorrectoException() : base("Número Incorrecto") { }

        public NumeroIncorrectoException(string mensaje) :base(mensaje) { }
    }

}

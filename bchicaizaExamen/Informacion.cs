using System;
using System.Collections.Generic;
using System.Text;

namespace bchicaizaExamen
{
    public class Informacion
    {
        private string nombre;
        private string apellido;
        private string edad;
        private string fecha;
        private string pais;
        private string ciudad;
        private string montoInicial;
        private string montoMensual;
        private string montoTotal;
        private string usuario;
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Edad { get => edad; set => edad = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Pais { get => pais; set => pais = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string MontoInicial { get => montoInicial; set => montoInicial = value; }
        public string MontoMensual { get => montoMensual; set => montoMensual = value; }
        public string MontoTotal { get => montoTotal; set => montoTotal = value; }
        public string Usuario { get => usuario; set => usuario = value; }
    }
}

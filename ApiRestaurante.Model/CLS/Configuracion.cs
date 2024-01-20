using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Model.CLS
{
    public class Configuracion
    {
        int idConfiguracion;
        int controlStock;
        int incluirPropina;
        double propina;
        int incluirImpuesto;
        double iva;
        double mesaVIP;
        int autorizarDescProp;
        String printerComanda;
        String printerFactura;
        String printerInformes;
        int alertaCaja;
        int multisesion;
        int numSesiones;
        int muchosProductos;

        public int IdConfiguracion { get => idConfiguracion; set => idConfiguracion = value; }
        public int ControlStock { get => controlStock; set => controlStock = value; }
        public int IncluirPropina { get => incluirPropina; set => incluirPropina = value; }
        public double Propina { get => propina; set => propina = value; }
        public int IncluirImpuesto { get => incluirImpuesto; set => incluirImpuesto = value; }
        public double Iva { get => iva; set => iva = value; }
        public double MesaVIP { get => mesaVIP; set => mesaVIP = value; }
        public int AutorizarDescProp { get => autorizarDescProp; set => autorizarDescProp = value; }
        public string PrinterComanda { get => printerComanda; set => printerComanda = value; }
        public string PrinterFactura { get => printerFactura; set => printerFactura = value; }
        public string PrinterInformes { get => printerInformes; set => printerInformes = value; }
        public int AlertaCaja { get => alertaCaja; set => alertaCaja = value; }
        public int Multisesion { get => multisesion; set => multisesion = value; }
        public int NumSesiones { get => numSesiones; set => numSesiones = value; }
        public int MuchosProductos { get => muchosProductos; set => muchosProductos = value; }
    }
}

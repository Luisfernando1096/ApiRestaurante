using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Model.CLS
{
    public class Pedido
    {
        int idPedido;
        int idCliente;
        int idMesa;
        int idCuenta;
        int idMesero;
        bool cancelado;
        String fecha;
        bool listo;
        double total;
        double descuento;
        double iva;
        double propina;
        double totalPago;
        double saldo;
        int idTiraje;
        String nFactura;
        bool anular;
        double efectivo;
        double credito;
        double btc;

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdMesa { get => idMesa; set => idMesa = value; }
        public int IdCuenta { get => idCuenta; set => idCuenta = value; }
        public int IdMesero { get => idMesero; set => idMesero = value; }
        public bool Cancelado { get => cancelado; set => cancelado = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public bool Listo { get => listo; set => listo = value; }
        public double Total { get => total; set => total = value; }
        public double Descuento { get => descuento; set => descuento = value; }
        public double Iva { get => iva; set => iva = value; }
        public double Propina { get => propina; set => propina = value; }
        public double TotalPago { get => totalPago; set => totalPago = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public int IdTiraje { get => idTiraje; set => idTiraje = value; }
        public string NFactura { get => nFactura; set => nFactura = value; }
        public bool Anular { get => anular; set => anular = value; }
        public double Efectivo { get => efectivo; set => efectivo = value; }
        public double Credito { get => credito; set => credito = value; }
        public double Btc { get => btc; set => btc = value; }
    }
}

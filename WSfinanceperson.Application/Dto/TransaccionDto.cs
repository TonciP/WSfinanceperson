using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Application.Dto
{
    public class TransaccionDto
    {
        public decimal Monto { get;  set; }
        public string Descripcion { get;  set; }
        public CuentaDto Cuenta { get; set; }
        //public Guid CuentaId { get;  set; }

        public string Tipo { get;  set; }
        public string Estado { get;  set; }
        //public Guid CategoriaId { get; set; }
        public DateTime FechaRegistro { get;  set; }

        public CategoriaDto Categoria { get; set; }

        public TransaccionDto() { }
        public TransaccionDto(string tipo)
        {
            FechaRegistro = DateTime.Now;
            //Estado = EstadoTransaccion.Registrado;
            Tipo = tipo;
            //_detalle = new List<DetalleTransaccion>();
        }

        public TransaccionDto(decimal monto, string descripcion, Guid cuentaId, string tipo, CategoriaDto categoria)
        {
            Monto = monto;
            Descripcion = descripcion;
            //CuentaId = cuentaId;
            Tipo = tipo;
            Categoria = categoria;
        }
    }
}

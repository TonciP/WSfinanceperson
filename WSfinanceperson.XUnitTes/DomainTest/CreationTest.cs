using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Personas;
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Domain.Models.Transacciones;
using WSfinanceperson.Domain.Models.Transferencias;
using Xunit;

namespace WSfinanceperson.XUnitTes.DomainTest
{
    
    public class CreationTest
    {
        [Fact]
        public void CreatePersona_WithValidParameters_ReturnsPersona()
        {
            //Assert.ThrowsAsync<BussinessRuleValidationException>(() => Task.FromResult(new Persona("Juan", "Perez")));
            string correo = "56350a";
            string contrasena = "root";
            var exeptionCorreo = Assert.ThrowsAsync<BussinessRuleValidationException>(() => Task.FromResult(new Persona(correo, contrasena)));

            Assert.Equal("Mail is Invalid", exeptionCorreo.Result.Message);

            correo = "56350a@nur.edu.bo";
            contrasena = "123";
            var exeptionContrasena= Assert.ThrowsAsync<BussinessRuleValidationException>(() => Task.FromResult(new Persona(correo, contrasena)));

            Assert.Equal("La contraseña no contiene letras", exeptionContrasena.Result.Message);

            correo = "56350a@nur.edu.bo";
            contrasena = "root";
            var exeptionContrasena2 = Assert.ThrowsAsync<BussinessRuleValidationException>(() => Task.FromResult(new Persona(correo, contrasena)));

            Assert.Equal("La contraseña no contiene numeros", exeptionContrasena2.Result.Message);

            //correo = "56350a@nur.edu.bo";
            //contrasena = "root123";
            //var exeptionContrasena3 = Assert.ThrowsAsync<BussinessRuleValidationException>(() => Task.FromResult(new Persona(correo, contrasena)));

            //Assert.Equal("La contraseña no contiene caracteres especiales", exeptionContrasena3.Result.Message);

            correo = "56350a@nur.edu.bo";
            contrasena = "4813494d137e1631bba301d5acab6e7bb7aa74ce1185d456565ef51d737677b2";
            Persona persona = new Persona(correo, contrasena);

            Assert.Equal(correo, persona.Correo);
            Assert.Equal(contrasena, persona.Contrasena);
        }

        [Fact]
        public void CreateTransaccion_WithValidParameters_ReturnsTransaccion()
        {
            decimal monto = -100;
            string descripcion = "Alimento";
            Guid cuentaId = Guid.NewGuid();
            Movimiento tipo = Movimiento.Egreso;
            EstadoTransaccion estadoTransaccion = EstadoTransaccion.Registrado;
            Guid categoriaId = Guid.NewGuid();

            var exeptionMonto= Assert.ThrowsAsync<BussinessRuleValidationException>(() => 
            Task.FromResult(new Transaccion(monto, descripcion, cuentaId, tipo, estadoTransaccion, categoriaId))
            );

            Assert.Equal("La cantidad no puede ser menor a 0", exeptionMonto.Result.Message);

            monto = 100;
            descripcion = "Alimento";
            cuentaId = Guid.NewGuid();
            tipo = Movimiento.Egreso;
            estadoTransaccion = EstadoTransaccion.Registrado;
            categoriaId = Guid.NewGuid();

            Transaccion transaccion = new Transaccion(monto, descripcion, cuentaId, tipo, estadoTransaccion, categoriaId);

            Assert.Equal(monto, transaccion.Monto.Value);
            Assert.Equal(descripcion, transaccion.Descripcion);
            Assert.Equal(cuentaId, transaccion.CuentaId);
            Assert.Equal(tipo, transaccion.Tipo);
            Assert.Equal(estadoTransaccion, transaccion.Estado);
            Assert.Equal(categoriaId, transaccion.CategoriaId);

        }

        [Fact]
        public void CreateTransferencia_WithValidParameters_ReturnsTransferencia()
        {
            
            Guid cuentaOrigenId = Guid.NewGuid();
            Guid cuentaDestinoId = Guid.NewGuid();
            decimal monto = -100;
            Movimiento tipo = Movimiento.Egreso;
            EstadoTransaccion estadoTransaccion = EstadoTransaccion.Registrado;

            var exeptionMonto = Assert.ThrowsAsync<BussinessRuleValidationException>(() =>
            Task.FromResult(new Transferencia(cuentaOrigenId, cuentaDestinoId, monto, tipo, estadoTransaccion))
            );

            Assert.Equal("La cantidad no puede ser menor a 0", exeptionMonto.Result.Message);

            monto = 100;
            cuentaOrigenId = Guid.NewGuid();
            cuentaDestinoId = Guid.NewGuid();
            tipo = Movimiento.Egreso;
            estadoTransaccion = EstadoTransaccion.Registrado;

            Transferencia transferencia = new Transferencia(cuentaOrigenId, cuentaDestinoId, monto, tipo, estadoTransaccion);

            Assert.Equal(monto, transferencia.Monto.Value);
            Assert.Equal(cuentaOrigenId, transferencia.CuentaOrigenId);
            Assert.Equal(cuentaDestinoId, transferencia.CuentaDestinoId);
            Assert.Equal(tipo, transferencia.Tipo);
            Assert.Equal(estadoTransaccion, transferencia.Estado);
        }

        [Fact]
        public void CreateCuenta_WithValidParameters_ReturnsCuenta()
        {
            string nombre = "Banco Nacional";
            decimal saldo = -100;
            Guid personaId = Guid.NewGuid();

            var exeptionMonto = Assert.ThrowsAsync<BussinessRuleValidationException>(() =>
            Task.FromResult(new Cuenta(nombre, saldo, personaId))
            );

            Assert.Equal("La cantidad no puede ser menor a 0", exeptionMonto.Result.Message);

            nombre = "Banco Futuro";
            saldo = 100;

            Cuenta transferencia = new Cuenta(nombre, saldo, personaId);

            Assert.Equal(nombre, transferencia.Nombre);
            Assert.Equal(saldo, transferencia.SaldoInicial.Value);
            Assert.Equal(personaId, transferencia.PersonaId);
        }

    }
}

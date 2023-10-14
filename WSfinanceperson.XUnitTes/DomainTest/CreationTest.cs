using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WSfinanceperson.XUnitTes.DomainTest
{
    
    public class CreationTest
    {
        [Fact]
        public void CreatePersona_WithValidParameters_ReturnsPersona()
        {
            // Arrange
            var nombre = "Juan";
            var apellido = "Perez";
            var fechaNacimiento = DateTime.Now.AddYears(-20);
            var email = "";
        }
    }
}

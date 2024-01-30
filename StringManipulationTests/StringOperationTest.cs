using StringManipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringManipulationTests
{
    public class StringOperationTest
    {

        [Fact]
        public void ConcatenateStrings() // Las clases y metodos de prueba deben ser públicos
        {
            var strOperations = new StringOperations(); // Crear objeto de la clase que tiene las operaciones que queremos probar

            var result = strOperations.ConcatenateStrings("Hello", "Platzi"); // Guardamos resultado de la operacion y le pasamos los strings

            Assert.Equal("Hello Platzi", result); // Comprobamos que la función esté devolviendo bien con Assert nos permite hacer esa comparacion, nos dice cual es el string esperado y cual es el string actual
        }
    }
}

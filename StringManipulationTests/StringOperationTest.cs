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
            // Arrange
            var strOperations = new StringOperations(); // Crear objeto de la clase que tiene las operaciones que queremos probar
            // Act
            var result = strOperations.ConcatenateStrings("Hello", "Platzi"); // Guardamos resultado de la operacion y le pasamos los strings
            // Assert
            Assert.NotNull(result); 
            Assert.NotEmpty(result);    
            // Se pueden cubrir estas dos comprobaciones ademas de la ultima
            Assert.Equal("Hello Platzi", result); // Comprobamos que la función esté devolviendo bien con Assert nos permite hacer esa comparacion, nos dice cual es el string esperado y cual es el string actual
        }


        // Cuando trabajamos con metodos que devuelven T o F, tenemos que trabajar con ambos escenarios en distintos metodos haciendo referencia en los nombres
        [Fact]
        public void IsPalindrome_True()
        {
            // Arrange
            var strOperations = new StringOperations();   
            // Act
            var result = strOperations.IsPalindrome("ama");
            // Assert
            Assert.True(result);   
        }

        [Fact]
        public void IsPalindrome_False()
        {
            // Arrange
            var strOperations = new StringOperations();
            // Act
            var result = strOperations.IsPalindrome("Hello");
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveWhitespace()
        {
            // Arrange
            var strStringManipulation = new StringOperations();
            // Act
            var result = strStringManipulation.RemoveWhitespace("Hola, esta es una prueba");
            // Assert
            Assert.DoesNotContain(" ", result);
        }

    }
}

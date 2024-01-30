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

        // PRUEBA DE ISPALINDROME CON THEORY Y INLINEDATA
        [Theory]

        [InlineData("oro", true)]

        [InlineData("hello", false)]

        public void IsPalindromeTest(string word, bool expected)
        {
            var strOperations = new StringOperations();
            var result = strOperations.IsPalindrome(word);
            if (expected)
            {
                Assert.True(result);
            }
            else
            {
                Assert.False(result);
            }
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

        [Fact]  
        public void QuantintyInWords()
        {
            // Arrange
            var strOperations = new StringOperations();
            // Act
            var result = strOperations.QuantintyInWords("cat", 10);
            // Assert
            Assert.StartsWith("diez", result); 
            Assert.Contains("cat", result);
        }

        // PRUEBA DE QUANTINTYWORDS CON THEORY Y INLINEDATA
        [Theory]

        [InlineData("car", 10, "ten cars")]

        [InlineData("country", 4, "four countries")]

        [InlineData("dog", 1, "one dog")]

        [InlineData("tree", 100, "one hundred trees")]

        public void QuantityInWordsTest(string input, int quantity, string expected)
        {
            // Arrange
            var operations = new StringOperations();
            // Act
            var result = operations.QuantintyInWords(input, quantity);
            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void GetStringLenght_Exception() // Indicamos el exception pq es lo que queremos probar 
        {
            // Arrange
            var strOperations = new StringOperations();
            // La estructura Act no se utiliza porque no alcanzamos a guardar nada, ya que, llamamos a la funcion y va a saltar una excepion inmediantamente 
            // Assert
            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        }

        [Fact]
        public void TruncateString_Exception()
        {
            // Arrange
            var strOperations = new StringOperations();
            // La estructura Act no se utiliza porque no alcanzamos a guardar nada, ya que, llamamos a la funcion y va a saltar una excepion inmediantamente 
            // Assert
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strOperations.TruncateString("Platzi", -2));
        }

        [Theory]
        [InlineData("V", 5)] // De esta manera pasamos por parámetro y podemos hacer múltiples de estas comprobaciones
        // Las pruebas unitarias generalmente no reciben parametros sino que se configura intermanente pero gracias a unos atributos que tiene Xunit se puede hacer sin usar Fact y usando Theory
        public void FromRomanToNumbers(string romanNumer, int expected) // se agregan estos parametros para pasar el numero romano y el resultado esperado de la funcion
        {
            // Arrange
            var strOperations = new StringOperations();
            // Act 
            var result = strOperations.FromRomanToNumber(romanNumer); // recibe el parametro
            // Assert
            Assert.Equal(expected, result);
        }

    } 
}

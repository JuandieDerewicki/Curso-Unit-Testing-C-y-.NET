using StringManipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;

namespace StringManipulationTests
{
    public class StringOperationTest
    {

        [Fact(Skip = "Esta prueba no es válida en este momento, TICKET-001")] // Ademas debe tener un "ticket" que diga cuando se va a volver a realizar
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
        //[Theory]

        //[InlineData("car", 10, "ten cars")]

        //[InlineData("country", 4, "four countries")]

        //[InlineData("dog", 1, "one dog")]

        //[InlineData("tree", 100, "one hundred trees")]

        //public void QuantityInWordsTest(string input, int quantity, string expected)
        //{
        //    // Arrange
        //    var operations = new StringOperations();
        //    // Act
        //    var result = operations.QuantintyInWords(input, quantity);
        //    //Assert
        //    Assert.NotEmpty(result);
        //    Assert.Equal(expected, result);
        //}


        //[Fact]
        //public void GetStringLenght_Exception() // Indicamos el exception pq es lo que queremos probar 
        //{
        //    // Arrange
        //    var strOperations = new StringOperations();
        //    // La estructura Act no se utiliza porque no alcanzamos a guardar nada, ya que, llamamos a la funcion y va a saltar una excepion inmediantamente 
        //    // Assert
        //    //Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        //    Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));

        //}

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

        // Nosotros no queremos probar el loguin, solo las ocurrencias
        [Fact]
        public void CountOccurrences() // Cuenta cuantas veces encuentra un caracter especifico pero adicional a eso, tambien hace un loguin con un pequeño mensaje 
        {
            // Arrange
            var mockLogger = new Mock<ILogger<StringOperations>>();  // Le pasamos al mock el tipo que queremos que nos simlule que en este caso es ILogger<StringOperatios>
            var strOperations = new StringOperations(mockLogger.Object); // Hacemos un DEBUG TEST para encontrar el error y marcamos esto como el principio o final. El error nos está dando en logger y nosotros lo que queremos es que cuente las ocurrencias y no esa parte
            // Act 
            var result = strOperations.CountOccurrences("Hello platzi", 'l'); // recibe el parametro
            // Assert
            Assert.Equal(3, result);
        }

        // Esta funcion lee un archivo y regresa el texto que tiene, pero para leer ese archivo tiene una interfaz de la que depende y no la recibe desde el construsctor (como normalmente se hace) sino que la recibe como parametro y debemos simular esa interfaz
        [Fact]
        public void ReadFile()
        { 
            var mockFileReader = new Mock<IFileReaderConector>(); // Tenemos que simular la logica de esta interfaz
            var strOperations = new StringOperations();
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file"); // Este metodo setup me permite configurar una funcion en particular q tenga el mockfilereader
            // poniendo esa clase de it.isany estamos haciendo que retorne sea cual esa el archivo, el reading file
            var result = strOperations.ReadFile(mockFileReader.Object, "file.txt");

            Assert.Equal("Reading file", result);
        }


    } 
}

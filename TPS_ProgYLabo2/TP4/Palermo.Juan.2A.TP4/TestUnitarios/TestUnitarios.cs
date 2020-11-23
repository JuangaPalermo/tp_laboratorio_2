using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Excepciones;
using Archivos;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        [TestMethod]
        public void TestColeccionCompra()
        {
            Compra<Periferico> compra = new Compra<Periferico>();

            Assert.IsNotNull(compra.Elementos);
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestArchivosTexto()
        {
            Teclado teclado = new Teclado(Periferico.Marca.Gigabyte, 123, "Prueba Teclado");

            Texto txtaux = new Texto();

            txtaux.Guardar(@"ABC:\DirectorioErroneo.abc", teclado.ToString());

        }

    }
}

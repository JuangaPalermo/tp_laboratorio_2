using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace Test_Unitarios
{
    [TestClass]
    public class TestColecciones
    {
        [TestMethod]
        public void TestColeccionAlumnos()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos);
        }

        [TestMethod]
        public void TestColeccionProfesores()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Instructores);
        }

        [TestMethod]
        public void TestColeccionJornadas()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Jornadas);
        }

        [TestMethod]
        public void TestColeccionAlumnosJornada()
        {
            Jornada jornada = new Jornada(Universidad.EClases.Programacion, new Profesor());

            Assert.IsNotNull(jornada.Alumnos);
        }
    }
}

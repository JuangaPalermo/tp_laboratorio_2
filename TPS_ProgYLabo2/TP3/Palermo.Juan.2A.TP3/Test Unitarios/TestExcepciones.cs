using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace Test_Unitarios
{
    [TestClass]
    public class TestExcepciones
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalido()
        {
            string dniString = "lalala";
            string dniNegativo = "-20";
            string dniGrande = "150000365";

            Alumno a1 = new Alumno(1, "primer", "alumno", dniString, Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "segundo", "alumno", dniNegativo, Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            Alumno a3 = new Alumno(3, "tercer", "alumno", dniGrande, Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Alumno a4 = new Alumno(4, "cuarto", "alumno", dniGrande, Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalida()
        {
            string dniNacional = "38564254";
            string dniExtranjero = "93564825";
            Profesor p1 = new Profesor(1, "primer", "profesor", dniNacional, Persona.ENacionalidad.Extranjero);
            Profesor p2 = new Profesor(2, "segundo", "profesor", dniExtranjero, Persona.ENacionalidad.Argentino);
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetido()
        {
            Universidad universidad = new Universidad();

            Alumno a1 = new Alumno(1, "Alumno", "Prueba", "41172065", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

            universidad += a1;
            universidad += a1;

        }

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestSinProfesor()
        {
            Universidad universidad = new Universidad();
            Profesor profesor = new Profesor(1, "Profesor", "Prueba", "32165498", Persona.ENacionalidad.Argentino);

            profesor = (universidad == Universidad.EClases.Laboratorio);
            profesor = (universidad == Universidad.EClases.Programacion);
            profesor = (universidad == Universidad.EClases.Legislacion);
            profesor = (universidad == Universidad.EClases.SPD);
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestArchivosXml()
        {
            Universidad universidad = new Universidad();

            Xml<Universidad> xmlaux = new Xml<Universidad>();
            xmlaux.Guardar(@"ABC:\DirectorioErroneo.abc", universidad);
            xmlaux.Leer(@"ABC:\DirectorioErroneo.abc", out universidad);

        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestArchivosTexto()
        {
            Profesor profesor = new Profesor(1, "Profesor", "Prueba", "32165498", Persona.ENacionalidad.Argentino);
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, profesor);
            string auxstr;

            Texto txtaux = new Texto();

            txtaux.Guardar(@"ABC:\DirectorioErroneo.abc", jornada.ToString());
            txtaux.Leer(@"ABC:\DirectorioErroneo.abc", out auxstr);

        }

    }
}

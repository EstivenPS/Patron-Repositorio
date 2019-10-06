using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatronRepositorio.BLL;
using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void RepositorioBaseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Empleados> repositorio;
            repositorio = new RepositorioBase<Empleados>();

            Empleados empleado = new Empleados();
            empleado.EmpleadoId = 0;
            empleado.Fecha = DateTime.Now;
            empleado.Nombres = "Prueba";
            empleado.Direccion = "Prueba";
            empleado.Telefono = "000-000-0000";
            empleado.Celular = "000-000-0000";
            empleado.Cedula = "000-0000000-0";
            empleado.Sueldo = 0;
            empleado.Incentivo = 0;

            Assert.IsTrue(repositorio.Guardar(empleado));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Empleados> repositorio;
            repositorio = new RepositorioBase<Empleados>();

            Empleados empleado = new Empleados();
            empleado.EmpleadoId = 1;
            empleado.Fecha = DateTime.Now;
            empleado.Nombres = "Prueba Modificada";
            empleado.Direccion = "Prueba Modificada";
            empleado.Telefono = "000-000-0000";
            empleado.Celular = "000-000-0000";
            empleado.Cedula = "000-0000000-0";
            empleado.Sueldo = 1;
            empleado.Incentivo = 1;

            Assert.IsTrue(repositorio.Modificar(empleado));
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Empleados> repositorio;
            repositorio = new RepositorioBase<Empleados>();
            
            Assert.IsTrue(repositorio.Eliminar(1));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Empleados> repositorio;
            repositorio = new RepositorioBase<Empleados>();

            Empleados empleado = repositorio.Buscar(1);


            Assert.IsTrue(empleado != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}
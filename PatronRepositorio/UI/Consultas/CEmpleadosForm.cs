using PatronRepositorio.BLL;
using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatronRepositorio.UI.Consultas
{
    public partial class CEmpleadosForm : Form
    {
        public CEmpleadosForm()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Empleados>();
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();

            if(CriteriotextBox.Text.Trim().Length > 0)
            {
                switch(FiltrocomboBox.SelectedIndex)
                {
                    case 0://Todos
                        listado = repositorio.GetList(p => true);
                        break;

                    case 1://ID
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = repositorio.GetList(p => p.EmpleadoId == id);
                        break;

                    case 2://Nombre
                        listado = repositorio.GetList(p => p.Nombres.Contains(CriteriotextBox.Text));
                        break;

                    case 3://Direccion
                        listado = repositorio.GetList(p => p.Direccion.Contains(CriteriotextBox.Text));
                        break;

                    case 4://Sueldo
                        decimal sueldo = Convert.ToDecimal(CriteriotextBox.Text);
                        listado = repositorio.GetList(p => p.Sueldo == sueldo);
                        break;
                }

                listado = listado.Where(c => c.Fecha.Date >= DesdedateTimePicker.Value.Date && c.Fecha <= HastadateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = repositorio.GetList(p => true);
            }

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }
    }
}

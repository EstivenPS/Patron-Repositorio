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

namespace PatronRepositorio.UI.Registros
{
    public partial class REmpleadosForm : Form
    {
        public REmpleadosForm()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            NombretextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            CelularmaskedTextBox.Text = string.Empty;
            CedulamaskedTextBox.Text = string.Empty;
            SueldotextBox.Text = string.Empty;
            IncentivotextBox.Text = string.Empty;
            MyerrorProvider.Clear();
        }

        private Empleados LlenaClase()
        {
            Empleados empleado = new Empleados();

            empleado.EmpleadoId = (int)IDnumericUpDown.Value;
            empleado.Fecha = FechadateTimePicker.Value;
            empleado.Nombres = NombretextBox.Text;
            empleado.Direccion = DirecciontextBox.Text;
            empleado.Telefono = TelefonomaskedTextBox.Text;
            empleado.Celular = CelularmaskedTextBox.Text;
            empleado.Cedula = CedulamaskedTextBox.Text;
            empleado.Sueldo = Convert.ToDecimal(SueldotextBox.Text);
            empleado.Incentivo = Convert.ToDecimal(IncentivotextBox.Text);

            return empleado;
        }

        private void LlenaCampos(Empleados empleado)
        {
            IDnumericUpDown.Value = empleado.EmpleadoId;
            FechadateTimePicker.Value = empleado.Fecha;
            NombretextBox.Text = empleado.Nombres;
            DirecciontextBox.Text = empleado.Direccion;
            TelefonomaskedTextBox.Text = empleado.Telefono;
            CelularmaskedTextBox.Text = empleado.Cedula;
            CedulamaskedTextBox.Text = empleado.Cedula;
            SueldotextBox.Text = Convert.ToString(empleado.Sueldo);
            IncentivotextBox.Text = Convert.ToString(empleado.Incentivo);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();

            Empleados empleado = repositorio.Buscar((int)IDnumericUpDown.Value);

            return (empleado != null);
        }

        private bool Validar()
        {
            bool paso = true;
            MyerrorProvider.Clear();

            if(string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                MyerrorProvider.SetError(NombretextBox, "El campo Nombre no puede estar vacio");
                NombretextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                MyerrorProvider.SetError(DirecciontextBox, "El campo Direccion no puede estar vacio");
                DirecciontextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text))
            {
                MyerrorProvider.SetError(DirecciontextBox, "El campo Telefono no puede estar vacio");
                TelefonomaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CelularmaskedTextBox.Text))
            {
                MyerrorProvider.SetError(CelularmaskedTextBox, "El campo Celular no puede estar vacio");
                CelularmaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text))
            {
                MyerrorProvider.SetError(CedulamaskedTextBox, "El campo Cedula no puede estar vacio");
                CedulamaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(SueldotextBox.Text))
            {
                MyerrorProvider.SetError(DirecciontextBox, "El campo Sueldo no puede estar vacio");
                SueldotextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(IncentivotextBox.Text))
            {
                MyerrorProvider.SetError(IncentivotextBox, "El campo Incentivo no puede estar vacio");
                IncentivotextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Empleados empleado;
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();

            if (!Validar())
                return;

            empleado = LlenaClase();

            if (IDnumericUpDown.Value == 0)
                paso = repositorio.Guardar(empleado);
            else
            {
                if(!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un registro que no existe en la base de datos", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                paso = repositorio.Modificar(empleado);
            }

            if(paso)
            {
                Limpiar();
                MessageBox.Show("¡Guardado correctamente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("¡No fue posible guardar!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id;
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            int.TryParse(Convert.ToString(IDnumericUpDown.Value), out id);

            Limpiar();

            if (repositorio.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyerrorProvider.SetError(IDnumericUpDown, "No se puede eliminar un registro que no existe");
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Empleados empleado = new Empleados();
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            int.TryParse(Convert.ToString(IDnumericUpDown.Value), out id);

            Limpiar();

            empleado = repositorio.Buscar(id);

            if (empleado != null)
                LlenaCampos(empleado);
            else
                MessageBox.Show("Registro no encontrado");
        }
    }
}

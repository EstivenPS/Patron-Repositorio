using PatronRepositorio.UI.Consultas;
using PatronRepositorio.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatronRepositorio
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void RegistroDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REmpleadosForm re = new REmpleadosForm();
            re.MdiParent = this;
            re.Show();
        }

        private void ConsultaDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CEmpleadosForm ce = new CEmpleadosForm();
            ce.MdiParent = this;
            ce.Show();
        }
    }
}

using Manejador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion_TallerAutomotiz
{
    public partial class FrmRefacciones : Form
    {
        ManejadorRefacciones MR;
        int fila = 0, columna = 0;
        public static int idR = 0;
        public static string CodigoBarras = "", Nombre = "", Descripcion= "", Marca = "";

        private void button3_Click(object sender, EventArgs e)
        {
            idR = 0; CodigoBarras = ""; Nombre = ""; Descripcion = "";  Marca = ""; 
            FrmAgregarRefacciones dm = new FrmAgregarRefacciones();
            dm.ShowDialog();
            txtBuscar.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (fila >= 0)
            {
                idR = int.Parse(dtgvAdministrador.Rows[fila].Cells[0].Value.ToString());
                CodigoBarras = dtgvAdministrador.Rows[fila].Cells[1].Value.ToString();
                Nombre = dtgvAdministrador.Rows[fila].Cells[2].Value.ToString();
                Descripcion = dtgvAdministrador.Rows[fila].Cells[5].Value.ToString();
                Marca = dtgvAdministrador.Rows[fila].Cells[4].Value.ToString();
                FrmAgregarRefacciones dm = new FrmAgregarRefacciones();
                dm.ShowDialog();
                Limpiar();
                txtBuscar.Focus();
            }
            else
                MessageBox.Show("Por favor, seleccione una fila válida para modificar.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            idR = int.Parse(dtgvAdministrador.Rows[fila].Cells[0].Value.ToString());
            MR.Eliminar(idR, dtgvAdministrador.Rows[fila].Cells[1].Value.ToString());
            Limpiar();
            txtBuscar.Focus();
        }

        public FrmRefacciones()
        {
            InitializeComponent();
            MR = new ManejadorRefacciones();
        }
        void Limpiar()
        {
            dtgvAdministrador.Visible = false;
        }

        private void FrmRefacciones_Load(object sender, EventArgs e)
        {

        }
    }
}

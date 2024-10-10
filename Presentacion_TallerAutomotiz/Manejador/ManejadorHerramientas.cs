using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using Entidades;

namespace Manejador
{
    public class ManejadorHerramientas
    {
        Base b = new Base("localhost", "root", "", "BD_TallerAutomotriz");

        public string GuardarHerramientas(TextBox codigoherramientas, TextBox Nombre, TextBox medida, TextBox Marca, TextBox Descripcion)
        {
            try
            {
                return b.Comando(($"insert into Herramientas values (null'{codigoherramientas.Text}','{Nombre.Text}', '{medida.Text}', '{Marca.Text}', '{Descripcion.Text}')"));
            }
            catch (Exception)
            {
                return "Error de valor";
            }
        }
        public void MostrarHerramientas(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            DataTable datos = b.Consultar($"SELECT * FROM Herramientas WHERE Tipo LIKE '%{filtro}%' OR CodigoHerramienta LIKE '%{filtro}%' AND Nombre LIKE '%{filtro}%'", "Herramientas").Tables[0];
            Tabla.DataSource = datos;
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }
        public void Modificar(int idh, TextBox codigoherramientas, TextBox Nombre, TextBox medida, TextBox Marca, TextBox Descripcion)
        {
            b.Comando($"CALL p_ModificarHerramientas({idh},'{codigoherramientas.Text}', '{Nombre.Text}', '{medida.Text}', '{Marca.Text}', '{Descripcion.Text}')");
            MessageBox.Show("Registro Modificado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Eliminar(int idh, string Dato)
        {
            
            DialogResult rs = MessageBox.Show($"Está seguro de borrar {Dato}", "!Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"CALL p_EliminarHerramienta({idh})");
                MessageBox.Show("Registro Eliminado");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_entidad;
using Capa_negocio;


namespace biblioteca_reto2
{
    public partial class Form1 : Form
    {
        claseentidad objent = new claseentidad();
        clasenegocio objeng = new clasenegocio();

        public Form1()
        {
            InitializeComponent();
        }

        void mantenimiento(string accion)
        {
            objent.codigo = txtcodigo.Text;
            objent.titulo = txttitulo.Text;
            objent.autor = txtautor.Text;
            objent.editorial = txteditprial.Text;
            objent.precio = txtprecio.Text;
            objent.cantidad = txtcantidad.Text;
            objent.accion = accion;
            string men = objeng.N_mantenimiento_clientes(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void limpiar()
        {
            txtcodigo.Text = "";
            txttitulo.Text = "";
            txtautor.Text = "";
            txteditprial.Text = "";
            txtprecio.Text = "";
            txtcantidad.Text = "";
            dataGridView1.DataSource = objeng.N_listar_clientes();

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text == "")
            {
                if (MessageBox.Show("¿Deseas registrar a " + txttitulo.Text + "?", "Mensaje",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }


            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + txttitulo.Text + "?", "Mensaje",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }


            }

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text == "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + txttitulo.Text + "?", "Mensaje",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }


            }
        }

        private void txtbuscart_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscart.Text != "")
            {
                objent.titulo = txtbuscart.Text;
                DataTable dt = new DataTable();
                dt = objeng.N_buscar_clientes(objent);
                dataGridView1.DataSource = dt;

            }
            else
            {
                dataGridView1.DataSource = objeng.N_listar_clientes();


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;
            txtcodigo.Text = dataGridView1[0, fila].Value.ToString();
            txttitulo.Text = dataGridView1[1, fila].Value.ToString();
            txtautor.Text = dataGridView1[2, fila].Value.ToString();
            txteditprial.Text = dataGridView1[3, fila].Value.ToString();
            txtprecio.Text = dataGridView1[4, fila].Value.ToString();
            txtcantidad.Text = dataGridView1[5, fila].Value.ToString();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comanda
{
    public partial class Form1 : Form
    {
        readonly BaseDatos menus;
        public Form1()
        {
            InitializeComponent();
            this.Text = "San Jorge Restaurant";
            this.BackColor = Color.BurlyWood;
            menus = new BaseDatos();
            menuActivo();
        }

        private void menuActivo()
        {
            comboBoxMenu.DataSource = menus.listamenu;
            comboBoxMenu.DisplayMember = "Nombre";
            comboBoxMenu.ValueMember = "Id";
        }

        private void comboBoxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxMenu.SelectedIndex)
            {              //Los case no mandaban a llamar a ninguna de las listas
                case 1:listBoxSeleccion.DataSource = menus.ListAperitivos;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 2: listBoxSeleccion.DataSource = menus.Ensalada;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 3: listBoxSeleccion.DataSource = menus.ListCarnes;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 4: listBoxSeleccion.DataSource = menus.ListPescado;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 5: listBoxSeleccion.DataSource = menus.ListPollo;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 6: listBoxSeleccion.DataSource = menus.ListSandwich;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 7: listBoxSeleccion.DataSource = menus.ListSandwich;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 8: listBoxSeleccion.DataSource = menus.ListPaninis;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 9: listBoxSeleccion.DataSource = menus.ListPostre;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 10: listBoxSeleccion.DataSource = menus.ListBebida;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;

                default:
                    listBoxSeleccion.DataSource = menus.Vacio;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    
                    
                    break;
            }
            
           
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AgregarMenu();   
        }
        private void AgregarMenu()
        {
            var valor = listBoxSeleccion.SelectedIndex;
            if (valor!=0)
            {                      //No se podia multiplicar un double con un decimal y lo converti a double
                var datos = Convert.ToDouble(comboBoxCantidad.Text) * Convert.ToDouble(textBoxPrecio.Text); 
                var total = Convert.ToString(datos);
                dataGridView1.Rows.Add(listBoxSeleccion.Text, comboBoxCantidad.Text, textBoxPrecio.Text,total);
     
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarAgregar();
        }

        private void Limpiar()
        {
            textBoxPrecio.Text = "";
            comboBoxCantidad.Text = "0";
            comboBoxMenu.Text = "None";
            textBoxTotal.Text = "";
            dataGridView1.Rows.Clear();
        }

        private void LimpiarAgregar()
        {
            textBoxPrecio.Text = "";
            comboBoxCantidad.Text = "0";
            comboBoxMenu.Text = "None";
            textBoxTotal.Text = "";
            dataGridView1.Rows.Clear(); //Le faltaba esto para que borrara la comanda
        }

        private void buttonCobrar_Click(object sender, EventArgs e)
        {
            cobrar();
        }

        private void cobrar()
        {
            decimal suma = 0;
            foreach (DataGridViewRow Celda in dataGridView1.Rows)
            {  //Faltaba esta llave 
                 suma+=Convert.ToDecimal(Celda.Cells["Total"].Value);
            }

            textBoxTotal.Text = Convert.ToString(suma);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarMenu();
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarAgregar();
        }

        private void cobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cobrar();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Proyecto POO Mayo 2019","Acerca de..");
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void listBoxSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

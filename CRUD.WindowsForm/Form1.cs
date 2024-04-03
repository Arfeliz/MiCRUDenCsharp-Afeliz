using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace CRUD.WindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BD.Conexion();
            MessageBox.Show("Se ha conectado correctamente");

            dataGridView1.DataSource = Consulta();
        }

        public DataTable Consulta()
        {
            BD.Conexion();
            DataTable datos = new DataTable();
            string consultar = "SELECT * FROM Empleados";
            SqlCommand cmd = new SqlCommand(consultar, BD.Conexion());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(datos);
            return datos;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            BD.Conexion();
            string insertar = "INSERT INTO Empleados(codigo,nombre,apellido,direccion) VALUES (@codigo,@nombre,@apellido,@direccion) ";
            SqlCommand insert = new SqlCommand(insertar, BD.Conexion());
            insert.Parameters.AddWithValue("@codigo", textBox3.Text);
            insert.Parameters.AddWithValue("@nombre", textBox1.Text);
            insert.Parameters.AddWithValue("@apellido", textBox2.Text);
            insert.Parameters.AddWithValue("@direccion", textBox4.Text);

            insert.ExecuteNonQuery();

            MessageBox.Show("Se cargo el empleado");

            dataGridView1.DataSource = Consulta();
            Vaciarcasillas();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BD.Conexion();
            string Update = "UPDATE Empleados SET codigo=@codigo, nombre=@nombre, apellido=@apellido, direccion=@direccion where codigo=@codigo";
            SqlCommand actualizar = new SqlCommand(Update, BD.Conexion());
            actualizar.Parameters.AddWithValue("@codigo", textBox3.Text);
            actualizar.Parameters.AddWithValue("@nombre", textBox1.Text);
            actualizar.Parameters.AddWithValue("@apellido", textBox2.Text);
            actualizar.Parameters.AddWithValue("@direccion", textBox4.Text);

            actualizar.ExecuteNonQuery();

            MessageBox.Show("Se ha actualizado correctamente el empleado");

            dataGridView1.DataSource = Consulta();
            Vaciarcasillas();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BD.Conexion();
            String delete = "DELETE FROM Empleados where codigo=@codigo";
            SqlCommand borrar = new SqlCommand(delete, BD.Conexion());
            borrar.Parameters.AddWithValue("@codigo",textBox3.Text);

            borrar.ExecuteNonQuery();

            MessageBox.Show("Se ha eliminado correctamente al empleado");

            dataGridView1.DataSource = Consulta();
            Vaciarcasillas();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Vaciarcasillas();

        }
        public void Vaciarcasillas() 
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            textBox1.Focus();
        }
    }
}

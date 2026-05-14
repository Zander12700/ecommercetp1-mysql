using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;


namespace ecommercetp1


{
    public partial class UsuariosForm : Form
    {
        int idSeleccionado = -1;
        string conexion = "server=localhost;database=usuarios;user=root;password=;";

        public UsuariosForm()
        {
            InitializeComponent();

        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtContraseña.Text = "";
            cbTiendas.SelectedIndex = -1;
            idSeleccionado = -1;
        }


        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvUsuarios.CurrentRow;

                idSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
                txtNombre.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtEmail.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtContraseña.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Contraseña"].Value.ToString();
                cbTiendas.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Tienda"].Value.ToString();
            }
        }

        public void ModificarDatos()
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Por favor, selecciona un registro de la tabla primero.");
                return;
            }
            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                try
                {
                    conn.Open();

                    string query = @"UPDATE usuarios_admin SET Nombre = @nom, Tienda = @tie, Contraseña = @pass, Email = @mail WHERE ID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@tie", cbTiendas.Text);
                        cmd.Parameters.AddWithValue("@pass", txtContraseña.Text);
                        cmd.Parameters.AddWithValue("@mail", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@id", idSeleccionado);

                        int resultado = cmd.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            MessageBox.Show("Registro actualizado con éxito.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar: " + ex.Message);
                }
            }
        }

        public void MostrarDatos()
        {
            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM `usuarios_admin`";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

                    DataTable tabla = new DataTable();

                    adapter.Fill(tabla);

                    dgvUsuarios.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(cbTiendas.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))

                {
                    MessageBox.Show("Todos los campos son obligatorios");
                    return;
                }
                try
                {
                    conn.Open();

                    string query = "INSERT INTO usuarios_admin (Nombre, Tienda, Contraseña, Email) VALUES (@Nombre, @Tienda, @Contraseña, @Email)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Tienda", cbTiendas.Text);
                        cmd.Parameters.AddWithValue("@Contraseña", txtContraseña.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Usuario guardado correctamente");

                        LimpiarCampos();
                        MostrarDatos();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado >= 0)
            {
                ModificarDatos();
                LimpiarCampos();
                MostrarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Por favor, selecciona un registro de la tabla para eliminar.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM usuarios_admin WHERE ID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idSeleccionado);
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Registro eliminado correctamente.");

                            idSeleccionado = -1;
                            LimpiarCampos();
                            MostrarDatos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Actualizar_SQL_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Conexion_Click(object sender, EventArgs e)
        {
            //string conexion = "Server=.\\SQLEXPRESS;Database=UsuariosDB;Trusted_Connection=True;TrustServerCertificate=True;";

            //using (SqlConnection con = new SqlConnection(conexion))
            {
                //string query = @"INSERT INTO Usuarios
                        //(Nombre, Email, Contraseña, Tienda)
                        //VALUES
                        //(@nombre, @email, @contraseña, @tienda)";

                //using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    //cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    //cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    //cmd.Parameters.AddWithValue("@contraseña", txtContraseña.Text);
                    //cmd.Parameters.AddWithValue("@tienda", cbTiendas.SelectedItem.ToString());

                    //conn.Open();
                    //cmd.ExecuteNonQuery();
                }
            }

            //MessageBox.Show("Usuario guardado correctamente");
        }
    }
}

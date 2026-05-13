using MySql.Data.MySqlClient;
using System.Data;
using System.Linq.Expressions;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace usuarios_admin
{
    public partial class UsuariosForms1 : Form
    {
        string conexion = "server=localhost;database=usuarios;user=root;password=;";

        private int idSeleccionado = -1;

        public void LimpiarText()
        {
            txt_Nombre.Clear();
            txt_Tienda.Clear();
            txt_Contra.Clear();
            txt_Email.Clear();
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
                        cmd.Parameters.AddWithValue("@nom", txt_Nombre.Text);
                        cmd.Parameters.AddWithValue("@tie", txt_Tienda.Text);
                        cmd.Parameters.AddWithValue("@pass", txt_Contra.Text);
                        cmd.Parameters.AddWithValue("@mail", txt_Email.Text);
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

                    dtgv_Base.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public void InsertarDatos()
        {
            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                if (string.IsNullOrWhiteSpace(txt_Nombre.Text) ||
                string.IsNullOrWhiteSpace(txt_Tienda.Text) ||
                string.IsNullOrWhiteSpace(txt_Contra.Text) ||
                string.IsNullOrWhiteSpace(txt_Email.Text))

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
                        cmd.Parameters.AddWithValue("@Nombre", txt_Nombre.Text);
                        cmd.Parameters.AddWithValue("@Tienda", txt_Tienda.Text);
                        cmd.Parameters.AddWithValue("@Contraseña", txt_Contra.Text);
                        cmd.Parameters.AddWithValue("@Email", txt_Email.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Usuario guardado correctamente");

                        LimpiarText();
                        MostrarDatos();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }

        }

        public UsuariosForms1()
        {
            InitializeComponent();
        }

        private void btn_Insertar_Click(object sender, EventArgs e)
        {
            InsertarDatos();
            MostrarDatos();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            ModificarDatos();
            MostrarDatos();
        }

        private void dtgv_Base_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Fila clickeada: " + e.RowIndex);

            if (e.RowIndex >= 0 && dtgv_Base.CurrentRow != null)
            {
                var fila = dtgv_Base.CurrentRow;

                idSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
                txt_Nombre.Text = fila.Cells["Nombre"].Value.ToString();
                txt_Tienda.Text = fila.Cells["Tienda"].Value.ToString();
                txt_Contra.Text = fila.Cells["Contraseña"].Value.ToString();
                txt_Email.Text = fila.Cells["Email"].Value.ToString();
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
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
                            LimpiarText();
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace Interfaces_Proyecto
{
    public partial class PantallaInicio : Form
    {
        public PantallaInicio()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3G4P0P9\SQLEXPRESS;Initial Catalog=LOGIN;Integrated Security=True");

        public void logear (string usuario, string contraseña)
        { 
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nombre, Tipo_Usuario FROM Usuarios WHERE Usuario = @usuario AND Password = @pas", con);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("pas", contraseña);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count == 1){

                    this.Hide();
                    if(dt.Rows[0][1].ToString()=="Administrador"){
                        new Administrador(dt.Rows[0][0].ToString()).Show(); 

                    }else if(dt.Rows[0][1].ToString()=="Usuario")
                    {
                        new Usuario(dt.Rows[0][0].ToString()).Show();
                    }

                }else{
                    MessageBox.Show("Usuario y/o Contraseña Incorrecta");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            } finally 
            {
                con.Close();
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void PanelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PantallaInicio_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textUsuario_Enter(object sender, EventArgs e)
        {
            if (textUsuario.Text == "USUARIO")
            {
                textUsuario.Text = "";
                textUsuario.ForeColor = Color.Maroon;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            logear(this.textUsuario.Text, this.textContraseña.Text);
        }

        private void textUsuario_Leave(object sender, EventArgs e)
        {
            if (textUsuario.Text == "")
            {
                textUsuario.Text = "USUARIO";
                textUsuario.ForeColor = Color.White;
            }
        }

        private void textContraseña_Enter(object sender, EventArgs e)
        {
            if (textContraseña.Text == "CONTRASEÑA")
            {
                textContraseña.Text = "";
                textContraseña.ForeColor = Color.Maroon;
                textContraseña.UseSystemPasswordChar = true;
            }
        }

        private void textContraseña_Leave(object sender, EventArgs e)
        {
            if (textContraseña.Text == "")
            {
                textContraseña.Text = "CONTRASEÑA";
                textContraseña.ForeColor = Color.White;
                textContraseña.UseSystemPasswordChar = false;
            }
        }

        private void btMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PantallaInicio_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

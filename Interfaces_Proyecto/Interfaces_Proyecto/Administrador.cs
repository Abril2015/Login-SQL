using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaces_Proyecto
{
    public partial class Administrador : Form
    {
        public Administrador(string nombre)
        {
            InitializeComponent();
            lblMensageAdmin.Text = nombre; 
        }
    }
}

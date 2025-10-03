using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visit.Shared;
using static Visit.Shared.UserRole;

namespace Visit.UI
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2VSeparator1_Click(object sender, EventArgs e)
        {

        }
 
        private void btnBimar_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            UserRole.CurrentRole = Role.Bimar;
            frmLogin.Show();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            UserRole.CurrentRole = Role.Doctor;
            frmLogin.Show();
        }
    }
}

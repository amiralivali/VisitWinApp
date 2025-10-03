using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kavenegar;
using Visit.Shared;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static Visit.Shared.UserRole;

namespace Visit.UI
{
    public partial class frmLogin : Form
    {
        HttpClientHelper clientHelper;
        public frmLogin()
        {
            InitializeComponent();
            clientHelper = new HttpClientHelper();
            if (UserRole.CurrentRole == Role.Bimar)
            {
                lblNcNezam.Text = "کدملی";
            }
            else
            {
                lblNcNezam.Text = "کد نظام پزشکی";
            }
        }
        private void frmBimar_Load(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

        }

        private async void btnSendSms_Click(object sender, EventArgs e)
        {
            string route;
            if (UserRole.CurrentRole == Role.Bimar)
            {
                route = string.Format(RouteConstants.ExistBimar, txtNcNezam.Text, txtMobile.Text);
            }
            else
            {
                route = string.Format(RouteConstants.ExistDoctor, txtNcNezam.Text, txtMobile.Text);
            }
            bool check = await clientHelper.GetAsync<bool>(route);
            if (check==false)
            {
                Random rnd = new Random();
                int randomCode = rnd.Next(100000, 999999);
                string text = "کد ورود به سامانه ویزیت24" + Environment.NewLine + randomCode;
                route = string.Format(RouteConstants.SendSms, text);
                var checkSms = await clientHelper.GetAsync<string>(route);
            }
            else
            {
                MessageBox.Show("!اطلاعات شما در سیستم زخیره نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobile.Text = "";
                txtNcNezam.Text = "";
            }
            
        }
    }
}

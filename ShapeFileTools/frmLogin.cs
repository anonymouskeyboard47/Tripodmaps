using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Tripodmaps
{
    public partial class frmLogin : Form
    {

        TRIP_API.IMLogin tripLogin = null;
        string strUserName = "";
        string strPassword = "";
        string errMessage = "";

        private void LoginNow()
        {
            frmAjaxLoading frmAjaxForm = null;

            try
            {

                frmAjaxForm = new frmAjaxLoading();
                frmAjaxForm.Show(this);
                frmAjaxForm.Update();

                strUserName = txtUserName.Text;
                strPassword = txtPassword.Text;

                if (SystemLogin() == true)
                {
                    frmAjaxForm.Close();
                    frmAjaxForm = null;

                    this.Visible = false;

                    //MessageBox.Show(Application.StartupPath);

                    //string strPath =  this.GetType().Assembly.CodeBase;

                    MainForm MainForm = new MainForm(Application.StartupPath + "\\Data\\" + "Main.trip");
                    //MainForm MainForm = new MainForm("Main.trip");
                    MainForm.Show();

                }

                else
                {
                    frmAjaxForm.Close();
                    frmAjaxForm = null;

                    DialogResult dgResult;

                    dgResult = MessageBox.Show("Tripodsystems Authentication Failed. Please re-enter the login details to retry.",
                        "Tripodsystems Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Closes the parent form.
                    txtUserName.Text = "";
                    txtPassword.Text = "";

                    txtUserName.Focus();

                }
            }

            finally
            {
                if (frmAjaxForm != null)
                {
                    frmAjaxForm.Close();
                    frmAjaxForm = null;
                }
            }
        }

        private bool SystemLogin()
        {
            TRIP_API.IMEventLog imVent = null;

            try
            {
                tripLogin = new TRIP_API.IMLogin();

                if (tripLogin.AuthenticateUser(strUserName, strPassword) == true)
                {
                    imVent = new TRIP_API.IMEventLog();

                    imVent.Source = "Tripodmaps";
                    imVent.Event = "5001";
                    imVent.Log = "Tripodmaps";
                    imVent.EventLogID = 3001;
                    imVent.EveEventType = EventLogEntryType.FailureAudit;

                    imVent.WriteEvent();

                    return true;
                }

                else
                {
                    imVent = new TRIP_API.IMEventLog();

                    imVent.Source = "Tripodmaps";
                    imVent.Event = "5001"; //Failed Login
                    imVent.Log = "Tripodmaps";
                    imVent.EventLogID = 289;
                    imVent.EveEventType = EventLogEntryType.FailureAudit;
                    imVent.WriteEvent();

                    return false;
                }

            }

            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;
            }

            finally
            {
                tripLogin = null;
            }

        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {

            this.Close();
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            LoginNow();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginNow();
            }
        }

        private void lnkNewUserRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCustomers frmCustomer = new frmCustomers(Application.StartupPath + "\\Data\\" + "Main.trip");
            frmCustomer.Show();
        }

    }
}

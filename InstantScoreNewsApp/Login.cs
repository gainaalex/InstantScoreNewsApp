/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-20
 * Fisier: Login.cs
 * Functionalitate: Consituie interfata de log in
 ************************************************************/



using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatchManager;


namespace InstantScoreNewsApp
{
    public partial class Login : Form
    {
        private ProxyMatchManager _proxy;
        public bool succesfullAuthentification;
        //primeste proxy ul ca parametru in vederea executarii operatiilor de login implementate in el
        public Login(ProxyMatchManager p)
        {
            _proxy = p;
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Functia de Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //cazul in care utilizatorul inchide fereasta nu modifica userul curent, ramanand logat pe cel anterior
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Toate campurile trebuie completate", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            succesfullAuthentification= _proxy.Login(textBox1.Text, textBox2.Text);
            if (succesfullAuthentification)
            {
                MessageBox.Show("Autentificare reusita", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Autentificare esuata. Data de log in incorecte", "Err", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        /// <summary>
        /// Functia ce lanseaza interfata de inregistrare a unui nou user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn(_proxy);
            DialogResult result = signIn.ShowDialog();
        }
    }
}

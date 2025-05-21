/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-20
 * Fisier: SignIn.cs
 * Functionalitate: Consituie interfata de sign in/ inregistare
 ************************************************************/

using InstantScoreNewsLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstantScoreNewsApp
{
    public partial class SignIn : Form
    {
        //primit ca parametru in constructor pentru functiile sale de manipulare al userilor
        private ProxyMatchManager _proxy;
        public SignIn(ProxyMatchManager p)
        {
            _proxy = p;
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Toate campurile trebuie completate", "Eroare", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _proxy.AddUser(textBox1.Text, textBox2.Text);
                MessageBox.Show("Inregistrare reusita. Va redirectionam spre meniul de login.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

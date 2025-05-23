/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-23
 * Fisier: EventForm.cs
 * Functionalitate: Consituie interfata cu utilizatorul in momentul adugarii/ modificarii unui eveniment
 ************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatchStats;


namespace InstantScoreNewsApp
{
    public partial class EventForm : Form
    {
        // obiect rezultat in urma interactiunii cu utilizatorul
        public Event eveniment;
        public EventForm()
        {
            InitializeComponent();
        }

        public EventForm(Event e)
        {
            InitializeComponent();
            textBoxMinut.Text=e.minut.ToString();
            textBoxDesc.Text=e.descriere;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMinut.Text) || string.IsNullOrWhiteSpace(textBoxDesc.Text))
            {
                MessageBox.Show("Toate campurile trebuie completate", "Eroare", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                eveniment = new Event(int.Parse(textBoxMinut.Text), textBoxDesc.Text);
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Formular trimis cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

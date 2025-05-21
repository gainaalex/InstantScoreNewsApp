/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-20
 * Fisier: MatchForm.cs
 * Functionalitate: Consituie interfata de adaugare/modifiare meciuri
 ************************************************************/



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InstantScoreNewsLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace InstantScoreNewsApp
{
    public partial class MatchForm : Form
    {
        //folosit pentru a putea primi in interfata principala obiectul nou format
        public Match match; 
        public MatchForm()
        {
            InitializeComponent();
        }
        //constructor apelat cand vrem sa modificam un meci
        public MatchForm(Match m)
        {
            InitializeComponent();

            textBoxGazda.Text = m.Gazda;
            textBoxOaspete.Text = m.Oaspete;
            textBoxScorG.Text = m.ScorGazda.ToString();
            textBoxScorO.Text = m.ScorOaspete.ToString();
        }
        /// <summary>
        /// Salveaza un obiect Match cu noile date introduse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxGazda.Text) || string.IsNullOrWhiteSpace(textBoxOaspete.Text) || 
                string.IsNullOrWhiteSpace(textBoxScorG.Text) || string.IsNullOrWhiteSpace(textBoxScorO.Text))
            {
                MessageBox.Show("Toate campurile trebuie completate", "Eroare", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                match = new Match(textBoxGazda.Text, textBoxOaspete.Text, int.Parse(textBoxScorG.Text), int.Parse(textBoxScorO.Text));
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Formular trimis cu succes", "Sucees", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

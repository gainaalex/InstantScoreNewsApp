/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-23
 * Fisier: InstantScoreNews.cs
 * Functionalitate: Consituie interfata ce intampina userul si se modifica in functie de tipul utilizatorului
 ************************************************************/

using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Text.RegularExpressions;
using MatchManager;
using MatchStats;

namespace InstantScoreNewsApp;

public partial class InstantScoreNews : Form
{
    private ProxyMatchManager _matchManager;
    private MatchStats.Match _currentMatch;
    public InstantScoreNews()
    {
        InitializeComponent();
        //folosim proxy pentru identificarea permisiunilor fiecarui utilizator autentificat
        _matchManager = new ProxyMatchManager();
    }
    /// <summary>
    /// Acctualizeaza interfata in functie de tipul de acces al userului curent
    /// </summary>
    private void UpdateGUI()
    {
        if (_matchManager.CurrentUser == null)
        {
            buttonLogOut.Enabled = false;
            label1.Text = "Neautentificat";

            buttonAddMeci.Enabled = false;
            buttonAddEvent.Enabled = false;
            buttonElimMeci.Enabled = false;
            buttonElimEvent.Enabled = false;
            buttonModifMeci.Enabled = false;
            buttonModifEvent.Enabled = false;
        }
        else
        {
            buttonLogOut.Enabled = true;
            if (_matchManager.CurrentUser.AccesType == -1)
            {
                buttonAddMeci.Enabled = true;
                buttonAddEvent.Enabled = true;
                buttonElimMeci.Enabled = true;
                buttonElimEvent.Enabled = true;
                buttonModifMeci.Enabled = true;
                buttonModifEvent.Enabled = true;
            }
            else
            {
                buttonAddMeci.Enabled = false;
                buttonAddEvent.Enabled = false;
                buttonElimMeci.Enabled = false;
                buttonElimEvent.Enabled = false;
                buttonModifMeci.Enabled = false;
                buttonModifEvent.Enabled = false;
            }
        }
    }
    private void ClearListBoxes()
    {
        listBox1.Items.Clear();
        listBox2.Items.Clear();
    }
    /// <summary>
    /// Actualizeaza lista meciurilor
    /// </summary>
    private void UpdateMatchListBox()
    {
        ClearListBoxes();
        listBox1.Items.AddRange(_matchManager.GetMatches().ToArray());
    }
    /// <summary>
    /// Actualizeaza lista Evenimentelor din meciul curent selectat
    /// </summary>
    private void UpdateEventListBox()
    {
        listBox2.Items.Clear();
        listBox2.Items.AddRange(_matchManager.GetEvents(_currentMatch).ToArray());
    }

    /// <summary>
    /// Butonul de Login ce lanseaza interfata de Login
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button1_Click(object sender, EventArgs e)
    {
        Login login = new Login(_matchManager);
        DialogResult result = login.ShowDialog();
        if (result == DialogResult.OK)
        {
            label1.Text = "Bine ai venit, " + _matchManager.CurrentUser.Username + "!";
            UpdateMatchListBox();
            //userul e intampinat cu ultimele actiuni ale adminului
            foreach (var notificare in _matchManager.CurrentUser.Notificari)
            {
                MessageBox.Show(notificare, "Notificare Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _matchManager.CurrentUser.Notificari.Clear();
        }
        _currentMatch = null;
        UpdateGUI();

    }

    private void buttonAddMeci_Click(object sender, EventArgs e)
    {
        MatchForm mf = new MatchForm();
        DialogResult = mf.ShowDialog();
        if (DialogResult == DialogResult.OK)
        {
            _matchManager.AddMatch(mf.match);
        }
        UpdateMatchListBox();
    }
    /// <summary>
    /// Actualizeaza meciul curent selectat la navigarea pe interfata grafica
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        MatchStats.Match m = listBox1.SelectedItem as MatchStats.Match;
        if (m != null)
        {
            _currentMatch = m;
            listBox2.Items.Clear();
            listBox2.Items.AddRange(_matchManager.GetEvents(m).ToArray());
        }
    }

    private void buttonLogOut_Click(object sender, EventArgs e)
    {
        _matchManager.CurrentUser = null;
        _currentMatch = null;
        //neautentificat nu ai acces la meciuri
        ClearListBoxes();
        UpdateGUI();
    }

    private void buttonModifMeci_Click(object sender, EventArgs e)
    {
        if (_currentMatch != null)
        {
            MatchForm mf = new MatchForm(_currentMatch);
            DialogResult = mf.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                _matchManager.UpdateMatch(_currentMatch, mf.match);
            }
            UpdateMatchListBox();
        }
        else
            MessageBox.Show("Pentru a modifica un camp mai intai trebuie sa-l selectezi", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void buttonElimMeci_Click(object sender, EventArgs e)
    {
        if (_currentMatch != null)
        {
            _matchManager.RemoveMatch(_currentMatch);
            UpdateMatchListBox();
        }
        else
            MessageBox.Show("Pentru a sterge un meci mai intai trebuie sa-l selectezi", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void buttonAddEvent_Click(object sender, EventArgs e)
    {
        if (_currentMatch != null)
        {
            EventForm ef = new EventForm();
            DialogResult = ef.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                _matchManager.AddEvent(_currentMatch, ef.eveniment);
                UpdateEventListBox();
            }
        }
        else
        {
            MessageBox.Show("Pentru a adauga un eveniment mai intai trebuie sa selectezi un meci", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void buttonModifEvent_Click(object sender, EventArgs e)
    {
        //selectia evenimentului de modificat
        Event evenim = listBox2.SelectedItem as Event;
        if (evenim != null)
        {
            EventForm ef = new EventForm(evenim);
            DialogResult = ef.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                _matchManager.UpdateEvent(_currentMatch, evenim, ef.eveniment);
                UpdateEventListBox();
            }

        }
        else
        {
            MessageBox.Show("Pentru a modifica un eveniment mai intai trebuie sa-l selectezi", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void buttonElimEvent_Click(object sender, EventArgs e)
    {
        //selectia evenimentului de modificat
        Event evenim = listBox2.SelectedItem as Event;
        if (evenim != null)
        {
            _matchManager.DeleteEvent(_currentMatch, evenim);
            UpdateEventListBox();
        }
        else
        {
            MessageBox.Show("Pentru a sterge un eveniment mai intai trebuie sa-l selectezi", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void buttonHelp_Click_1(object sender, EventArgs e)
    {
        try
        {
            string helpPath = System.IO.Path.Combine(
                System.Environment.CurrentDirectory, "InstantScore.chm");

            if (System.IO.File.Exists(helpPath))
            {
                Help.ShowHelp(this, helpPath);
            }
            else
            {
                MessageBox.Show("Fisierul de ajutor nu a fost gasit.",
                                "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("A aparut o eroare la deschiderea fisierului de ajutor:\n" + ex.Message,
                            "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

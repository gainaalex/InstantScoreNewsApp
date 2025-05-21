namespace InstantScoreNewsApp;

partial class InstantScoreNews
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        buttonLogin = new Button();
        listBox1 = new ListBox();
        listBox2 = new ListBox();
        label1 = new Label();
        buttonAddMeci = new Button();
        buttonModifMeci = new Button();
        buttonElimMeci = new Button();
        buttonAddEvent = new Button();
        buttonModifEvent = new Button();
        buttonElimEvent = new Button();
        groupBox1 = new GroupBox();
        groupBox2 = new GroupBox();
        buttonLogOut = new Button();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        SuspendLayout();
        // 
        // buttonLogin
        // 
        buttonLogin.Location = new Point(549, 12);
        buttonLogin.Name = "buttonLogin";
        buttonLogin.Size = new Size(94, 29);
        buttonLogin.TabIndex = 0;
        buttonLogin.Text = "Login";
        buttonLogin.UseVisualStyleBackColor = true;
        buttonLogin.Click += button1_Click;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.Location = new Point(41, 55);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(346, 324);
        listBox1.TabIndex = 1;
        listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        // 
        // listBox2
        // 
        listBox2.FormattingEnabled = true;
        listBox2.Location = new Point(422, 55);
        listBox2.Name = "listBox2";
        listBox2.Size = new Size(346, 324);
        listBox2.TabIndex = 2;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 16);
        label1.Name = "label1";
        label1.Size = new Size(103, 20);
        label1.TabIndex = 3;
        label1.Text = "Neautentificat";
        // 
        // buttonAddMeci
        // 
        buttonAddMeci.Enabled = false;
        buttonAddMeci.Location = new Point(10, 22);
        buttonAddMeci.Name = "buttonAddMeci";
        buttonAddMeci.Size = new Size(94, 29);
        buttonAddMeci.TabIndex = 4;
        buttonAddMeci.Text = "Adaugare";
        buttonAddMeci.UseVisualStyleBackColor = true;
        buttonAddMeci.Click += buttonAddMeci_Click;
        // 
        // buttonModifMeci
        // 
        buttonModifMeci.Enabled = false;
        buttonModifMeci.Location = new Point(133, 22);
        buttonModifMeci.Name = "buttonModifMeci";
        buttonModifMeci.Size = new Size(94, 29);
        buttonModifMeci.TabIndex = 5;
        buttonModifMeci.Text = "Modificare";
        buttonModifMeci.UseVisualStyleBackColor = true;
        buttonModifMeci.Click += buttonModifMeci_Click;
        // 
        // buttonElimMeci
        // 
        buttonElimMeci.Enabled = false;
        buttonElimMeci.Location = new Point(252, 22);
        buttonElimMeci.Name = "buttonElimMeci";
        buttonElimMeci.Size = new Size(94, 29);
        buttonElimMeci.TabIndex = 6;
        buttonElimMeci.Text = "Eliminare";
        buttonElimMeci.UseVisualStyleBackColor = true;
        buttonElimMeci.Click += buttonElimMeci_Click;
        // 
        // buttonAddEvent
        // 
        buttonAddEvent.Enabled = false;
        buttonAddEvent.Location = new Point(0, 22);
        buttonAddEvent.Name = "buttonAddEvent";
        buttonAddEvent.Size = new Size(94, 29);
        buttonAddEvent.TabIndex = 7;
        buttonAddEvent.Text = "Adaugare";
        buttonAddEvent.UseVisualStyleBackColor = true;
        buttonAddEvent.Click += buttonAddEvent_Click;
        // 
        // buttonModifEvent
        // 
        buttonModifEvent.Enabled = false;
        buttonModifEvent.Location = new Point(127, 22);
        buttonModifEvent.Name = "buttonModifEvent";
        buttonModifEvent.Size = new Size(94, 29);
        buttonModifEvent.TabIndex = 8;
        buttonModifEvent.Text = "Modificare";
        buttonModifEvent.UseVisualStyleBackColor = true;
        buttonModifEvent.Click += buttonModifEvent_Click;
        // 
        // buttonElimEvent
        // 
        buttonElimEvent.Enabled = false;
        buttonElimEvent.Location = new Point(252, 22);
        buttonElimEvent.Name = "buttonElimEvent";
        buttonElimEvent.Size = new Size(94, 29);
        buttonElimEvent.TabIndex = 9;
        buttonElimEvent.Text = "Eliminare";
        buttonElimEvent.UseVisualStyleBackColor = true;
        buttonElimEvent.Click += buttonElimEvent_Click;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(buttonElimMeci);
        groupBox1.Controls.Add(buttonModifMeci);
        groupBox1.Controls.Add(buttonAddMeci);
        groupBox1.Location = new Point(41, 387);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(346, 60);
        groupBox1.TabIndex = 10;
        groupBox1.TabStop = false;
        groupBox1.Text = "Control Meciuri";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(buttonElimEvent);
        groupBox2.Controls.Add(buttonModifEvent);
        groupBox2.Controls.Add(buttonAddEvent);
        groupBox2.Location = new Point(422, 387);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(346, 60);
        groupBox2.TabIndex = 11;
        groupBox2.TabStop = false;
        groupBox2.Text = "Control Evenimente";
        // 
        // buttonLogOut
        // 
        buttonLogOut.Enabled = false;
        buttonLogOut.Location = new Point(674, 12);
        buttonLogOut.Name = "buttonLogOut";
        buttonLogOut.Size = new Size(94, 29);
        buttonLogOut.TabIndex = 12;
        buttonLogOut.Text = "LogOut";
        buttonLogOut.UseVisualStyleBackColor = true;
        buttonLogOut.Click += buttonLogOut_Click;
        // 
        // InstantScoreNews
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(buttonLogOut);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Controls.Add(label1);
        Controls.Add(listBox2);
        Controls.Add(listBox1);
        Controls.Add(buttonLogin);
        Name = "InstantScoreNews";
        Text = "InstantScoreNews";
        groupBox1.ResumeLayout(false);
        groupBox2.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button buttonLogin;
    private ListBox listBox1;
    private ListBox listBox2;
    private Label label1;
    private Button buttonAddMeci;
    private Button buttonModifMeci;
    private Button buttonElimMeci;
    private Button buttonAddEvent;
    private Button buttonModifEvent;
    private Button buttonElimEvent;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private Button buttonLogOut;
}

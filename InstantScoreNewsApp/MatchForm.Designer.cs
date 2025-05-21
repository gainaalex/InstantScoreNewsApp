namespace InstantScoreNewsApp
{
    partial class MatchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxGazda = new TextBox();
            textBoxOaspete = new TextBox();
            textBoxScorG = new TextBox();
            textBoxScorO = new TextBox();
            buttonSend = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // textBoxGazda
            // 
            textBoxGazda.Location = new Point(48, 49);
            textBoxGazda.Name = "textBoxGazda";
            textBoxGazda.Size = new Size(157, 27);
            textBoxGazda.TabIndex = 0;
            // 
            // textBoxOaspete
            // 
            textBoxOaspete.Location = new Point(487, 49);
            textBoxOaspete.Name = "textBoxOaspete";
            textBoxOaspete.Size = new Size(157, 27);
            textBoxOaspete.TabIndex = 1;
            // 
            // textBoxScorG
            // 
            textBoxScorG.Location = new Point(246, 49);
            textBoxScorG.Name = "textBoxScorG";
            textBoxScorG.Size = new Size(71, 27);
            textBoxScorG.TabIndex = 2;
            // 
            // textBoxScorO
            // 
            textBoxScorO.Location = new Point(362, 49);
            textBoxScorO.Name = "textBoxScorO";
            textBoxScorO.Size = new Size(71, 27);
            textBoxScorO.TabIndex = 3;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(298, 109);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(94, 29);
            buttonSend.TabIndex = 4;
            buttonSend.Text = "Trimite";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 26);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 5;
            label1.Text = "Gazda";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(233, 26);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 6;
            label2.Text = "Scor Gazda";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(350, 26);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 7;
            label3.Text = "Scor Oaspete";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(529, 26);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 8;
            label4.Text = "Oaspete";
            // 
            // MatchForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 160);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonSend);
            Controls.Add(textBoxScorO);
            Controls.Add(textBoxScorG);
            Controls.Add(textBoxOaspete);
            Controls.Add(textBoxGazda);
            Name = "MatchForm";
            Text = "Formular de meci";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxGazda;
        private TextBox textBoxOaspete;
        private TextBox textBoxScorG;
        private TextBox textBoxScorO;
        private Button buttonSend;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
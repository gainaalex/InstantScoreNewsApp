namespace InstantScoreNewsApp
{
    partial class EventForm
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
            textBoxMinut = new TextBox();
            textBoxDesc = new TextBox();
            label1 = new Label();
            label2 = new Label();
            buttonSend = new Button();
            SuspendLayout();
            // 
            // textBoxMinut
            // 
            textBoxMinut.Location = new Point(35, 66);
            textBoxMinut.Name = "textBoxMinut";
            textBoxMinut.Size = new Size(46, 27);
            textBoxMinut.TabIndex = 0;
            // 
            // textBoxDesc
            // 
            textBoxDesc.Location = new Point(106, 66);
            textBoxDesc.Name = "textBoxDesc";
            textBoxDesc.Size = new Size(240, 27);
            textBoxDesc.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 43);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 2;
            label1.Text = "Minut";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(106, 43);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 3;
            label2.Text = "Descriere";
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(134, 120);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(94, 29);
            buttonSend.TabIndex = 4;
            buttonSend.Text = "Trimite";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // EventForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 175);
            Controls.Add(buttonSend);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxDesc);
            Controls.Add(textBoxMinut);
            Name = "EventForm";
            Text = "Formular de intamplari";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxMinut;
        private TextBox textBoxDesc;
        private Label label1;
        private Label label2;
        private Button buttonSend;
    }
}
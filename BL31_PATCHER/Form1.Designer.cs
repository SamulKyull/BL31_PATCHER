namespace BL31_PATCHER
{
    partial class Form1
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
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            LoglistBox1 = new ListBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(263, 12);
            button1.Name = "button1";
            button1.Size = new Size(99, 23);
            button1.TabIndex = 0;
            button1.Text = "Open bl31.bin";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(245, 23);
            textBox1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(12, 41);
            button2.Name = "button2";
            button2.Size = new Size(350, 43);
            button2.TabIndex = 2;
            button2.Text = "DO PATCH";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // LoglistBox1
            // 
            LoglistBox1.FormattingEnabled = true;
            LoglistBox1.ItemHeight = 17;
            LoglistBox1.Location = new Point(12, 94);
            LoglistBox1.Name = "LoglistBox1";
            LoglistBox1.Size = new Size(350, 106);
            LoglistBox1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 212);
            Controls.Add(LoglistBox1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "BL31 PACTHER";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private ListBox LoglistBox1;
    }
}

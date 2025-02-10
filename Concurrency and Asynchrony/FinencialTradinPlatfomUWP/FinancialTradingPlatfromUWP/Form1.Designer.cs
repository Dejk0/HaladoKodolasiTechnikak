namespace FinancialTradingPlatfromUWP
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
            Fast = new Button();
            button2 = new Button();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // Fast
            // 
            Fast.Location = new Point(146, 89);
            Fast.Name = "Fast";
            Fast.Size = new Size(145, 23);
            Fast.TabIndex = 0;
            Fast.Text = "fast";
            Fast.UseVisualStyleBackColor = true;
            Fast.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(155, 175);
            button2.Name = "button2";
            button2.Size = new Size(126, 23);
            button2.TabIndex = 1;
            button2.Text = "CPU BOUND";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(413, 72);
            listView1.Name = "listView1";
            listView1.Size = new Size(353, 303);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(button2);
            Controls.Add(Fast);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button Fast;
        private Button button2;
        private ListView listView1;
    }
}

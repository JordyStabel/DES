namespace DES_Jordy_Stabel
{
    partial class Form1
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
        /// Required method for Designer support, do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_Key = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Message = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_KeyBinary = new System.Windows.Forms.Label();
            this.lb_MessageBinary = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Calculate = new System.Windows.Forms.Button();
            this.lb_MessageHex = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_KeyHex = new System.Windows.Forms.Label();
            this.label_8 = new System.Windows.Forms.Label();
            this.lb_FirstKey = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_D0 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_C0 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_Key
            // 
            this.tb_Key.Location = new System.Drawing.Point(135, 24);
            this.tb_Key.Name = "tb_Key";
            this.tb_Key.Size = new System.Drawing.Size(126, 20);
            this.tb_Key.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Message:";
            // 
            // tb_Message
            // 
            this.tb_Message.Location = new System.Drawing.Point(135, 63);
            this.tb_Message.Name = "tb_Message";
            this.tb_Message.Size = new System.Drawing.Size(126, 20);
            this.tb_Message.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Key Binary:";
            // 
            // lb_KeyBinary
            // 
            this.lb_KeyBinary.AutoSize = true;
            this.lb_KeyBinary.Location = new System.Drawing.Point(135, 151);
            this.lb_KeyBinary.Name = "lb_KeyBinary";
            this.lb_KeyBinary.Size = new System.Drawing.Size(19, 13);
            this.lb_KeyBinary.TabIndex = 5;
            this.lb_KeyBinary.Text = "....";
            // 
            // lb_MessageBinary
            // 
            this.lb_MessageBinary.AutoSize = true;
            this.lb_MessageBinary.Location = new System.Drawing.Point(135, 173);
            this.lb_MessageBinary.Name = "lb_MessageBinary";
            this.lb_MessageBinary.Size = new System.Drawing.Size(19, 13);
            this.lb_MessageBinary.TabIndex = 7;
            this.lb_MessageBinary.Text = "....";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Message Binary:";
            // 
            // btn_Calculate
            // 
            this.btn_Calculate.Location = new System.Drawing.Point(1250, 699);
            this.btn_Calculate.Name = "btn_Calculate";
            this.btn_Calculate.Size = new System.Drawing.Size(126, 23);
            this.btn_Calculate.TabIndex = 8;
            this.btn_Calculate.Text = "Calculate!";
            this.btn_Calculate.UseVisualStyleBackColor = true;
            this.btn_Calculate.Click += new System.EventHandler(this.Btn_Calculate_Click);
            // 
            // lb_MessageHex
            // 
            this.lb_MessageHex.AutoSize = true;
            this.lb_MessageHex.Location = new System.Drawing.Point(135, 120);
            this.lb_MessageHex.Name = "lb_MessageHex";
            this.lb_MessageHex.Size = new System.Drawing.Size(19, 13);
            this.lb_MessageHex.TabIndex = 12;
            this.lb_MessageHex.Text = "....";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Message Binary:";
            // 
            // lb_KeyHex
            // 
            this.lb_KeyHex.AutoSize = true;
            this.lb_KeyHex.Location = new System.Drawing.Point(135, 98);
            this.lb_KeyHex.Name = "lb_KeyHex";
            this.lb_KeyHex.Size = new System.Drawing.Size(19, 13);
            this.lb_KeyHex.TabIndex = 10;
            this.lb_KeyHex.Text = "....";
            // 
            // label_8
            // 
            this.label_8.AutoSize = true;
            this.label_8.Location = new System.Drawing.Point(69, 98);
            this.label_8.Name = "label_8";
            this.label_8.Size = new System.Drawing.Size(50, 13);
            this.label_8.TabIndex = 9;
            this.label_8.Text = "Key Hex:";
            // 
            // lb_FirstKey
            // 
            this.lb_FirstKey.AutoSize = true;
            this.lb_FirstKey.Location = new System.Drawing.Point(135, 230);
            this.lb_FirstKey.Name = "lb_FirstKey";
            this.lb_FirstKey.Size = new System.Drawing.Size(19, 13);
            this.lb_FirstKey.TabIndex = 16;
            this.lb_FirstKey.Text = "....";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "First Key:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(135, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(796, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "57-49-41-33-25-17-9-1-58-50-42-34-26-18-10-2-59-51-43-35-27-19-11-3-60-52-44-36-6" +
    "3-55-47-39-31-23-15-7-62-54-46-38-30-22-14-6-61-53-45-37-29-21-13-5-28-20-12-4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Key Permutation:";
            // 
            // lb_D0
            // 
            this.lb_D0.AutoSize = true;
            this.lb_D0.Location = new System.Drawing.Point(135, 288);
            this.lb_D0.Name = "lb_D0";
            this.lb_D0.Size = new System.Drawing.Size(19, 13);
            this.lb_D0.TabIndex = 20;
            this.lb_D0.Text = "....";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(95, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "D0:";
            // 
            // lb_C0
            // 
            this.lb_C0.AutoSize = true;
            this.lb_C0.Location = new System.Drawing.Point(135, 266);
            this.lb_C0.Name = "lb_C0";
            this.lb_C0.Size = new System.Drawing.Size(19, 13);
            this.lb_C0.TabIndex = 18;
            this.lb_C0.Text = "....";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(96, 266);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "C0:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 734);
            this.Controls.Add(this.lb_D0);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lb_C0);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lb_FirstKey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lb_MessageHex);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_KeyHex);
            this.Controls.Add(this.label_8);
            this.Controls.Add(this.btn_Calculate);
            this.Controls.Add(this.lb_MessageBinary);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_KeyBinary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Message);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Key);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Message;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_KeyBinary;
        private System.Windows.Forms.Label lb_MessageBinary;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Calculate;
        private System.Windows.Forms.Label lb_MessageHex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_KeyHex;
        private System.Windows.Forms.Label label_8;
        private System.Windows.Forms.Label lb_FirstKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_D0;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lb_C0;
        private System.Windows.Forms.Label label12;
    }
}


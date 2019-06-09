namespace lab2_3
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.search_spaces = new System.Windows.Forms.TextBox();
            this.search_capacity = new System.Windows.Forms.TextBox();
            this.search_type = new System.Windows.Forms.ComboBox();
            this.search_company = new System.Windows.Forms.TextBox();
            this.search_bt = new System.Windows.Forms.Button();
            this.clear_bt = new System.Windows.Forms.Button();
            this.search_result = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.search_spaces);
            this.groupBox1.Controls.Add(this.search_capacity);
            this.groupBox1.Controls.Add(this.search_type);
            this.groupBox1.Controls.Add(this.search_company);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 219);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "what do u want to find?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Airplane\'s load-carrying capacity (kg)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Count of spaces";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Airplane\'s type";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Airplane company name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // search_spaces
            // 
            this.search_spaces.Location = new System.Drawing.Point(139, 178);
            this.search_spaces.Name = "search_spaces";
            this.search_spaces.Size = new System.Drawing.Size(116, 23);
            this.search_spaces.TabIndex = 3;
            // 
            // search_capacity
            // 
            this.search_capacity.Location = new System.Drawing.Point(10, 133);
            this.search_capacity.Name = "search_capacity";
            this.search_capacity.Size = new System.Drawing.Size(116, 23);
            this.search_capacity.TabIndex = 2;
            // 
            // search_type
            // 
            this.search_type.FormattingEnabled = true;
            this.search_type.Location = new System.Drawing.Point(139, 83);
            this.search_type.Name = "search_type";
            this.search_type.Size = new System.Drawing.Size(116, 23);
            this.search_type.TabIndex = 1;
            // 
            // search_company
            // 
            this.search_company.Location = new System.Drawing.Point(10, 46);
            this.search_company.Name = "search_company";
            this.search_company.Size = new System.Drawing.Size(116, 23);
            this.search_company.TabIndex = 0;
            // 
            // search_bt
            // 
            this.search_bt.BackColor = System.Drawing.Color.PowderBlue;
            this.search_bt.Location = new System.Drawing.Point(65, 239);
            this.search_bt.Name = "search_bt";
            this.search_bt.Size = new System.Drawing.Size(75, 23);
            this.search_bt.TabIndex = 1;
            this.search_bt.Text = "Search";
            this.search_bt.UseVisualStyleBackColor = false;
            this.search_bt.Click += new System.EventHandler(this.search_bt_Click);
            // 
            // clear_bt
            // 
            this.clear_bt.BackColor = System.Drawing.Color.PowderBlue;
            this.clear_bt.Location = new System.Drawing.Point(164, 239);
            this.clear_bt.Name = "clear_bt";
            this.clear_bt.Size = new System.Drawing.Size(75, 23);
            this.clear_bt.TabIndex = 2;
            this.clear_bt.Text = "Clear";
            this.clear_bt.UseVisualStyleBackColor = false;
            this.clear_bt.Click += new System.EventHandler(this.clear_bt_Click);
            // 
            // search_result
            // 
            this.search_result.FormattingEnabled = true;
            this.search_result.ItemHeight = 15;
            this.search_result.Location = new System.Drawing.Point(14, 268);
            this.search_result.Name = "search_result";
            this.search_result.Size = new System.Drawing.Size(299, 109);
            this.search_result.TabIndex = 3;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(335, 399);
            this.Controls.Add(this.search_result);
            this.Controls.Add(this.clear_bt);
            this.Controls.Add(this.search_bt);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form2";
            this.Text = "Search";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox search_company;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox search_spaces;
        private System.Windows.Forms.TextBox search_capacity;
        private System.Windows.Forms.ComboBox search_type;
        private System.Windows.Forms.Button search_bt;
        private System.Windows.Forms.Button clear_bt;
        private System.Windows.Forms.ListBox search_result;
    }
}
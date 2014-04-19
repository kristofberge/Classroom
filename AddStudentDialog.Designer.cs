namespace Classroom
{
    partial class AddStudentDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddStudName = new System.Windows.Forms.TextBox();
            this.nudAddStudGrade = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudAddStudHeight = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbAddStudClass = new System.Windows.Forms.ComboBox();
            this.bAddStud = new System.Windows.Forms.Button();
            this.bAddStudCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddStudGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddStudHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Grade:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Height:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Class";
            // 
            // txtAddStudName
            // 
            this.txtAddStudName.Location = new System.Drawing.Point(70, 12);
            this.txtAddStudName.Name = "txtAddStudName";
            this.txtAddStudName.Size = new System.Drawing.Size(195, 20);
            this.txtAddStudName.TabIndex = 4;
            // 
            // nudAddStudGrade
            // 
            this.nudAddStudGrade.DecimalPlaces = 1;
            this.nudAddStudGrade.Location = new System.Drawing.Point(70, 44);
            this.nudAddStudGrade.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudAddStudGrade.Name = "nudAddStudGrade";
            this.nudAddStudGrade.Size = new System.Drawing.Size(48, 20);
            this.nudAddStudGrade.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "/10";
            // 
            // nudAddStudHeight
            // 
            this.nudAddStudHeight.Location = new System.Drawing.Point(70, 75);
            this.nudAddStudHeight.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudAddStudHeight.Name = "nudAddStudHeight";
            this.nudAddStudHeight.Size = new System.Drawing.Size(69, 20);
            this.nudAddStudHeight.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(141, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "cm";
            // 
            // cmbAddStudClass
            // 
            this.cmbAddStudClass.FormattingEnabled = true;
            this.cmbAddStudClass.Location = new System.Drawing.Point(70, 105);
            this.cmbAddStudClass.Name = "cmbAddStudClass";
            this.cmbAddStudClass.Size = new System.Drawing.Size(92, 21);
            this.cmbAddStudClass.TabIndex = 9;
            // 
            // bAddStud
            // 
            this.bAddStud.Location = new System.Drawing.Point(70, 138);
            this.bAddStud.Name = "bAddStud";
            this.bAddStud.Size = new System.Drawing.Size(75, 23);
            this.bAddStud.TabIndex = 10;
            this.bAddStud.Text = "Add";
            this.bAddStud.UseVisualStyleBackColor = true;
            this.bAddStud.Click += new System.EventHandler(this.bAddStud_Click);
            // 
            // bAddStudCancel
            // 
            this.bAddStudCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bAddStudCancel.Location = new System.Drawing.Point(190, 138);
            this.bAddStudCancel.Name = "bAddStudCancel";
            this.bAddStudCancel.Size = new System.Drawing.Size(75, 23);
            this.bAddStudCancel.TabIndex = 11;
            this.bAddStudCancel.Text = "Cancel";
            this.bAddStudCancel.UseVisualStyleBackColor = true;
            // 
            // AddStudentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 173);
            this.Controls.Add(this.bAddStudCancel);
            this.Controls.Add(this.bAddStud);
            this.Controls.Add(this.cmbAddStudClass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudAddStudHeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudAddStudGrade);
            this.Controls.Add(this.txtAddStudName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddStudentDialog";
            this.Text = "Add Student";
            ((System.ComponentModel.ISupportInitialize)(this.nudAddStudGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddStudHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddStudName;
        private System.Windows.Forms.NumericUpDown nudAddStudGrade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudAddStudHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAddStudClass;
        private System.Windows.Forms.Button bAddStud;
        private System.Windows.Forms.Button bAddStudCancel;
    }
}
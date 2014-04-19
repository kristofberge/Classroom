namespace Classroom
{
    partial class EditStudentDialog
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
            this.bAddStudCancel = new System.Windows.Forms.Button();
            this.bEditStud = new System.Windows.Forms.Button();
            this.cmbEditStudClass = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudEditStudHeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudEditStudGrade = new System.Windows.Forms.NumericUpDown();
            this.txtEditStudName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClassList = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbStudents = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditStudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditStudGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // bAddStudCancel
            // 
            this.bAddStudCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bAddStudCancel.Location = new System.Drawing.Point(186, 216);
            this.bAddStudCancel.Name = "bAddStudCancel";
            this.bAddStudCancel.Size = new System.Drawing.Size(75, 23);
            this.bAddStudCancel.TabIndex = 23;
            this.bAddStudCancel.Text = "Cancel";
            this.bAddStudCancel.UseVisualStyleBackColor = true;
            // 
            // bEditStud
            // 
            this.bEditStud.Location = new System.Drawing.Point(66, 216);
            this.bEditStud.Name = "bEditStud";
            this.bEditStud.Size = new System.Drawing.Size(75, 23);
            this.bEditStud.TabIndex = 22;
            this.bEditStud.Text = "Edit";
            this.bEditStud.UseVisualStyleBackColor = true;
            this.bEditStud.Click += new System.EventHandler(this.bEditStud_Click);
            // 
            // cmbEditStudClass
            // 
            this.cmbEditStudClass.FormattingEnabled = true;
            this.cmbEditStudClass.Location = new System.Drawing.Point(66, 183);
            this.cmbEditStudClass.Name = "cmbEditStudClass";
            this.cmbEditStudClass.Size = new System.Drawing.Size(92, 21);
            this.cmbEditStudClass.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "cm";
            // 
            // nudEditStudHeight
            // 
            this.nudEditStudHeight.Location = new System.Drawing.Point(66, 153);
            this.nudEditStudHeight.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudEditStudHeight.Name = "nudEditStudHeight";
            this.nudEditStudHeight.Size = new System.Drawing.Size(69, 20);
            this.nudEditStudHeight.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "/10";
            // 
            // nudEditStudGrade
            // 
            this.nudEditStudGrade.DecimalPlaces = 1;
            this.nudEditStudGrade.Location = new System.Drawing.Point(66, 122);
            this.nudEditStudGrade.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudEditStudGrade.Name = "nudEditStudGrade";
            this.nudEditStudGrade.Size = new System.Drawing.Size(48, 20);
            this.nudEditStudGrade.TabIndex = 17;
            // 
            // txtEditStudName
            // 
            this.txtEditStudName.Location = new System.Drawing.Point(66, 90);
            this.txtEditStudName.Name = "txtEditStudName";
            this.txtEditStudName.Size = new System.Drawing.Size(211, 20);
            this.txtEditStudName.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Class";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Height:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Grade:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name:";
            // 
            // cmbClassList
            // 
            this.cmbClassList.FormattingEnabled = true;
            this.cmbClassList.Location = new System.Drawing.Point(115, 6);
            this.cmbClassList.Name = "cmbClassList";
            this.cmbClassList.Size = new System.Drawing.Size(75, 21);
            this.cmbClassList.TabIndex = 25;
            this.cmbClassList.SelectedIndexChanged += new System.EventHandler(this.cmbClassList_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Select class:";
            // 
            // cmbStudents
            // 
            this.cmbStudents.FormattingEnabled = true;
            this.cmbStudents.Location = new System.Drawing.Point(115, 42);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new System.Drawing.Size(162, 21);
            this.cmbStudents.TabIndex = 27;
            this.cmbStudents.SelectedIndexChanged += new System.EventHandler(this.cmbStudents_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Select Student:";
            // 
            // EditStudentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 255);
            this.Controls.Add(this.cmbStudents);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbClassList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bAddStudCancel);
            this.Controls.Add(this.bEditStud);
            this.Controls.Add(this.cmbEditStudClass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudEditStudHeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudEditStudGrade);
            this.Controls.Add(this.txtEditStudName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditStudentDialog";
            this.Text = "Edit Sudent";
            ((System.ComponentModel.ISupportInitialize)(this.nudEditStudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditStudGrade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAddStudCancel;
        private System.Windows.Forms.Button bEditStud;
        private System.Windows.Forms.ComboBox cmbEditStudClass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudEditStudHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudEditStudGrade;
        private System.Windows.Forms.TextBox txtEditStudName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClassList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStudents;
        private System.Windows.Forms.Label label8;
    }
}
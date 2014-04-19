namespace Classroom
{
    partial class AddClassDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddClassName = new System.Windows.Forms.TextBox();
            this.bAddClass = new System.Windows.Forms.Button();
            this.bCancelClass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // txtAddClassName
            // 
            this.txtAddClassName.Location = new System.Drawing.Point(56, 18);
            this.txtAddClassName.Name = "txtAddClassName";
            this.txtAddClassName.Size = new System.Drawing.Size(113, 20);
            this.txtAddClassName.TabIndex = 2;
            // 
            // bAddClass
            // 
            this.bAddClass.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bAddClass.Location = new System.Drawing.Point(15, 54);
            this.bAddClass.Name = "bAddClass";
            this.bAddClass.Size = new System.Drawing.Size(75, 23);
            this.bAddClass.TabIndex = 3;
            this.bAddClass.Text = "Add";
            this.bAddClass.UseVisualStyleBackColor = true;
            this.bAddClass.Click += new System.EventHandler(this.bAddClass_Click);
            // 
            // bCancelClass
            // 
            this.bCancelClass.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelClass.Location = new System.Drawing.Point(94, 54);
            this.bCancelClass.Name = "bCancelClass";
            this.bCancelClass.Size = new System.Drawing.Size(75, 23);
            this.bCancelClass.TabIndex = 4;
            this.bCancelClass.Text = "Cancel";
            this.bCancelClass.UseVisualStyleBackColor = true;
            // 
            // AddClassDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 93);
            this.Controls.Add(this.bCancelClass);
            this.Controls.Add(this.bAddClass);
            this.Controls.Add(this.txtAddClassName);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddClassDialog";
            this.Text = "Add a class";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddClassName;
        private System.Windows.Forms.Button bAddClass;
        private System.Windows.Forms.Button bCancelClass;
    }
}
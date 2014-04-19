namespace Classroom
{
    partial class EditClassDialog
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
            this.bCancelClass = new System.Windows.Forms.Button();
            this.bEditClass = new System.Windows.Forms.Button();
            this.txtEditClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClassList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bCancelClass
            // 
            this.bCancelClass.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelClass.Location = new System.Drawing.Point(102, 96);
            this.bCancelClass.Name = "bCancelClass";
            this.bCancelClass.Size = new System.Drawing.Size(75, 23);
            this.bCancelClass.TabIndex = 8;
            this.bCancelClass.Text = "Cancel";
            this.bCancelClass.UseVisualStyleBackColor = true;
            // 
            // bEditClass
            // 
            this.bEditClass.Location = new System.Drawing.Point(23, 96);
            this.bEditClass.Name = "bEditClass";
            this.bEditClass.Size = new System.Drawing.Size(75, 23);
            this.bEditClass.TabIndex = 7;
            this.bEditClass.Text = "Edit";
            this.bEditClass.UseVisualStyleBackColor = true;
            this.bEditClass.Click += new System.EventHandler(this.bEditClass_Click);
            // 
            // txtEditClassName
            // 
            this.txtEditClassName.Location = new System.Drawing.Point(64, 60);
            this.txtEditClassName.Name = "txtEditClassName";
            this.txtEditClassName.Size = new System.Drawing.Size(113, 20);
            this.txtEditClassName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select class:";
            // 
            // cmbClassList
            // 
            this.cmbClassList.FormattingEnabled = true;
            this.cmbClassList.Location = new System.Drawing.Point(102, 17);
            this.cmbClassList.Name = "cmbClassList";
            this.cmbClassList.Size = new System.Drawing.Size(75, 21);
            this.cmbClassList.TabIndex = 10;
            this.cmbClassList.SelectedIndexChanged += new System.EventHandler(this.cmbClassList_SelectedIndexChanged);
            // 
            // EditClassDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 147);
            this.Controls.Add(this.cmbClassList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCancelClass);
            this.Controls.Add(this.bEditClass);
            this.Controls.Add(this.txtEditClassName);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditClassDialog";
            this.Text = "Edit Class";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancelClass;
        private System.Windows.Forms.Button bEditClass;
        private System.Windows.Forms.TextBox txtEditClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClassList;
    }
}
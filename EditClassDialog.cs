using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classroom
{
    public partial class EditClassDialog : Form
    {
        public enum Action
        {
            Edit,
            Delete
        };

        private Class selectedClass;

        private Class _editClass;

        public Class editClass
        {
            get { return _editClass; }
            set { _editClass = value; }
        }
        

        public EditClassDialog(List<Class> classList, Action action)
        {
            InitializeComponent();
            this.Text = action + " class";
            bEditClass.Text = action.ToString();
            foreach (Class c in classList)
            {
                cmbClassList.Items.Add(c);
            }
            cmbClassList.SelectedIndex = -1;
        }

        private void cmbClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedClass=  (Class) ((ComboBox)sender).SelectedItem;
            txtEditClassName.Text = selectedClass.name;
        }

        private void bEditClass_Click(object sender, EventArgs e)
        {
            if (txtEditClassName.Text != "")
            {
                _editClass = selectedClass;
                _editClass.name = txtEditClassName.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else 
            {
                MessageBox.Show("Fill in a name.");
            }
        }

 


    }
}

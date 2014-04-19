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
    public partial class AddStudentDialog : Form
    {
        private Student _newStud;

        private string name;
        private double grade;
        private int height;
        private Class studClass;

        public Student newStud
        {
            get { return _newStud; }
            set { _newStud = value; }
        }

        public AddStudentDialog(List<Class> classList)
        {
            InitializeComponent();
            foreach(Class c in classList){
                cmbAddStudClass.Items.Add(c);
            }
            cmbAddStudClass.SelectedIndex = -1;
        }

        private void bAddStud_Click(object sender, EventArgs e)
        {
            if (checkAndGetValues())
            {
                _newStud = new Student(0, name, grade, height, studClass);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else 
            { 
                MessageBox.Show("Fill in all required fields");
            }
        }

        private bool checkAndGetValues()
        {
            if(txtAddStudName.Text!=""
                && cmbAddStudClass.SelectedIndex!=-1
                && cmbAddStudClass.Text!=""
                && cmbAddStudClass.SelectedItem!=null){

                name = txtAddStudName.Text;
                grade = Convert.ToDouble(nudAddStudGrade.Value);
                Console.WriteLine("height:" + nudAddStudHeight.Value);
                height = Convert.ToInt32(nudAddStudHeight.Value);
                studClass = (Class)cmbAddStudClass.SelectedItem;
                return true;
            }
            return false;
        }




    }
}

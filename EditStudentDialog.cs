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
    public partial class EditStudentDialog : Form
    {
        public enum Action
        {
            Edit,
            Delete
        };

        private Class _selectedClass;
        private AbstractHelper _helper;
        private Student selectedStud;

        private Student _editStudent;

        public Student editStudent
        {
            get { return _editStudent; }
            set { _editStudent = value; }
        }


        public EditStudentDialog(List<Class> classList, AbstractHelper helper, Action action)
        {
            InitializeComponent();
            this._helper = helper;
            this.Text = action + " student";
            bEditStud.Text = action.ToString();
            foreach (Class c in classList)
            {
                cmbClassList.Items.Add(c);
                cmbEditStudClass.Items.Add(c);
            }
            cmbClassList.SelectedIndex = -1;
        }

        private void cmbClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedClass = (Class)((ComboBox)sender).SelectedItem;
            FillStudents(_helper.GetStudentsInClass(_selectedClass));
        }

        private void FillStudents(List<Student> studentsList) {
            cmbStudents.Items.Clear();
            foreach (Student s in studentsList){
                cmbStudents.Items.Add(s);
            }
            cmbStudents.SelectedIndex = -1;
        }

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedStud = (Student) ((ComboBox)sender).SelectedItem;
            txtEditStudName.Text = selectedStud.name;
            nudEditStudGrade.Value = Convert.ToDecimal(selectedStud.grade);
            nudEditStudHeight.Value = selectedStud.height;
            cmbEditStudClass.SelectedItem = selectedStud.class_id;
        }

        private void bEditStud_Click(object sender, EventArgs e)
        {
            if (txtEditStudName.Text != ""
                && cmbEditStudClass.SelectedIndex>-1
                && cmbEditStudClass.SelectedItem!=null
                && cmbEditStudClass.Text!="")
            {
                _editStudent = new Student(
                    selectedStud.id,
                    txtEditStudName.Text,
                    (double)nudEditStudGrade.Value,
                    (int)nudEditStudHeight.Value,
                    (Class)cmbEditStudClass.SelectedItem);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Fill in all required fields.");
            }
        }
        
    }
}

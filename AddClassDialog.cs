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
    public partial class AddClassDialog : Form
    {
        public AddClassDialog()
        {
            InitializeComponent();
        }

        private Class _newClass;

        public Class newClass
        {
            get { return _newClass; }
            set { _newClass = value; }
        }


        private void bAddClass_Click(object sender, EventArgs e)
        {
            _newClass = new Class(0, txtAddClassName.Text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Classroom
{
    public partial class MainForm : Form
    {
        AbstractHelper helper;

        private const string EMPTY_SEAT = "Empty seat";
        private const string SELECTEDLABEL_TEXT = "Selected class: ";
        private const string SELECTEDLABEL_DEFAULT = "No class selected.";

        private const string MSG_CLASSROOM_SIZE = "There are too many students for this classroom.";
        private const string MSG_NO_CLASS = "No class selected.";
        private const string MSG_VALUES_MISSING = "Fill in all required fields.";
        private const string ERROR_TITLE = "Unable to create classroom.";
        private const string MSG_EMPTY_CLASS = "There are no students in this classroom.";
        private const string DB_OP_RES_TITLE = "Database operation result.";
        private const string MSG_CLASS_ADD_OK = "Class insert SUCCESFUL.";
        private const string MSG_CLASS_ADD_NOK = "Class insert FAILED.";
        private const string MSG_CLASS_EDIT_OK = "Class edit SUCCESFUL.";
        private const string MSG_CLASS_EDIT_NOK = "Class edit FAILED.";
        private const string MSG_CLASS_DEL_OK = "Class delete SUCCESFUL.";
        private const string MSG_CLASS_DEL_NOK = "Class delete FAILED.";
        private const string MSG_STUD_ADD_OK = "Student insert SUCCESFUL.";
        private const string MSG_STUD_ADD_NOK = "Student insert FAILED.";
        private const string MSG_STUD_EDIT_OK = "Student edit SUCCESFUL.";
        private const string MSG_STUD_EDIT_NOK = "Student edit FAILED.";
        private const string MSG_STUD_DEL_OK = "Student delete SUCCESFUL.";
        private const string MSG_STUD_DEL_NOK = "Student delete FAILED.";

        private const string LBLSELECTEDXML_DEFAULT = "Database selected.";
        private const string LBLSELECTEDXML_SELECTED = "Selected file: ";
        private const string LBLSELECTEDNETWORK = "Network selected.";

        private int classRoomRows, amountOfStudents, classRoomColumns, MaxSwaps, MinHeightDifference;
        private AbstractStudentDistributor studDist;
        private List<Student> students;
        private Student[,] classroom;
        private Label clickedLabel;
        private List<Label> lblList;

        private List<Class> classList;

        private String xmlUri = null;

        Class selectedClass;
        
         public MainForm()
        {
            InitializeComponent();
            SetDatabaseAsSource();
            FillClassesCmb();
        }


        

        private void BDistGrade_Click(object sender, EventArgs e)
        {
            ResetClassroom();
            GetValues();
            studDist = new StudentDistributorGrade(classRoomRows, classRoomColumns);
            PrepareClassroom();
          
        }


        private void GetValues()
        { // Get the values from the 3 left fields.
            if (txtAmountOfStudents.Text != ""
                && txtRows.Text != ""
                && txtColumns.Text != "")
            {
                
                amountOfStudents = Convert.ToInt32(txtAmountOfStudents.Text);
                classRoomRows = Convert.ToInt32(txtRows.Text);
                classRoomColumns = Convert.ToInt32(txtColumns.Text);
            }
            else
            {
                MessageBox.Show(MSG_VALUES_MISSING, ERROR_TITLE);
            }
        }

        private void PrepareClassroom() {
            // Fill in the classroom table.
            if (students != null) // If the students array is not initialized.
            {
                if (students.Count > 0) // If there are no students in this classroom.
                {
                    if (classRoomRows * classRoomColumns >= amountOfStudents) // If the classroom is too small.
                    {
                        classroom = studDist.createClassroom(students);
                        ShowClassroom(classroom);
                    }
                    else
                    {
                        MessageBox.Show(MSG_CLASSROOM_SIZE, ERROR_TITLE);
                    }
                }
                else 
                {
                    MessageBox.Show(MSG_EMPTY_CLASS, ERROR_TITLE);
                }
            }
            else
            {
                MessageBox.Show(MSG_NO_CLASS, ERROR_TITLE);
            }
        }

        private void ShowClassroom(Student[,] classroom)
        { // Generate the lables to display the classroom.
            
            // Variables used to calculate the position and size of each label.
            int lineHeight = 15;
            int lblWidth = 150;
            int lblVerticalOffset = 180;
            int lblHorizontalOffset = 20;
            int lblMargin = 20;


            lblList = new List<Label>(); // The list of lalbels.
            
            // Iterate through the classroom.
            for (int r = 0; r < classRoomRows; r++)
            {
                for (int c = 0; c < classRoomColumns; c++)
                {
                    Student current = classroom[r, c]; // The currently selected student.
                    Label lblStudent = new Label(); // Create a new label.
                    lblStudent.Height = lineHeight * 3;                 // Set label height...
                    lblStudent.Width = lblWidth;                        // ,width...
                    lblStudent.BorderStyle = BorderStyle.FixedSingle;   // and border.

                    if (current != null)
                    { // Fill in te label with information from the Student.
                        lblStudent.Text = current.name + "\n" + current.grade + "/10\n" + current.height + "cm";
                    }
                    else 
                    { // Fill in an Empty Seat.
                        lblStudent.Text = EMPTY_SEAT;
                    }

                    // Set th label's position.
                    lblStudent.Location = new Point(c * (lblWidth + lblMargin) + lblHorizontalOffset, r * lineHeight * 4 + lblVerticalOffset);

                    lblStudent.Click += new EventHandler(StudentLabel_Click); // Set the EventHandler for when the label is clicked.

                    lblList.Add(lblStudent);        // Add the label to the List...
                    this.Controls.Add(lblStudent);  // and to the Form.
                }
            }
        }

        private void StudentLabel_Click(object sender, EventArgs e) {
            if (clickedLabel == null)
            { // If clickedLabel is null, this is the first label that is clicked.
                clickedLabel = (Label)sender; // Keep a reference to the clicked label.
                SetClicked(clickedLabel); // Change the layout.
            }
            else { // If this is the 2nd label clicked.
                // Get the List indexes of both labels.
                // We need these later.
                int indexClicked = lblList.IndexOf(clickedLabel); // Index of the 1st clicked label.
                int indexSender = lblList.IndexOf((Label)sender); // Index of the 2nd clicked label.

                if (indexClicked != indexSender)
                {   // If two different labels were clicked, we need to swap them
                    // AND the Students in the classroom array.

                    // First we need to convert the linear indexes from the label List
                    // to two-dimensional indexes we can use in the classroom array.
                    int rowClicked = 0, rowSend = 0, colClicked = 0, colSend = 0;

                    // Calculate the row of the 1st clicked label.
                    int help = indexClicked;
                    while (help >= classRoomColumns)
                    {
                        help -= classRoomColumns;
                        rowClicked++;
                    }
                    Console.WriteLine("rowClicked: " + rowClicked);

                    // Calculate the column of the 1st clicked label.
                    help = indexClicked;
                    while (help >= classRoomColumns)
                    {
                        help -= classRoomColumns;
                    }
                    colClicked = help;
                    Console.WriteLine("colClicked: " + colClicked);

                    // Calculate the row of the 2nd clicked label.
                    help = indexSender;
                    while (help >= classRoomColumns)
                    {
                        help -= classRoomColumns;
                        rowSend++;
                    }
                    Console.WriteLine("rowSend: " + rowSend);

                    // Calculate the column of the 2nd clicked label.
                    help = indexSender;
                    while (help >= classRoomColumns)
                    {
                        help -= classRoomColumns;
                    }
                    colSend = help;
                    Console.WriteLine("colSend: " + colSend);
                    Console.WriteLine("----------------------------");

                    // Swap the texts of the 2 labels.
                    Label helpLbl = lblList.ElementAt(indexSender);
                    Student helpStud = classroom[rowClicked, colClicked];
                    if (helpStud != null) // This if avoids a NullPointerException in case the seat is empty.
                    {
                        helpLbl.Text = helpStud.name + "\n" + helpStud.grade + "/10\n" + helpStud.height + "cm";
                    }
                    else {
                        helpLbl.Text = EMPTY_SEAT;
                    }

                    helpLbl = lblList.ElementAt(indexClicked);
                    helpStud = classroom[rowSend, colSend];
                    if (helpStud != null) // This if avoids a NullPointerException in case the seat is empty.
                    {
                        helpLbl.Text = helpStud.name + "\n" + helpStud.grade + "/10\n" + helpStud.height + "cm";
                    }
                    else
                    {
                        helpLbl.Text = EMPTY_SEAT;
                    }
                    SetUnclicked(helpLbl);

                    // Swap the Students in the classroom array.
                    helpStud = classroom[rowClicked, colClicked];
                    classroom[rowClicked, colClicked] = classroom[rowSend, colSend];
                    classroom[rowSend, colSend] = helpStud;
                }
                else {
                    // If the same label is clicked again, unselect it.
                    SetUnclicked(lblList.ElementAt(indexClicked));
                }

                clickedLabel = null;
                
            }
        }

        private void SetClicked(Label label)
        {   // Make the label look "clicked".
            label.BorderStyle = BorderStyle.Fixed3D;
            label.ForeColor = Color.Crimson;
            label.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
        }

        private void SetUnclicked(Label label)
        {   // Make the label look "normal".
            label.BorderStyle = BorderStyle.FixedSingle;
            label.ForeColor = Color.Black;
            label.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        }

        private void bDistHeight_Click(object sender, EventArgs e)
        {
            ResetClassroom();
            GetValues();
            // Define the distributor as a StudentDistributorHeight
            studDist = new StudentDistributorHeight(classRoomRows, classRoomColumns);
            PrepareClassroom();
        }

        private void bDistSmart_Click(object sender, EventArgs e)
        {
            ResetClassroom();
            GetValues();
            GetExtraValues(); // We need to get the values from the fields on the left as well.

            // Define the distributor as a StudentDistributorSmart
            studDist = new StudentDistributorSmart(classRoomRows, classRoomColumns, MaxSwaps, MinHeightDifference);
            PrepareClassroom();
        }

        private void GetExtraValues()
        { // Get the values from the fields on the left as well.
          // If the fields are empty, enter 0.

            if (txtMaxSwaps.Text != "")
            {
                MaxSwaps = Convert.ToInt32(txtMaxSwaps.Text);
            }
            else 
            {
                MaxSwaps = 0;
                txtMaxSwaps.Text = "0";
            }



            if (txtMinHeight.Text != "")
            {
                MinHeightDifference = Convert.ToInt32(txtMinHeight.Text);
            }
            else
            {
                MinHeightDifference = 0;
                txtMinHeight.Text = "0";
            }
        }




        private void ResetClassroom()
        { // Remove the classroom labels from the Form and clear the label List.
            try
            {
                foreach (Label l in lblList)
                {
                    if (l != null)
                    {
                        this.Controls.Remove(l);
                    }
                }
                lblList.Clear();
            }
            catch (NullReferenceException)
            { }
     

        }

        private void ResetData()
        { // Clear all the data (except classes List) and empty the textfields.

            classroom = null;
            studDist = null;
            students = null;

            amountOfStudents = 0;
            classRoomRows = 0;
            classRoomColumns = 0;

            txtAmountOfStudents.Text = "";
            txtColumns.Text = "";
            txtMaxSwaps.Text = "";
            txtMinHeight.Text = "";
            txtRows.Text = "";
            cmbClasses.Text = "";

            lblSelectedClass.Text = SELECTEDLABEL_DEFAULT;
            cmbClasses.Select();

            lblXmlSelected.Text = LBLSELECTEDXML_DEFAULT;
            
        }

        
        private void CmbClasses_IndexChanged(object sender, EventArgs e)
        { // When a class is chosen, get the Students from this class.
            selectedClass = (Class) ((ComboBox)sender).SelectedItem;  // Store the selected class.
            lblSelectedClass.Text = SELECTEDLABEL_TEXT + selectedClass;
            students = helper.GetStudentsInClass(selectedClass); // Get the students that are a member in this class.
            txtAmountOfStudents.Text = students.Count.ToString();   // Fill in the amount of Students in the class.
        }

        private void SourceChosen(object sender, EventArgs e)
        { // Load the correct Helper object based on the selected option.
                ResetClassroom();
                ResetData();



                if (((ToolStripMenuItem)sender) == databaseToolStripMenuItem)
                {
                    SetDatabaseAsSource();
                }
                else
                {
                    if (((ToolStripMenuItem)sender) == xMLToolStripMenuItem)
                    {
                        SetXmlAsSource();
                    }
                    else
                    {
                        if(((ToolStripMenuItem)sender == networkToolStripMenuItem)){
                            SetNetworkAsSource();
                        }
                    }
                }
                FillClassesCmb();
                
            
        }



        private void FillClassesCmb()
        {
            cmbClasses.Items.Clear(); // Clear the old values from the combobox.
            cmbClasses.SelectedIndex = -1;
            // Load the Classes and insert them into the combobox.
            classList = helper.GetClasses();
            foreach (Class c in classList)
            {
                cmbClasses.Items.Add(c);
            }
        }

        private void SetXmlAsSource()
        {
            if (xmlUri == null)
            {
                SelectXml();
            }
            else
            {
                lblXmlSelected.Text = LBLSELECTEDXML_SELECTED + xmlUri;
            }
            helper = new LinqToXmlHelper(xmlUri);
            databaseToolStripMenuItem.Checked = false;
            xMLToolStripMenuItem.Checked = true;
        }

        private void SetDatabaseAsSource()
        {
            helper = new SqlHelper(StudentsDatabase.GetInstance());
            lblXmlSelected.Text = LBLSELECTEDXML_DEFAULT;
            databaseToolStripMenuItem.Checked = true;
            xMLToolStripMenuItem.Checked = false;

        }

        private void SetNetworkAsSource()
        {
            helper = new NetworkHelper(new Client());
            lblXmlSelected.Text = LBLSELECTEDNETWORK;
            networkToolStripMenuItem.Checked = true;

        }


        private void bSelectXml_Click(object sender, EventArgs e)
        {
            SelectXml();
        }


        private void SelectXml()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open XML file";
            ofd.Filter = "XML file|*.xml";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                xmlUri = ofd.FileName;
                lblXmlSelected.Text = LBLSELECTEDXML_SELECTED + xmlUri;
            }
        }

        private void AddClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClassDialog addClass = new AddClassDialog();
            if(addClass.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                if (helper.Add(addClass.newClass))
                {
                    MessageBox.Show(MSG_CLASS_ADD_OK, DB_OP_RES_TITLE);
                    ResetClassroom();
                    ResetData();
                    FillClassesCmb();
                }
                else {
                    MessageBox.Show(MSG_CLASS_ADD_NOK, DB_OP_RES_TITLE);
                }
            }
        }
        private void AddStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentDialog addStud = new AddStudentDialog(classList);
            if (addStud.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                if (helper.Add(addStud.newStud))
                {
                    MessageBox.Show(MSG_STUD_ADD_OK, DB_OP_RES_TITLE);
                    ResetClassroom();
                    ResetData();
                }
                else {
                    MessageBox.Show(MSG_STUD_ADD_NOK, DB_OP_RES_TITLE);
                }
            }

        }

        private void EditClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditClassDialog editClass = new EditClassDialog(classList, EditClassDialog.Action.Edit);
            if(editClass.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (helper.Edit(editClass.editClass))
                {
                    MessageBox.Show(MSG_CLASS_EDIT_OK, DB_OP_RES_TITLE);
                    ResetClassroom();
                    ResetData();
                    FillClassesCmb();
                }
                else {
                    MessageBox.Show(MSG_CLASS_EDIT_NOK, DB_OP_RES_TITLE);
                }
            }
        }

        private void EditStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditStudentDialog editStudent = new EditStudentDialog(classList, helper, EditStudentDialog.Action.Edit);
            if (editStudent.ShowDialog() == System.Windows.Forms.DialogResult.OK) { 
                if(helper.Edit(editStudent.editStudent)){
                    MessageBox.Show(MSG_STUD_EDIT_OK, DB_OP_RES_TITLE);
                    ResetClassroom();
                    ResetData();
                    
                }
                else
                {
                    MessageBox.Show(MSG_STUD_EDIT_NOK, DB_OP_RES_TITLE);
                }
            }
        }

        private void DeleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditStudentDialog delStudent = new EditStudentDialog(classList, helper, EditStudentDialog.Action.Delete);
            if(delStudent.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                if(helper.Delete(delStudent.editStudent)){
                    MessageBox.Show(MSG_STUD_DEL_OK, DB_OP_RES_TITLE);
                    ResetClassroom();
                    ResetData();
                }
                else
                {
                    MessageBox.Show(MSG_STUD_DEL_NOK, DB_OP_RES_TITLE);
                }
            }
        }

        private void DeleteClassToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EditClassDialog editClass = new EditClassDialog(classList, EditClassDialog.Action.Delete);
            if (editClass.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (helper.Delete(editClass.editClass))
                {
                    MessageBox.Show(MSG_CLASS_DEL_OK, DB_OP_RES_TITLE);
                    ResetClassroom();
                    ResetData();
                    FillClassesCmb();
                }
                else
                {
                    MessageBox.Show(MSG_CLASS_DEL_NOK, DB_OP_RES_TITLE);
                }
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetClassroom();
            ShowClassroom(classroom);
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetClassroom();
            ResetData();
        }

        

        



        

        

        
    }
}

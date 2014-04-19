using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Globalization;
using System.Windows.Forms;

namespace Classroom
{
    class LinqToXmlHelper:AbstractHelper
    {

        private XDocument _doc;
        private string _path;

        public static readonly string CLASS_EL = "class";
        public static readonly string STUD_EL = "student";

        public static readonly string CLASS_NAME_ATT = "name";

        public static readonly string STUD_NAME_ATT = "name";
        public static readonly string STUD_GRADE_EL = "grade";
        public static readonly string STUD_HEIGHT_EL = "height";
        public static readonly string ID_ATT = "id";

        public static readonly string META_EL = "meta";
        public static readonly string CLASSINDEX_EL = "classindex";
        public static readonly string STUDINDEX_EL = "studindex";

        private static readonly string DECIMAL_SEPERATOR = ".";

        

        public LinqToXmlHelper(string path)
        {
            this._doc = XDocument.Load(path);
            this._path = path;
        }


        public List<Class> GetClasses()
        {
            List<Class> classList = new List<Class>();
            IEnumerable<IEnumerable<XAttribute>> classes =
                from el in _doc.Root.Elements(CLASS_EL)
                select el.Attributes();

            
            foreach (IEnumerable<XAttribute> at in classes) {
                
                classList.Add(new Class(Convert.ToInt32(at.ElementAt(1).Value),
                    at.ElementAt(0).Value));
                
            }
                
            
            return classList;
        }

        public List<Student> GetStudentsInClass(Class fromClass)
        {
            List<Student> studentsList = new List<Student>();
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = DECIMAL_SEPERATOR;
            IEnumerable<IEnumerable<XElement>> students =
                from el in _doc.Root.Elements(CLASS_EL)
                where el.Attribute(ID_ATT).Value==fromClass.id.ToString()
                select el.Elements(STUD_EL);

            foreach(IEnumerable<XElement> el in students){
                foreach (XElement s in el) {
                    studentsList.Add(new Student(
                        Convert.ToInt64(s.Attribute(ID_ATT).Value),
                        s.Attribute(STUD_NAME_ATT).Value,
                        Convert.ToDouble(s.Element(STUD_GRADE_EL).Value, provider),
                        Convert.ToInt32(s.Element(STUD_HEIGHT_EL).Value),
                        fromClass));
                }
            }

            return studentsList;
        }

        public bool Add(Class newClass)
        {
            long newClassId = 1 + Convert.ToInt64(
                _doc.Root
                .Descendants(CLASSINDEX_EL)
                .First()
                .Value);

            try
            {
                XElement newClassEl = new XElement(CLASS_EL);
                newClassEl.SetAttributeValue(CLASS_NAME_ATT, newClass.name);
                newClassEl.SetAttributeValue(ID_ATT, newClassId);
                _doc.Root.Add(newClassEl);
                _doc.Root.Element(META_EL).SetElementValue(CLASSINDEX_EL, newClassId);
                _doc.Save(_path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Add(Student newStudent)
        {
            long newStudId = 1 + Convert.ToInt64(
                _doc.Root
                .Descendants(STUDINDEX_EL)
                .First()
                .Value);

            try
            {
                XElement newStudEl = GenerateXElement(newStudent, newStudId);
                _doc.Root
                    .Elements(CLASS_EL)
                    .Single(c => (string) c.Attribute(ID_ATT)==newStudent.class_id.id.ToString())
                    .Add(newStudEl);
                _doc.Root.Element(META_EL).SetElementValue(STUDINDEX_EL, newStudId);
                _doc.Save(_path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public bool Edit(Class editClass)
        {
            XElement oldClass = _doc.Root
                .Descendants(CLASS_EL)
                .Single(c => (string)c.Attribute(ID_ATT).Value == editClass.id.ToString());

            try
            {
                oldClass.SetAttributeValue(CLASS_NAME_ATT, editClass.name);
                _doc.Save(_path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Student editStudent) {
            XElement oldStud = _doc.Root
                        .Descendants(STUD_EL)
                        .Single(s => (string)s.Attribute(ID_ATT).Value == editStudent.id.ToString());

            try
            {
                if (Convert.ToInt32(oldStud.Parent.Attribute(ID_ATT).Value) == editStudent.class_id.id)
                {
                    oldStud.SetAttributeValue(STUD_NAME_ATT, editStudent.name);
                    oldStud.SetElementValue(STUD_GRADE_EL, editStudent.grade);
                    oldStud.SetElementValue(STUD_HEIGHT_EL, editStudent.height);
                    _doc.Save(_path);
                }
                else
                {
                    XElement newStudEl = GenerateXElement(editStudent);
                    oldStud.Remove();
                    _doc.Root
                        .Elements(CLASS_EL)
                        .Single(c => (string)c.Attribute(ID_ATT).Value == editStudent.class_id.id.ToString())
                        .Add(newStudEl);
                    _doc.Save(_path);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool Delete(Class delClass)
        {
            try
            {
                XElement delClassEl = _doc.Root
                        .Descendants(CLASS_EL)
                        .Single(s => (string)s.Attribute(ID_ATT).Value == delClass.id.ToString());
                if (delClassEl.DescendantNodes().Count() == 0)
                {
                    delClassEl.Remove();
                    _doc.Save(_path);
                }
                else {
                    MessageBox.Show("Cannot remove a class that has students in it.");
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Delete(Student delStudent)
        {
            try
            {
                _doc.Root
                        .Descendants(STUD_EL)
                        .Single(s => (string)s.Attribute(ID_ATT).Value == delStudent.id.ToString())
                        .Remove();
                _doc.Save(_path);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
            
        }

        private static XElement GenerateXElement(Student student, long id)
        {
            XElement newStudEl = new XElement(STUD_EL);
            newStudEl.SetAttributeValue(STUD_NAME_ATT, student.name);
            newStudEl.SetAttributeValue(ID_ATT, id);
            newStudEl.SetElementValue(STUD_GRADE_EL, student.grade);
            newStudEl.SetElementValue(STUD_HEIGHT_EL, student.height);
            return newStudEl;
        }

        private XElement GenerateXElement(Student student)
        {
            XElement newStudEl = new XElement(STUD_EL);
            newStudEl.SetAttributeValue(STUD_NAME_ATT, student.name);
            newStudEl.SetAttributeValue(ID_ATT, student.id);
            newStudEl.SetElementValue(STUD_GRADE_EL, student.grade);
            newStudEl.SetElementValue(STUD_HEIGHT_EL, student.height);
            return newStudEl;
        }
    }

    
}

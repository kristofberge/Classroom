using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    abstract class AbstractStudentDistributor
    {
        abstract protected void sort(int low, int high);
        abstract protected Student[,] distribute();

        protected int _classRoomRows;
        protected int _classRoomColumns;
        protected static Student[] students;

        public AbstractStudentDistributor(int classRoomRows, int classRoomColumns)
        {
            this._classRoomRows = classRoomRows;
            this._classRoomColumns = classRoomColumns;
        }

        public Student[,] createClassroom(Student[] array)
        {
            students = array;
            sort(0, students.Length - 1);
            return distribute();
        }

        public Student[,] createClassroom(List<Student> array)
        {
            students = array.ToArray();
            sort(0, students.Length-1);
            return distribute();
        }
    }
}

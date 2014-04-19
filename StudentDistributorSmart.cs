using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    class StudentDistributorSmart:AbstractStudentDistributor
    {
        private int _MaxSwaps;
        private int _MinHeightDifference;

        public StudentDistributorSmart(int classRoomRows, int classRoomColumns, int maxSwaps, int MinHeightDifference):base(classRoomRows, classRoomColumns)
        {
            this._MaxSwaps = maxSwaps;
            this._MinHeightDifference = MinHeightDifference;
        }

        protected override void sort(int low, int high)
        {
            int i = low;
            int j = high;

            double pivot = students[low + (high - low) / 2].grade;

            while (i <= j)
            {
                while (students[i].grade < pivot)
                {
                    i++;
                }

                while (students[j].grade > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    swap(i, j);
                    i++;
                    j--;
                }
            }

            if (low < j)
                sort(low, j);
            if (i < high)
                sort(i, high);
        }

        private void swap(int i, int j)
        {
            Student help = students[i];
            students[i] = students[j];
            students[j] = help;

        }

        protected override Student[,] distribute()
        {
            Student[,] classroom = new Student[_classRoomRows, _classRoomColumns];

            // Distribution phase
            int i = 0;
            for (int r = 0; r < _classRoomRows && i < students.Length; r++)
            {
                for (int c = 0; c < _classRoomColumns && i < students.Length; c++)
                {
                    classroom[r, c] = students[c + (r * _classRoomColumns)];
                    i++;
                }
            }

            // Swap phase
            for (int j = 0; j < _MaxSwaps; j++ )
            {
                for (int r = 0; r < _classRoomRows-1; r++)
                {
                    for (int c = 0; c < _classRoomColumns; c++)
                    {
                        if (classroom[r + 1, c] != null && classroom[r, c] != null && classroom[r, c].height > classroom[r + 1, c].height + _MinHeightDifference)
                        {
                            Student help = classroom[r, c];
                            classroom[r, c] = classroom[r + 1, c];
                            classroom[r + 1, c] = help;
                        }
                    }
                }
            }
            return classroom;
        }
    }
}

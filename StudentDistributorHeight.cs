﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    class StudentDistributorHeight:AbstractStudentDistributor
    {


        public StudentDistributorHeight(int classRoomRows, int classRoomColumns)
            : base(classRoomRows, classRoomColumns)
        {}

        protected override void sort(int low, int high)
        {
            int i = low; int j = high;
            
            int pivot = students[low + (high - low) / 2].height;

            while(i <= j){
                while (students[i].height < pivot) {
                    i++;
                }

                while (students[j].height > pivot)
                {
                    j--;
                }

                if(i <= j){
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

            int i = 0;
            for (int r = 0; r < _classRoomRows && i < students.Length; r++)
            {
                for (int c = 0; c < _classRoomColumns && i < students.Length; c++)
                {
                    classroom[r, c] = students[i];
                    i++;
                }
            }

            return classroom;
        }

    }
}

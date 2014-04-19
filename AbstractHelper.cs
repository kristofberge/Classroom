using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    public interface AbstractHelper
    {
        List<Class> GetClasses();
        List<Student> GetStudentsInClass(Class fromClass);

        bool Add(Class newClass);
        bool Add(Student newStudent);

        bool Edit(Class editClass);
        bool Edit(Student editStudent);

        bool Delete(Class editClass);
        bool Delete(Student editStudent);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    class NetworkHelper:AbstractHelper
    {
        Client _client;

        public NetworkHelper(Client client)
        {
            this._client = client;
        }

        public List<Class> GetClasses()
        {
            List<Class> result = new List<Class>();
            List<string> stringList = new List<string>();

            if(_client.OpenConnection()){
                Console.WriteLine("Connection ok");
                stringList = _client.GetClassList();
                _client.CloseConnection();
            }

            foreach(string s in stringList){
                string[] parts = s.Split(';');
                result.Add(new Class(Convert.ToInt32(parts[0]), parts[1]));
            }
            return result;
        }

        public List<Student> GetStudentsInClass(Class fromClass)
        {
            List<Student> result = new List<Student>();
            List<string> stringList = new List<string>();

            if (_client.OpenConnection())
            {
                Console.WriteLine("Connection ok");
                stringList = _client.GetStudentsList(fromClass.id.ToString());
                _client.CloseConnection();
            }

            foreach (string s in stringList)
            {
                string[] parts = s.Split(';');
                result.Add(new Student(
                    Convert.ToInt64(parts[0]),
                    parts[1],
                    Convert.ToDouble(parts[2]),
                    Convert.ToInt32(parts[3]),
                    fromClass));
            }
            return result;
        }

        public bool Add(Class newClass)
        {
            throw new NotImplementedException();
        }

        public bool Add(Student newStudent)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Class editClass)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Student editStudent)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Class editClass)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Student editStudent)
        {
            throw new NotImplementedException();
        }
    }
}

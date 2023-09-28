namespace Students
{
    public class StudentManager
    {
        public List<Student> students;

        public StudentManager()
        {
            students = new List<Student>();
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void AddStudent(int id, string nameSurName, bool isInClass)
        {
            Student existingStudent = GetStudentById(id);

            if (existingStudent != null)
            {
                if (existingStudent.IsInClass)
                {
                    Console.WriteLine($"{existingStudent.NameSurName} zaten sınıfta.");
                }
                else
                {
                    existingStudent.IsInClass = true;
                    Console.WriteLine($"{existingStudent.NameSurName} zaten sınıfta olduğu belirlendi.");
                }
            }
            else
            {
                students.Add(new Student() { Id = id, NameSurName = nameSurName, IsInClass = isInClass });
                Console.WriteLine($"{nameSurName} isimli öğrenci sınıfta olarak eklendi.");
            }
        }

        public bool AllStudentsAreInClass()
        {
            return students.All(s => s.IsInClass);
        }
    }
}

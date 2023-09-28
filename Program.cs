using System;

namespace Students
{
    internal class Program
    {
        static void Main()
        {
            StudentManager studentManager = new StudentManager();

            do
            {
                int id = 0;
                bool isValidId = false;
                while (!isValidId)
                {
                    Console.Write("Öğrenci ID'sini girin (sadece rakam): ");
                    string idInput = Console.ReadLine();

                    if (int.TryParse(idInput, out id))
                    {
                        isValidId = true;
                    }
                    else
                    {
                        Console.WriteLine("Hata: Lütfen sadece rakam girin.");
                    }
                }

                Console.Write("Öğrenci Adı Soyadı'nı girin: ");
                string nameSurName = Console.ReadLine();

                Student existingStudent = studentManager.GetStudentById(id);

                if (existingStudent != null)
                {
                    Console.WriteLine($"{existingStudent.NameSurName} isimli öğrenci zaten kayıtlı.");
                }
                else
                {
                    Console.Write("Öğrenci sınıfta mı? (Evet için 'e', Hayır için 'h' girin): ");
                    bool isInClass = Console.ReadLine().ToLower() == "e";

                    studentManager.AddStudent(id, nameSurName, isInClass);
                }

                Console.Write("Başka bir öğrenci eklemek ister misiniz? (Evet için 'e', Hayır için 'h' girin): ");
            } while (Console.ReadLine().ToLower() == "e");

            if (studentManager.AllStudentsAreInClass())
            {
                Console.WriteLine("Tüm öğrenciler sınıfta.");
            }
            else
            {
                Console.WriteLine("Tüm öğrenciler sınıfta değil.");
            }
        }
    }
}

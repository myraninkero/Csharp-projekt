using System.Text.Json;
namespace StudentMetoder1;

class Program
{
    static void Main(string[] args)
    {
        string rawStudents = File.ReadAllText("students.json");

        var students = JsonSerializer.Deserialize<List<Student>>(rawStudents, JsonSerializerOptions.Web);

        var studentsUtils = new StudentUtilities(students ?? []);
        
        bool running = true;

        while (running)
        {
            ShowMenu();
            string input = Console.ReadLine();
            
            Console.Clear();
            switch (input)
            {
                case "1":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetTopStudents().ForEach(Console.WriteLine);
                    break;
                case "2":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetStudentsSortedByGrade().ForEach(Console.WriteLine);
                    break;
                case "3":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetStudentProgramList().ForEach(Console.WriteLine);
                    break;
                case "4":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetStudentCountByProgram().ForEach(Console.WriteLine);
                    break;
                case "5":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetAverageGradeByProgram().ForEach(Console.WriteLine);
                    break;
                case "6":
                    Console.WriteLine("\nResults:");
                    bool allNursesStudentsArePassing = studentsUtils.AllNursesStudentsArePassing();
                    Console.WriteLine($"All nurse students are passing: {allNursesStudentsArePassing}");
                    break;
                case "7":
                    Console.WriteLine("\nResults:");
                    var oldestStudent = studentsUtils.GetOldestStudent();
                    if (oldestStudent != null)
                    {
                        Console.WriteLine($"Oldest student: {oldestStudent.Name}, Birthdate {oldestStudent.Birthdate:yyyy-MM-dd}");
                    }
                    else
                    {
                        Console.WriteLine("No student found.");
                    }
                    break;
                case "8":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetTopFiveStudents().ForEach(Console.WriteLine);
                    break;
                case "9":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetCompletionPercentage().ForEach(Console.WriteLine);
                    break;
                case "10":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetProgramsWithHighAverage().ForEach(Console.WriteLine);
                    break;
                case "11":
                    running = false;
                    Console.WriteLine("Thank you!");
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
        
    static void ShowMenu()
    {
        Console.WriteLine("\n--- School-API ---");
        Console.WriteLine("1. Retrieve all students with a grade above 80.");
        Console.WriteLine("2. Sort students in descending order by grade and return name + grade.");
        Console.WriteLine("3. Each student's name + program name.");
        Console.WriteLine("4. How many students are enrolled in each program.");
        Console.WriteLine("5. Calculate the average grade per program.");
        Console.WriteLine("6. Check if all students in \"Undersköterska\" are approved (>= 50).");
        Console.WriteLine("7. The oldest student.");
        Console.WriteLine("8. The top 5 students with the highest grades.");
        Console.WriteLine("9. Name + percentage of completed semesters.");
        Console.WriteLine("10. Program names where the average grade exceeds 70.");
        Console.WriteLine("11. Exit.");
        Console.Write("Your choice: ");
    }
}
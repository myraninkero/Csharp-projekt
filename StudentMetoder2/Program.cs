using System.Text.Json;
namespace StudentMetoder2;

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
                    studentsUtils.GetTopStudentPerProgram().ForEach(Console.WriteLine);
                    break;
                case "2":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetRankedStudentsByProgram().ForEach(Console.WriteLine);
                    break;
                case "3":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetGradeSpreadPerProgram().ForEach(Console.WriteLine);
                    break;
                case "4":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetAverageByGenderAndProgram().ForEach(Console.WriteLine);
                    break;
                case "5":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetAgeGroupAverages().ForEach(Console.WriteLine);
                    break;
                case "6":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetProgramsRankedByAverage().ForEach(Console.WriteLine);
                    break;
                case "7":
                    Console.WriteLine("\nResults:");
                    studentsUtils.GetTopThreeStudentsPerProgram().ForEach(Console.WriteLine);
                    break;
                case "8":
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
        Console.WriteLine("1. Group students by program and return the one with the highest grade.");
        Console.WriteLine("2. Sort students within each program by grade and display a rank.");
        Console.WriteLine("3. Calculate the difference between the highest and lowest grades in each program.");
        Console.WriteLine("4. Return average grades broken down by gender and program.");
        Console.WriteLine("5. Divide into groups: <25, 25-30, >30. Return average grade in each group.");
        Console.WriteLine("6. Sort programs by average grade (highest first).");
        Console.WriteLine("7. Return the three with the highest scores within each program.");
        Console.WriteLine("8. Exit.");
        Console.Write("Your choice: ");
    }
}
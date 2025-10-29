namespace StudentMetoder2;

public class StudentUtilities
{
    private readonly List<Student> _students;

    public StudentUtilities(List<Student> students)
    {
        _students = students;
    }

    private int CalculateAge(DateTime birthdate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthdate.Year;
        if (birthdate.Date > today.AddYears(-age)) age--;
        return age;
    }

/*
1. Toppstudent per program
Gruppera studenter per program och returnera den med högst betyg.
Exempel: "Undersköterska: Mosa - 95"
*/
    public List<string> GetTopStudentPerProgram()
    {
        return _students
            .Where(s => s.Program != null)
            .GroupBy(s => s.Program.Name)
            .Select(g =>
            {
                var topStudent = g.OrderByDescending(s => s.Grade).First();
                return $"{g.Key}: {topStudent.Name} - {topStudent.Grade}";
            })
            .ToList();
    }

/*
2. Rangordning inom program
Sortera studenterna inom varje program efter betyg och visa en rank.
Exempel: "Undersköterska: 1. Mosa (95), 2. Ali (83)"
*/
    public List<string> GetRankedStudentsByProgram()
    {
        return _students
            .Where(s => s.Program != null)
            .GroupBy(s => s.Program.Name)
            .SelectMany(g =>
                g.OrderByDescending(s => s.Grade)
                    .Select((s, index) => $"{g.Key} - #{index + 1}: {s.Name} ({s.Grade})")
            )
            .ToList();
    }

/*
3. Betygsspridning per program
Beräkna skillnaden mellan högsta och lägsta betyg i varje program.
Exempel: "Undersköterska - spridning: 28"
*/
    public List<string> GetGradeSpreadPerProgram()
    {
        return _students
            .Where(s => s.Program != null)
            .GroupBy(s => s.Program.Name)
            .Select(g =>
            {
                var max = g.Max(s => s.Grade);
                var min = g.Min(s => s.Grade);
                var diff = max - min;
                return $"{g.Key}: {diff} Diff (Max: {max}, Min: {min})";
            })
            .ToList();
    }

/*
4. Medelbetyg per kön och program
Returnera snittbetyg uppdelat på kön *och* program.
Exempel: "Female - Undersköterska: 74.3"
*/
    public List<string> GetAverageByGenderAndProgram()
    {
        return _students
            .Where(s => s.Program != null && !string.IsNullOrEmpty(s.Gender))
            .GroupBy(s => new { s.Gender, Program = s.Program.Name })
            .Select(g =>
            {
                var average = g.Average(s => s.Grade);
                return $"{g.Key.Gender} - {g.Key.Program}: Average {average:F1}";
            })
            .ToList();
    }
    
/*
5. Åldersgrupper – medelbetyg
Dela in i grupper: <25, 25-30, >30
Returnera medelbetyg i varje grupp.
Exempel: "<25: snitt 68"
*/
    public List<string> GetAgeGroupAverages()
    {
        return _students
            .Where(s => s.Birthdate != DateTime.MinValue)
            .Select(s => new
            {
                Age = CalculateAge(s.Birthdate),
                Grade = s.Grade
            })
            .GroupBy(s =>
            {
                if (s.Age < 25) return "<25";
                if (s.Age <= 30) return "25–30";
                return ">30";
            })
            .Select(g => $"{g.Key}: Average {g.Average(s => s.Grade):F0}")
            .ToList();
    }

/*
6. Program rankade efter medelbetyg
Sortera program efter snittbetyg (högst först).
Exempel: "1. Sjuksköterska (snitt 82)"
*/
    public List<string> GetProgramsRankedByAverage()
    {
        return _students
            .Where(s => s.Program != null)
            .GroupBy(s => s.Program.Name)
            .Select(g => new
            {
                Program = g.Key,
                Average = g.Average(s => s.Grade)
            })
            .OrderByDescending(x => x.Average)
            .Select((x, index) => $"{index + 1}. {x.Program} (Average {x.Average:F0})")
            .ToList();
    }
    
/*
7. Topp 3 per program
Returnera de tre med högst betyg inom varje program.
Exempel:
"Undersköterska: Mosa (95), Ali (83), Sara (80)"
*/
    public List<string> GetTopThreeStudentsPerProgram()
    {
        return _students
            .Where(s => s.Program != null)
            .GroupBy(s => s.Program.Name)
            .Select(g =>
            {
                var topThree = g
                    .OrderByDescending(s => s.Grade)
                    .Take(3)
                    .Select(s => $"{s.Name} ({s.Grade})");

                return $"{g.Key}: {string.Join(", ", topThree)}";
            })
            .ToList();
    }
}
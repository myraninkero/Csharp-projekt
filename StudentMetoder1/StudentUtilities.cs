namespace StudentMetoder1;

public class StudentUtilities
{
    private readonly List<Student> _students;

    public StudentUtilities(List<Student> students)
    {
        _students = students;
    }
    
    /*
1. Filtrering – hitta duktiga studenter
Hämta alla studenter som har ett betyg över 80.
*/
    public List<Student> GetTopStudents()
    {
        return _students
            .Where(s => s.Grade > 80)
            .OrderByDescending(s => s.Grade)
            .ToList();
    }
    
/*
2. Sortering – ordna efter högsta betyg
Sortera studenterna i fallande ordning efter Grade och returnera namn + betyg.
Exempel: "Adam - 95"
*/
    public List<string> GetStudentsSortedByGrade()
    {
        return _students
            .OrderByDescending(s => s.Grade)
            .Select(s => $"{s.Name} - {s.Grade}")
            .ToList();
    }
    
/*
3. Projektion – skapa en enklare lista
Returnera varje students namn + programnamn.
Exempel: "Adam - Undersköterska"
*/
    public List<string> GetStudentProgramList()
    {
        return _students
            .Select(s => $"{s.Name} - {s.Program?.Name}")
            .ToList();
    }
    
/*
4. Gruppering – gruppera efter program
Returnera hur många som går varje program.
Exempel: "Undersköterska - 24 studenter"
*/
    public List<string> GetStudentCountByProgram()
    {
        return _students
            .GroupBy(s => s.Program?.Name)
            .Select(g => $"{g.Key} - {g.Count()}")
            .ToList();
    }
    
/*
5. Aggerering – medelbetyg per program
Beräkna medelbetyg per program.
Exempel: "Undersköterska - snitt 72.5"
*/
    public List<string> GetAverageGradeByProgram()
    {
        return _students
            .GroupBy(s => s.Program?.Name)
            .Select(g =>
            {
                var programName = g.Key ?? "Unknown program";
                var average = g.Average(s => s.Grade);
                return $"{programName} - Average {average:F1}";
            })
            .ToList();
    }
    
/*
6. Villkorskontroll – kontrollera betyg
Kontrollera om alla i "Undersköterska" har godkänt (>= 50).
Returnera true eller false.
*/
    public bool AllNursesStudentsArePassing()
    {
        return _students
            .Where(s => s.Program?.Name == "Undersköterska")
            .All(s => s.Grade >= 50);
    }
    
/*
7. Åldersberäkning – äldsta studenten
Returnera den student som är äldst.
*/
    public Student GetOldestStudent()
    {
        return _students
            .OrderBy(s => s.Birthdate)
            .FirstOrDefault();
    }
    
/*
8. Urval – top 5
Returnera de 5 studenter med högst betyg.
*/
    public List<Student> GetTopFiveStudents()
    {
        return _students
            .OrderByDescending(s => s.Grade)
            .Take(5)
            .ToList();
    }
    
/*
9. Transformation – andel avklarade terminer
Returnera namn + procent avklarade terminer.
Exempel: "Adam - 70%"
*/
    public List<string> GetCompletionPercentage()
    {
        return _students
            .Where(s => s.Program != null && s.Program.TotalSemester > 0)
            .Select(s =>
            {
                double procent = (double)s.Program.CurrentSemester / s.Program.TotalSemester * 100;
                return $"{s.Name} - {procent:F0}%";
            })
            .ToList();
    }
    
/*
10. Gruppfiltrering – program med snitt > 70
Returnera programnamn där medelbetyget överstiger 70.
Exempel: "Sjuksköterska"
*/
    public List<string> GetProgramsWithHighAverage()
    {
        return _students
            .Where(s => s.Program != null)
            .GroupBy(s => s.Program.Name)
            .Select(g => new { Program = g.Key, Average = g.Average(s => s.Grade) })
            .Where(x => x.Average > 70)
            .Select(x => $"{x.Program}")
            .ToList();
    }
}
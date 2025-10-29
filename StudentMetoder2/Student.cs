namespace StudentMetoder2;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime Birthdate { get; set; }
    public int Grade { get; set; }
    public ProgramInfo Program { get; set; }
    
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Gender: {Gender}, Birthdate: {Birthdate:yyyy-MM-dd}, Grade: {Grade}, Program: {Program?.Name}";
    }

}
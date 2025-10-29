using System.Text.Json.Serialization;
namespace StudentMetoder2;

public class ProgramInfo
{
    public string Name { get; set; }
    
    [JsonPropertyName("current_semester")]
    public int CurrentSemester { get; set; }
    
    [JsonPropertyName("total_semesters")]
    public int TotalSemester { get; set; }
}
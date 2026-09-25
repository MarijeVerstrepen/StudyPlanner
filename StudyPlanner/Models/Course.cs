using SQLite;

namespace StudyPlanner.Models;

public class Course
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public string Name { get; set; } = "";
}
using StudyPlanner.Models;

namespace StudyPlanner.Services;

public interface ICourseService
{
    Task<List<Course>> GetAllAsync();
    Task AddAsync(Course course);
    Task DeleteAsync(Course course);
}
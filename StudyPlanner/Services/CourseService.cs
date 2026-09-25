using SQLite;
using StudyPlanner.Models;

namespace StudyPlanner.Services;

public class CourseService : ICourseService
{
    private SQLiteAsyncConnection? _db;

    private async Task<SQLiteAsyncConnection> GetDbAsync()
    {
        if (_db is not null)
            return _db;

        var path = Path.Combine(FileSystem.AppDataDirectory, "studyplanner.db3");
        _db = new SQLiteAsyncConnection(path);
        await _db.CreateTableAsync<Course>();
        return _db;
    }

    public async Task<List<Course>> GetAllAsync()
    {
        var db = await GetDbAsync();
        return await db.Table<Course>().OrderBy(c => c.Name).ToListAsync();
    }

    public async Task AddAsync(Course course)
    {
        var db = await GetDbAsync();
        await db.InsertAsync(course);
    }

    public async Task DeleteAsync(Course course)
    {
        var db = await GetDbAsync();
        await db.DeleteAsync(course);
    }
}
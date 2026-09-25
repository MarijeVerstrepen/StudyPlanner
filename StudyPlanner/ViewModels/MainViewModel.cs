using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudyPlanner.Models;
using StudyPlanner.Services;
using System.Collections.ObjectModel;

namespace StudyPlanner.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ICourseService _courseService;

    public MainViewModel(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [ObservableProperty]
    private string newCourseName = "";

    public ObservableCollection<Course> Courses { get; } = new();

    [RelayCommand]
    private async Task LoadCoursesAsync()
    {
        Courses.Clear();
        foreach (var course in await _courseService.GetAllAsync())
            Courses.Add(course);
    }

    [RelayCommand]
    private async Task AddCourseAsync()
    {
        if (string.IsNullOrWhiteSpace(NewCourseName))
            return;

        var course = new Course { Name = NewCourseName.Trim() };
        await _courseService.AddAsync(course);
        Courses.Add(course);
        NewCourseName = "";
    }

    [RelayCommand]
    private async Task DeleteCourseAsync(Course course)
    {
        await _courseService.DeleteAsync(course);
        Courses.Remove(course);
    }
}
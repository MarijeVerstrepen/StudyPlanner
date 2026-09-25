using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace StudyPlanner.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string newCourseName = "";

    public ObservableCollection<string> Courses { get; } = new();

    [RelayCommand]
    private void AddCourse()
    {
        if (string.IsNullOrWhiteSpace(NewCourseName))
            return;

        Courses.Add(NewCourseName.Trim());
        NewCourseName = "";
    }
}
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System;
using TodoXaml.Models;
using Windows.Storage.Streams;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;

namespace TodoXaml.Views;

public sealed partial class MainPage : Page, INotifyPropertyChanged
{
    public ObservableCollection<TodoItem> Todos { get; set; }

    public bool IsFormVisible;

    private TodoItem editedTodo = null;

    public event PropertyChangedEventHandler PropertyChanged;

    public TodoItem EditedTodo
    {
        get { return editedTodo; }
        set
        {
            editedTodo = value;
            if (value != null)
            {
                IsFormVisible = true;
            }
            else
            {
                IsFormVisible = false;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EditedTodo)));
        }
    }
    public List<Priority> Priorities { get; } = Enum.GetValues(typeof(Priority)).Cast<Priority>().ToList();

    public MainPage()
    {
        InitializeComponent();
        InitializeTodos();
    }

    private void InitializeTodos()
    {
        Todos = new ObservableCollection<TodoItem>()
        {
            new TodoItem()
            {
                Id = 3,
                Title = "Add Neptun code to neptun.txt",
                Description = "VLASX1",
                Priority = Priority.Normal,
                IsDone = true,
                Deadline = new DateTime(2024, 11, 08)
            },
            new TodoItem()
            {
                Id = 1,
                Title = "Buy milk",
                Description = "Should be lactose and gluten free!",
                Priority = Priority.Low,
                IsDone = false,
                Deadline = DateTimeOffset.Now + TimeSpan.FromDays(1)
            },
            new TodoItem()
            {
                Id = 2,
                Title = "Do the Computer Graphics homework",
                Description = "Ray tracing, make it shiny and gleamy! :)",
                Priority = Priority.High,
                IsDone = false,
                Deadline = new DateTime(2024, 11, 08)
            },
        };
    }

    public static Brush GetForeground(Priority priority)
    {
        switch(priority)
        {
            case Priority.Low:
                return new SolidColorBrush(Colors.Blue);

            case Priority.Normal:
                return (Brush)App.Current.Resources["ApplicationForegroundThemeBrush"];

            case Priority.High:
                return new SolidColorBrush(Colors.Red);
        }
        return null;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        EditedTodo = new TodoItem();
        AddForm.Visibility = Visibility.Visible;
    }


    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        Todos.Add(new TodoItem()
        {
            Id = EditedTodo.Id,
            Title = EditedTodo.Title,
            Description = EditedTodo.Description,
            Priority = EditedTodo.Priority,
            Deadline = EditedTodo.Deadline,
            IsDone = EditedTodo.IsDone
        });

        EditedTodo = null;

        AddForm.Visibility = Visibility.Collapsed;
    }
}

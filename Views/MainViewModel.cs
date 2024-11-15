using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfTestApp.Helper;
using WpfTestApp.Models;

namespace WpfTestApp.Views
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TaskModel> Tasks { get; set; } = new ObservableCollection<TaskModel>();


        private string _taskName;
        public string TaskName
        {
            get => _taskName;
            set
            {
                _taskName = value;
                OnPropertyChanged(_taskName);
                CommandManager.InvalidateRequerySuggested(); // Notify command system

            }
        }

        private DateTime? _dueDate;
        public DateTime? DueDate
        {
            get => _dueDate;
            set
            {
                _dueDate = value;
                OnPropertyChanged(_dueDate.ToString());
                CommandManager.InvalidateRequerySuggested(); // Notify command system
            }
        }

        private string _selectedPriority;
        public string SelectedPriority
        {
            get => _selectedPriority;
            set
            {
                _selectedPriority = value;
                OnPropertyChanged(_selectedPriority);
                CommandManager.InvalidateRequerySuggested(); // Notify command system

            }
        }

        public ICommand AddTaskCommand { get; }

        public MainViewModel()
        {
            //Tasks = new ObservableCollection<TaskModel>();
            AddTaskCommand = new RelayCommand(AddTask, CanAddTask);
        }

        private void AddTask(object parameter)
        {
            Tasks = new ObservableCollection<TaskModel>
    {
        new TaskModel { Name = "Task 1", DueDate = DateTime.Now, Priority = "High", Category = "Work", IsCompleted = false },
        new TaskModel { Name = "Task 2", DueDate = DateTime.Now.AddDays(1), Priority = "Low", Category = "Personal", IsCompleted = true }
    };
            // Add a new task to the ObservableCollection
            Tasks.Add(new TaskModel
            {
                Name = TaskName,
                DueDate = DueDate ?? DateTime.Now,
                Priority = SelectedPriority ?? "Medium",
                IsCompleted = false
            });

            // Clear input fields
            TaskName = string.Empty;
            DueDate = null;
            SelectedPriority = null;

            MessageBox.Show("Task added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanAddTask(object parameter)
        {
            // Only allow adding if all fields are valid
            return !string.IsNullOrWhiteSpace(TaskName) && DueDate != null && !string.IsNullOrWhiteSpace(SelectedPriority);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

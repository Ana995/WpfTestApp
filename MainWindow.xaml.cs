using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfTestApp.Models;
using WpfTestApp.Views;


namespace WpfTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TaskModel> Tasks { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //BTasks = new ObservableCollection<TaskModel>();
            //TaskDataGrid.ItemsSource = Tasks;
            DataContext = new MainViewModel();

            // Set default priority
            PriorityComboBox.SelectedIndex = 1; // Default to "Medium"
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(TaskNameTextBox.Text) || DueDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Add the task to the ObservableCollection
            Tasks.Add(new TaskModel
            {
                Name = TaskNameTextBox.Text,
                DueDate = DueDatePicker.SelectedDate.Value,
                Priority = ((ComboBoxItem)PriorityComboBox.SelectedItem)?.Content.ToString() ?? "Medium",
                IsCompleted = false
            });

            // Clear input fields
            TaskNameTextBox.Clear();
            DueDatePicker.SelectedDate = null;
            PriorityComboBox.SelectedIndex = -1;

            MessageBox.Show("Task added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
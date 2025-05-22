using System.Collections.ObjectModel;
using System.Windows.Input;
using DesignPatternSampleCore.Factories;
using DesignPatternSampleCore.Models;
using DesignPatternSampleCore.Repositories;
using System.Linq;

namespace DesignPatternSampleApp.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly EmployeeFactory _factory;

        // プロパティ - 画面にバインドする
        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set { _employees = value; OnPropertyChanged(); }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set { _selectedEmployee = value; OnPropertyChanged(); }
        }

        // 入力ボックスにバインドするプロパティ（新規追加用）
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(); }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(); }
        }

        private string _department;
        public string Department
        {
            get => _department;
            set { _department = value; OnPropertyChanged(); }
        }

        // コマンド
        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        // コンストラクタ
        public EmployeeViewModel(IEmployeeRepository repository, EmployeeFactory factory)
        {
            _repository = repository;
            _factory = factory;

            Employees = new ObservableCollection<Employee>();

            // コマンド初期化
            LoadCommand = new RelayCommand(_ => LoadEmployees());
            AddCommand = new RelayCommand(_ => AddEmployee(), _ => CanAddEmployee());
            UpdateCommand = new RelayCommand(_ => UpdateEmployee(), _ => CanUpdateEmployee());
            DeleteCommand = new RelayCommand(_ => DeleteEmployee(), _ => CanDeleteEmployee());
        }

        private void LoadEmployees()
        {
            Employees.Clear();
            var emps = _repository.GetAll();
            foreach (var emp in emps)
            {
                Employees.Add(emp);
            }
        }

        private void AddEmployee()
        {
            var newEmp = _factory.CreateEmployee(FirstName, LastName, Department);
            _repository.Add(newEmp);
            LoadEmployees();

            // 入力欄クリア
            FirstName = string.Empty;
            LastName = string.Empty;
            Department = string.Empty;
        }

        private bool CanAddEmployee()
        {
            return !string.IsNullOrWhiteSpace(FirstName)
                && !string.IsNullOrWhiteSpace(LastName)
                && !string.IsNullOrWhiteSpace(Department);
        }

        private void UpdateEmployee()
        {
            if (SelectedEmployee == null) return;
            _repository.Update(SelectedEmployee);
            LoadEmployees();
        }

        private bool CanUpdateEmployee()
        {
            return SelectedEmployee != null;
        }

        private void DeleteEmployee()
        {
            if (SelectedEmployee == null) return;
            _repository.Delete(SelectedEmployee.Id);
            LoadEmployees();
        }

        private bool CanDeleteEmployee()
        {
            return SelectedEmployee != null;
        }
    }
}

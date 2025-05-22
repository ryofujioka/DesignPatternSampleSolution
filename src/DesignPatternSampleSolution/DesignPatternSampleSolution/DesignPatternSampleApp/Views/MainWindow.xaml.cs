using DesignPatternSampleApp.Views;
using DesignPatternSampleApp.ViewModels;
using DesignPatternSampleCore.Factories;
using DesignPatternSampleCore.Repositories;
using System.Windows;
using DesignPatternSampleSolution.DesignPatternSampleCore.Factories;

namespace DesignPatternSampleApp.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Repository と Factory の具体実装を渡し、ViewModel を生成
            var repository = new EmployeeRepository();
            var factory = new RegularEmployeeFactory();
            this.DataContext = new EmployeeViewModel(repository, factory);
        }
    }
}

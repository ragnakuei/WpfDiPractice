using System.Windows;

namespace WpfDiPractice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var diFactory = new DiFactory();
            var mainWindow = diFactory.GetService<MainWindow>();
            mainWindow.DataContext = diFactory.GetService<MainWindowViewModel>();
            mainWindow.ShowDialog();
        }
    }
}
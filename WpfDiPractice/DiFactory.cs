using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using Microsoft.Extensions.DependencyInjection;
using WpfApp2.View;
using WpfApp2.ViewModel;

namespace WpfApp2
{
    public class DiFactory
    {
        private static readonly ServiceProvider _serviceProvider;

        static DiFactory()
        {
            var services = new ServiceCollection();
            services.AddSingleton<DiFactory>(x => new DiFactory());
            services.AddTransient<MainWindow>();
            services.AddTransient<MainWindowViewModel>();

            services.AddTransient<MainView>();
            services.AddTransient<MainViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        public (TUserControl UserControl, TViewModelBase ViewModel) GetUserControlWithViewMode<TUserControl, TViewModelBase>()
            where TUserControl : UserControl
            where TViewModelBase : ViewModelBase
        {
            var view = GetService<TUserControl>();
            var viewModel = GetService<TViewModelBase>();
            view.DataContext = viewModel;
            return (view, viewModel);
        }
        
        public (TWindow Window, TViewModelBase ViewModel) GetWindowithViewMode<TWindow, TViewModelBase>()
            where TWindow : Window
            where TViewModelBase : ViewModelBase
        {
            var view = GetService<TWindow>();
            var viewModel = GetService<TViewModelBase>();
            view.DataContext = viewModel;
            return (view, viewModel);
        }
    }
}
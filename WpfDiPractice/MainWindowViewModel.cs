using GalaSoft.MvvmLight;
using WpfApp2.View;
using WpfApp2.ViewModel;

namespace WpfApp2
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly MainView _mainView;
        private ViewModelBase _content;

        public ViewModelBase Content
        {
            get => _content;
            set => Set(ref _content, value);
        }

        public MainWindowViewModel(MainView mainView, MainViewModel mainViewModel)
        {
            _mainView = mainView;
            _mainViewModel = mainViewModel;
            
            _mainView.DataContext = _mainViewModel;            
            Content = mainViewModel;
        }
    }
}
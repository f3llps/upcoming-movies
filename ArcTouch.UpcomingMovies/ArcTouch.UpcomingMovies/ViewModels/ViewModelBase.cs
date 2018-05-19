using Prism.Mvvm;
using Prism.Navigation;

namespace ArcTouch.UpcomingMovies.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        //Attributes
        private string _title;
        protected INavigationService NavigationService { get; private set; }

        //Properties
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        //Constructor
        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        //Methods
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public virtual void Destroy()
        {
            
        }
    }
}

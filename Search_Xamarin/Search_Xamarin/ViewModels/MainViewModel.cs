using Search_Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Search_Xamarin.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Student> DataList = new ObservableCollection<Student>();

        private bool _isNotBusy;

        public bool IsNotBusy
        {
            get
            {
                return _isNotBusy;
            }
            set
            {
                _isNotBusy = value;
                OnPropertyChanged();
            }
        }

        private string _searchstring;

        public string SearchString
        {
            get
            {
                return _searchstring;
            }
            set
            {
                _searchstring = value;
                OnPropertyChanged();
            }
        }

        private ICommand _searchCommand;

        public ICommand SearchCommand
        {
            get
            {
                _searchCommand = _searchCommand ?? new Command(async () => await this.SearchInList());
                return _searchCommand;
            }
        }

        public void Init()
        {
            MainPage mainpage = new MainPage();
            mainpage.BindingContext = this;
            App.Current.MainPage = mainpage;
            IsNotBusy = true;
        }

        private async Task SearchInList()
        {
            IsNotBusy = false;
            await Task.Delay(2000);
            //Rellenar Lista
            IsNotBusy = true;
        }

    }
}

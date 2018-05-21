using Search_Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Search_Xamarin.Converters;

namespace Search_Xamarin.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Student> _datalist;

        public ObservableCollection<Student> DataList
        {
            get
            {
                return _datalist;
            }
            set
            {
                _datalist = value;
                OnPropertyChanged();
            }
        }

        private bool _isBusy = false;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
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

        private async Task SearchInList()
        {
            if (this.IsBusy) return;
            this.IsBusy = true;
            await Task.Delay(2000);
            this.DataList = new ObservableCollection<Student>(this.List());
            this.IsBusy = false;
        }

        private List<Student> List()
        {
            return new List<Student>()
            {
                new Student{Name="Hola"},
                new Student{Name="Si"}
            };
        }

    }
}

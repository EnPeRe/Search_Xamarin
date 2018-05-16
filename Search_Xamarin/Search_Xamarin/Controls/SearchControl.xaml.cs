using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Search_Xamarin.Controls
{
	public partial class SearchControl : StackLayout
	{
		public SearchControl ()
		{
			InitializeComponent ();
		}

        public static readonly BindableProperty SearchTextProperty = BindableProperty.Create("SearchText",
            typeof(string), typeof(SearchControl),
            default(ICommand), BindingMode.TwoWay,
            propertyChanged: OnResultChange);

        public string SearchText
        {
            get { return ((string)GetValue(SearchTextProperty)); }
            set
            {
                SetValue(SearchTextProperty, value);
            }
        }

        public static void OnResultChange(BindableObject bindable, object oldValue, object newValue)
        {
            SearchControl control = bindable as SearchControl;
            if (control != null && oldValue != newValue)
            {
                //Hacemos algo
            }
        }

        public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create("SearchCommand",
            typeof(ICommand), typeof(SearchControl),
            default(ICommand), BindingMode.TwoWay);

        public ICommand SearchCommand
        {
            get { return ((ICommand)GetValue(SearchCommandProperty)); }
            set
            {
                SetValue(SearchCommandProperty, value);
            }
        }

    }
}
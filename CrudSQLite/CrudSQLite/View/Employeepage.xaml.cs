using CrudSQLite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudSQLite.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Employeepage : ContentPage
    {
        EmployeeViewModel employeeView; 
        public Employeepage()
        {
            InitializeComponent();
            BindingContext = new EmployeeViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
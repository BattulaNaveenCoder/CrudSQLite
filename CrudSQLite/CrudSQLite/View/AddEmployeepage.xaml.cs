using CrudSQLite.Model;
using CrudSQLite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudSQLite.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEmployeepage : ContentPage
    {
        public Employeedata Employeedata;
        private Employeedata empdata;

        public AddEmployeepage()
        {
            InitializeComponent();
            BindingContext = new AddEmployeeViewModel();
           
        }

        public AddEmployeepage(Employeedata empdata)
        {
            InitializeComponent();
            BindingContext = new AddEmployeeViewModel(empdata);
            this.empdata = empdata;
        }
    }
}
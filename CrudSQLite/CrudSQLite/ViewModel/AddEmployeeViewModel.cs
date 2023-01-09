using CrudSQLite.Model;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrudSQLite.ViewModel
{
    public class AddEmployeeViewModel:BaseViewModel
    {
        private  Employeedata employeedata;
        private EmployeeViewModel model;

        public Employeedata Employeedata
        {
            get { return employeedata; }
            set { employeedata = value; OnPropertyChanged(); }
        }
        public AddEmployeeViewModel()
        {     
            save = new Command(Save_Clicked);
            Employeedata=new Employeedata();
            model = new EmployeeViewModel();
        }

        public AddEmployeeViewModel(Employeedata empdata)
        {
            save = new Command(Save_Clicked);
            this.Employeedata = empdata;
            model=new EmployeeViewModel();
            
        }

        #region methods
        private async void Save_Clicked(object obj)
        {
            var data = Employeedata;
            await App.EmployeeService.AddEmployee(data);
            await App.EmployeeService.AddEmployee(Employeedata);
            await model.LoadEmployee();
            await Application.Current.MainPage.Navigation.PopAsync();
            
        }
        #endregion 

        #region commands
        public ICommand save { get; set; }
        #endregion
    }
}

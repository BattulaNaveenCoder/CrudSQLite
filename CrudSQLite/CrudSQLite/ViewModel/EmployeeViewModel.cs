using CrudSQLite.Model;
using CrudSQLite.View;
using MvvmHelpers;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrudSQLite.ViewModel
{
    public class EmployeeViewModel:BaseViewModel
    {
      
        public ObservableCollection<Employeedata> employeedata { get; } 
       public EmployeeViewModel()
        {

            employeedata= new ObservableCollection<Employeedata>();
            AddEmployee = new Command(AddEmployee_clicked);
            EmployeeEdit = new Command(Update_Employee);
            EmployeeDelete = new Command(Delete_Employee);
           
            LoadEmployee();
        }

        

        private async void Delete_Employee(object obj)
        {
            var data = obj as Employeedata;
            await App.EmployeeService.DeleteEmployee(data.EmpId);
            await LoadEmployee();
        }

        private async void Update_Employee(object obj)
        {
            var data = obj as Employeedata;
            await Application.Current.MainPage.Navigation.PushAsync(new AddEmployeepage(data));
            
        }

         public async Task LoadEmployee()
        {
            try
            {
                IsBusy = true;
                employeedata.Clear();
                var EmpData = await App.EmployeeService.GetAll();
                if(EmpData != null)
                {
                    foreach (var data in EmpData)
                    {
                        employeedata.Add(data);
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy=false;
            }
           
        }


        #region Methods
       
        public async  void AddEmployee_clicked(object obj)
        {
            await LoadEmployee();
            await Application.Current.MainPage.Navigation.PushAsync(new AddEmployeepage());
        }

        
        #endregion

        #region commands
        public Command AddEmployee { get; set; }
       public Command EmployeeEdit { get; set; }
        public Command EmployeeDelete { get; set; }
      public Command Refreshing { get; set; }
  
        #endregion
    }
}

using CrudSQLite.Services;
using CrudSQLite.View;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudSQLite
{
    public partial class App : Application
    {

        static EmployeeService _employeeService;
        public static EmployeeService EmployeeService
        {
            get
            {
                if(_employeeService == null)
                {
                    _employeeService = new EmployeeService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Employee.db3"));
                }
                return _employeeService;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Employeepage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

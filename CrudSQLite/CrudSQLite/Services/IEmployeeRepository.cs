using CrudSQLite.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrudSQLite.Services
{
    public interface IEmployeeRepository
    {
        Task<bool>AddEmployee(Employeedata employeedata);
        Task<bool>UpdateEmployee(Employeedata employeedata);
        Task<bool>DeleteEmployee(int id);
        Task<Employeedata>GetEmployeedataById(int id);
        Task<IEnumerable<Employeedata>> GetAll();
    }
}

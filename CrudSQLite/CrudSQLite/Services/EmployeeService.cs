using CrudSQLite.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrudSQLite.Services
{
    public class EmployeeService : IEmployeeRepository
    {
        public SQLiteAsyncConnection _database;
        public EmployeeService(string dbPath) 
        {
            _database= new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Employeedata>().Wait();
        }
        public async Task<bool> AddEmployee(Employeedata employeedata)
        {
           if(employeedata.EmpId>0)
            {
              await  _database.UpdateAsync(employeedata);
            }
            else
            {
               await _database.InsertAsync(employeedata);
            }
           return await Task.FromResult(true);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            await _database.DeleteAsync<Employeedata>(id);
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Employeedata>> GetAll()
        {
            return await _database.Table<Employeedata>().ToListAsync();
        }

        public async Task<Employeedata> GetEmployeedataById(int id)
        {
            return await _database.Table<Employeedata>().Where(x=>x.EmpId== id).FirstOrDefaultAsync();
        }

        public Task<bool> UpdateEmployee(Employeedata employeedata)
        {
            throw new NotImplementedException();
        }
    }
}

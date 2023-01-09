using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudSQLite.Model
{
    public class Employeedata
    {
        [PrimaryKey,AutoIncrement]
        public int EmpId { get;set; }
        public string EmpName { get;set; }
        public decimal EmpSalary { get;set; }
        public DateTime EmpDOJ { get;set; }

    }
}

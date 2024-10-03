﻿using Company_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface IUnitOfWork
{
    public IDepartmentRepository DepartmentRepository { get; set; }
    public IEmployeeRepository EmployeeRepository { get; set; }
    int Complete();
}
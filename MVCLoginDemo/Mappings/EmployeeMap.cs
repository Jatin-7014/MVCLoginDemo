using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using MVCLoginDemo.Models;

namespace MVCLoginDemo.Mappings
{
    public class EmployeeMap:ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("Employees");
            Id(e => e.Id).GeneratedBy.GuidComb();
            Map(e => e.Name);
            Map(e => e.Email);
        }
    }
}
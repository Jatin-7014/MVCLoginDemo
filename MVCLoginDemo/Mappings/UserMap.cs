using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using FluentNHibernate.Mapping;
using MVCLoginDemo.Models;

namespace MVCLoginDemo.Mappings
{
    public class UserMap:ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(u => u.Id).GeneratedBy.Identity();
            Map(u => u.UserName);
            Map(u => u.Password);
            Map(u => u.Email);
            HasOne(u => u.Role).PropertyRef(u => u.User).Cascade.All().Constrained();
        }
    }
}
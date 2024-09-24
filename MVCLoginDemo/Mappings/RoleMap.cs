using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using MVCLoginDemo.Models;

namespace MVCLoginDemo.Mappings
{
    public class RoleMap:ClassMap<Role>
    {
        public RoleMap()
        {
            Table("Role");
            Id(r => r.Id).GeneratedBy.Identity();
            Map(r => r.RoleName);
            References(r =>r.User).Column("UserId").Cascade.None().Unique();
        }
    }
}
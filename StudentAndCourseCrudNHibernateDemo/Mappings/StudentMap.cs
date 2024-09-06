using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using StudentAndCourseCrudNHibernateDemo.Models;

namespace StudentAndCourseCrudNHibernateDemo.Mappings
{
    public class StudentMap:ClassMap<Student>
    {
        public StudentMap()
        {
            Table("Students");
            Id(u=>u.Id).GeneratedBy.Identity();
            Map(u => u.Name);
            Map(u => u.Age);
            Map(u => u.Email);

            //one to one rel
            HasOne(u => u.Course)
                .Cascade.All()
                .PropertyRef(a => a.Student)
                .Constrained(); //by setting false means foreign key rel is optional

        }
    }
}
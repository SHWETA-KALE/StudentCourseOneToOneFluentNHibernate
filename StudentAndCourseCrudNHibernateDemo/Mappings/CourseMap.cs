using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using FluentNHibernate.Mapping;
using StudentAndCourseCrudNHibernateDemo.Models;

namespace StudentAndCourseCrudNHibernateDemo.Mappings
{
    public class CourseMap:ClassMap<Course>
    {
        public CourseMap()
        {
            Table("Courses");
            Id(a => a.Id).GeneratedBy.Identity();
            Map(a => a.Name);
            Map(a=>a.DurationInYears);

            //one to one 
            References(a => a.Student)
                .Column("StudentId")
                .Unique()
                .Cascade.None();
        }

    }
}
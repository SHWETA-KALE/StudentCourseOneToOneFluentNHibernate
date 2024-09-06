using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StudentAndCourseCrudNHibernateDemo.Validations;

namespace StudentAndCourseCrudNHibernateDemo.Models
{
    public class Course
    {
        
        public virtual int Id { get; set; }

        
        [StringLength(50)]
        [NameValidator]
        [Required]
        public  virtual string Name { get; set; }
        [Required]
        public  virtual int DurationInYears { get; set; }
        
        public virtual Student Student { get; set; }    
    }
}
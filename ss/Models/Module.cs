using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ss.Models
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int Credits { get; set; }

        [IgnoreInsert]
        [Dapper.Column("CourseId")]
        public Course Course { get; set; }

        [IgnoreSelect]
        [IgnoreDataMember]
        public int CourseId { get; set; }

    }
}
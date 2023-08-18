using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayerAPI.DAL.Models
{
    public partial class Project
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProjectName { get; set; }
        public string AcademicInstitution { get; set; }
        public string AcademicAdvisor { get; set; }
        public string Description { get; set; }
        public bool IsSensetive { get; set; }
        public string SensetiveInfo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte Product { get; set; }
        public byte Status { get; set; }
        public string Requester { get; set; }
        public string StatusChagnedDesc { get; set; }

        public virtual User User { get; set; }
    }
}

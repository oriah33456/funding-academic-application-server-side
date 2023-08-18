using DataModels.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.DTO
{
    public  class ProjectDTO
    {
        public int userID { get; set; }
        public int Id { get; set; }
        public string Requester { get; set; }
        public string ProjectName { get; set; }
        public string AcademicInstitution { get; set; }
        public string AcademicAdvisor { get; set; }
        public string Description { get; set; }
        public bool IsSensetive { get; set; }
        public string SensetiveInfo { get; set; }

        public string StatusChagnedDesc { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Product Product { get; set; }
        public Status Status { get; set; }
    }
}

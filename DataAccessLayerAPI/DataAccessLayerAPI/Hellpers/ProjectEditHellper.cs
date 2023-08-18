using DataAccessLayerAPI.DAL.Models;
using DataModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DataAccessLayerAPI.Hellpers
{
    public class ProjectEditHellper
    {
        internal Project UpdateProject(ProjectDTO src, Project dest)
        {
          
            dest.Product = (byte)src.Product;
            dest.ProjectName = src.ProjectName;
            dest.AcademicAdvisor = src.AcademicAdvisor;
            dest.AcademicInstitution = src.AcademicInstitution;
            dest.Description = src.Description;
            dest.StartDate = src.StartDate;
            dest.EndDate = src.EndDate;
            dest.IsSensetive = src.IsSensetive;
            dest.SensetiveInfo = src.SensetiveInfo;
            return dest;

        }
    }
}

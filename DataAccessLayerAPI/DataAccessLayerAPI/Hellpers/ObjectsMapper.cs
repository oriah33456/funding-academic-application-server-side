using DataAccessLayerAPI.DAL.Models;
using DataModels.DTO;
using DataModels.DTO.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayerAPI.Hellpers
{
    public class ObjectsMapper
    {
        internal ProjectDTO GetProjectDTO(Project project)
        {
            return ProjectToDTOConverter(project);
        }

        private ProjectDTO ProjectToDTOConverter(Project project)
        {

            return new ProjectDTO()
            {
                Id = project.Id,
                Requester = project.Requester,
                userID=project.UserId,
                ProjectName = project.ProjectName,
                AcademicInstitution = project.AcademicInstitution,
                AcademicAdvisor = project.AcademicAdvisor,
                Description = project.Description,
                IsSensetive = project.IsSensetive,
                SensetiveInfo = project.SensetiveInfo,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Product = (Product)project.Product,
                Status = (Status)project.Status
            };
        }

        private Project ProjectDTOToProjectConverter(ProjectDTO project)
        {
            return new Project()
            {

                Requester = project.Requester,
                ProjectName = project.ProjectName,
                AcademicInstitution = project.AcademicInstitution,
                AcademicAdvisor = project.AcademicAdvisor,
                Description = project.Description,
                IsSensetive = project.IsSensetive,
                SensetiveInfo = project.SensetiveInfo,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Product = (byte)project.Product,
                Status = (byte)project.Status
            };
        }

        internal IEnumerable<ProjectDTO> GetProjectsDTO(List<Project> projects)
        {
            List<ProjectDTO> projectDTOs = new List<ProjectDTO>();
            foreach (var project in projects)
            {
                projectDTOs.Add(ProjectToDTOConverter(project));
            }
            return projectDTOs;
        }
 

        internal Project GetProject(ProjectDTO projectDTO)
        {
            return ProjectDTOToProjectConverter(projectDTO);
        }



        internal UserDTO GetUserDTO(User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                FullName=user.FullName,
                Email=user.Email

            };
        }




    }
}

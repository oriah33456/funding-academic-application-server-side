using DataAccessLayerAPI.DAL.Models;
using DataAccessLayerAPI.Hellpers;
using DataModels.DTO;
using DataModels.DTO.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayerAPI.Services
{
    public class DataAccessService
    {
        private ObjectsMapper _mapper;
        private FundingAcademicDBContext _fundingAcademicDBContext;
        ProjectEditHellper _projectEditHellper;

        public DataAccessService(FundingAcademicDBContext homeTestContext, ObjectsMapper mapper,
            ProjectEditHellper projectEditHellper)
        {
            _fundingAcademicDBContext = homeTestContext;
            _mapper = mapper;
            _projectEditHellper = projectEditHellper;
        }


        public UserDTO CreateUser(UserDTO user)
        {
            try
            {
                if (user.Password != null)      
                {
                    var newUser = new User()
                    {
                        Email = user.Email,
                        FullName = user.FullName,
                        Password = user.Password
                    };
                    _fundingAcademicDBContext.Add(newUser);
                    var res = _fundingAcademicDBContext.SaveChanges();
                    user.Id = newUser.Id;
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal UserDTO CanLogin(UserLogin userdto)
        {
            
           var user= _fundingAcademicDBContext.Users.Where(user => user.Email == userdto.Email
             && user.Password == userdto.Password).FirstOrDefault();
            if (user != null)
                return _mapper.GetUserDTO(user);

            else return null;

        }


        internal UserDTO GetUserNameById(int id)
        {
           var user = _fundingAcademicDBContext.Users.Find(id);
            if (user != null)
                return _mapper.GetUserDTO(user);
            //return (new { Nme = user.FullName }).ToString();
            else
                return null;

        }

        internal bool CheckUserByUserId(int id)
        {
            var user = _fundingAcademicDBContext.Users.Find(id);
            if (user != null)
                return true;
       
            else
                return false;

        }


        internal async Task<bool> SetUserToAdmin(int id)
        {
            var user = _fundingAcademicDBContext.Users.Find(id);
            if (user != null)
            {
                _fundingAcademicDBContext.Admins.Add(new Admin() { UserId = user.Id });
                await _fundingAcademicDBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        internal bool EditProject(ProjectDTO project, int id)
        {
            try
            {
                var pr = _fundingAcademicDBContext.Projects.Find(id);
                pr = _projectEditHellper.UpdateProject(project, pr);
                _fundingAcademicDBContext.Update(pr);
                _fundingAcademicDBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }

        internal bool UpdateStatus(int id, byte status, string statusChagnedDesc)
        {
            if (!string.IsNullOrEmpty(statusChagnedDesc))
            {
                var pr = _fundingAcademicDBContext.Projects.Find(id);
                pr.Status = status;
                pr.StatusChagnedDesc = statusChagnedDesc;
                _fundingAcademicDBContext.Projects.Update(pr);
                _fundingAcademicDBContext.SaveChanges();
                    return true;
            }
            return false;
        }

        internal bool CreateProject(ProjectDTO projectDTO, int userId)
        {
            Project project = _mapper.GetProject(projectDTO);
            project.UserId = userId;
            _fundingAcademicDBContext.Projects.Add(project);
            _fundingAcademicDBContext.SaveChanges();
            return true;
        }

        public ProjectDTO GetProjectById(int projectId)
        {
            try
            {
                var project = _fundingAcademicDBContext.Projects.Find(projectId);
                var projectDTO = _mapper.GetProjectDTO(project);
                return projectDTO;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<ProjectDTO> GetNewProjectsByStstus(int userId, byte status)
        {
            try
            {
                if (_fundingAcademicDBContext.Admins.Any(us => us.UserId == userId))
                {
                    var projects = _fundingAcademicDBContext.Projects.Where(pr => (Status)pr.Status == (Status)status);
                    if (projects != null)
                    {
                        var projectsDTO = _mapper.GetProjectsDTO(projects.ToList());
                        return projectsDTO;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<ProjectDTO> GetProjectByUserId(int userId)
        {
            try
            {

                var projects = _fundingAcademicDBContext.Projects.Where(x => x.UserId == userId);
                if (projects != null)
                {
                    var projectsDTO = _mapper.GetProjectsDTO(projects.ToList());
                    return projectsDTO;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public IEnumerable<AdminDTO> GetAdminByUserId(int userId)
        {
            try
            {
                var checkAdmin = _fundingAcademicDBContext.Admins.Where(x => x.UserId == userId).FirstOrDefault(); 
                // var checkAdmin = _fundingAcademicDBContext.Admins.Find(userId);
                if (checkAdmin != null)
                {

                 var    adminList = (from admins in _fundingAcademicDBContext.Admins
                            join users in _fundingAcademicDBContext.Users on admins.UserId equals users.Id
                            where admins.UserId == users.Id
                            select new AdminDTO()
                            {
                                FullName = users.FullName,
                                UserId = users.Id
                            });
                  
                    return adminList;
                }
                return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public bool GetAdminById(int userId)
        {
            try
            {

                //var checkAdmin = _fundingAcademicDBContext.Admins.Find(userId);
                var checkAdmin = _fundingAcademicDBContext.Admins.Where(x => x.UserId == userId).FirstOrDefault();
                if (checkAdmin != null)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool RemoveAdminById(int id, AdminDTO admin)
        {
            try
            {

                var adminToRemove = _fundingAcademicDBContext.Admins.Where(x => x.UserId==id).FirstOrDefault(); 
                //var adminToRemove = _fundingAcademicDBContext.Admins.Find(id);
                if (adminToRemove != null&& admin.UserId!= adminToRemove.UserId)
                {
                    _fundingAcademicDBContext.Admins.Remove(adminToRemove);
                    _fundingAcademicDBContext.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

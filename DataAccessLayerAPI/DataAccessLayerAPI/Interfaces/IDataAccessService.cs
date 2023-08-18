using DataModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayerAPI.Interfaces
{
    public interface IDataAccessService
    {
        UserDTO CreateUser(UserDTO user);
        UserDTO CanLogin(UserLogin userdto);
        UserDTO GetUserNameById(int id);
        bool CheckUserByUserId(int id);
        Task<bool> SetUserToAdmin(int id);
        bool EditProject(ProjectDTO project, int id);
        bool UpdateStatus(int id, byte status, string statusChagnedDesc);
        bool CreateProject(ProjectDTO projectDTO, int userId);
        ProjectDTO GetProjectById(int projectId);
        IEnumerable<ProjectDTO> GetNewProjectsByStstus(int userId, byte status);
        IEnumerable<ProjectDTO> GetProjectByUserId(int userId);
        IEnumerable<AdminDTO> GetAdminByUserId(int userId);
        bool GetAdminById(int userId);
        bool RemoveAdminById(int id, AdminDTO admin);

    }
}

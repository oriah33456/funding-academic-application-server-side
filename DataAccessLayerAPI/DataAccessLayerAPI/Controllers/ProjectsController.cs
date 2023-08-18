using AutoMapper;
using DataAccessLayerAPI.DAL.Models;
using DataAccessLayerAPI.Hellpers;
using DataAccessLayerAPI.Services;
using DataModels.DTO;
using DataModels.DTO.Enums;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayerAPI.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {

        private DataAccessService _dataAccessService;
        private readonly ILogger<ProjectsController> _logger;
        private FundingAcademicDBContext _homeTestContext;


        public ProjectsController(ILogger<ProjectsController> logger, DataAccessService dataAccessService)
        {
            _logger = logger;
            _dataAccessService = dataAccessService;


        }
        #region Get
        [HttpGet]
        [Route("{projectId}")]
        public ProjectDTO GetProjectById(int projectId)
        {

            return _dataAccessService.GetProjectById(projectId);
        }

       
        //
        [HttpGet]
        [Route("user/{userId}")]
        public IEnumerable<ProjectDTO> GetProjectsByUserId(int userId)
        {
            return _dataAccessService.GetProjectByUserId(userId);
        }

        [HttpGet]
        public IEnumerable<ProjectDTO> GetProjectsByStatus(int userId, byte status)
        {
            return _dataAccessService.GetNewProjectsByStstus(userId, status);
        }
        #endregion Get

        #region Post
        [HttpPost]
        [Route("create/{userId}")]
        public bool CreateProject(int userId, [FromBody] ProjectDTO project)
        {
         
            return _dataAccessService.CreateProject(project, userId);
        }
        #endregion Post

        #region Put
        [HttpPut]
        [Route("status/{id}/{status}")]
        public bool UpdateProjectStatus(int id, byte status ,[FromBody] string statusChagnedDesc)
            {
            
            return _dataAccessService.UpdateStatus(id, status, statusChagnedDesc);
        }

        [HttpPut]
        [Route("project/{id}")]
        public bool EditProject(int id, [FromBody] ProjectDTO project)
        {
            return _dataAccessService.EditProject(project, id);
        }
        #endregion Put
    }
}

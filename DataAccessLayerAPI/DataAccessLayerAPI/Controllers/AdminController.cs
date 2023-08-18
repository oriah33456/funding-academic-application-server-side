using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using DataAccessLayerAPI.Services;
using DataModels.DTO;
using DataAccessLayerAPI.DAL.Models;

namespace DataAccessLayerAPI.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private DataAccessService _dataAccessService;
        private readonly ILogger<AdminController> _logger;
        private FundingAcademicDBContext _homeTestContext;


        public AdminController(ILogger<AdminController> logger, DataAccessService dataAccessService)
        {
            _logger = logger;
            _dataAccessService = dataAccessService;


        }

        [HttpGet]
        [Route("{userId}")]
        public IEnumerable<AdminDTO> GetAdminsByUserId(int userId)
        {
            return _dataAccessService.GetAdminByUserId(userId);
        }

        [HttpGet]
        [Route("isadmin/{userId}")]
        public bool GetAdminDetails(int userId)
        {
            return _dataAccessService.GetAdminById(userId);
        }


        [HttpPut]
        [Route("remove/{id}")]
        public bool RemoveAdminDetails( int id,[FromBody]AdminDTO admin )
        {
            return _dataAccessService.RemoveAdminById(id, admin);
        }


    }
}

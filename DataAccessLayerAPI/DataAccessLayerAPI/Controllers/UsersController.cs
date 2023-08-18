using DataAccessLayerAPI.DAL.Models;
using DataAccessLayerAPI.Services;
using DataModels.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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
    public class UsersController : ControllerBase
    {

        private DataAccessService _dataAccessService;
        private readonly ILogger<UsersController> _logger;
        public UsersController(ILogger<UsersController> logger, DataAccessService dataAccessService)
        {
            _logger = logger;
            _dataAccessService = dataAccessService;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<UserDTO> Login(UserLogin user)
        {
            return _dataAccessService.CanLogin(user);
        }

        [HttpPost]
        [Route("create")]
        public UserDTO CreateUser(UserDTO user)
        {
            return _dataAccessService.CreateUser(user);
        }

        [HttpGet]
        [Route("name/{id}")]
        public UserDTO GetUserNameById(int id)
        {
            return _dataAccessService.GetUserNameById(id);
        }

        [HttpGet]
        [Route("{id}")]
        public bool CheckUserByUserId(int id)
        {
            return _dataAccessService.CheckUserByUserId(id);
        }



        [Route("admin/{userId}")]
        [HttpPut]
        public async Task<bool> UpdateUserToAdmin(int userId)
        {
            try
            {

                return await _dataAccessService.SetUserToAdmin(userId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

      
    }
}

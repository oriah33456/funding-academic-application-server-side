using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.DTO
{
   public  class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}

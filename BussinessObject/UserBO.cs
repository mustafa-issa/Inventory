using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessObject
{
    public class UserBO // Declare Class Public to Access any where 
    {
        //Declaring UserRegistration Variables

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }


    }
}


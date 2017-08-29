﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class
using System.Data;

namespace Bussinesslogic
{
    public class UserBL
    {
        public int SaveUserRegisrationBL(UserBO objUserBL) // passing Bussiness object Here 
        {
            try
            {
                UserDA objUserda = new UserDA(); // Creating object of Dataccess
                return objUserda.AddUserDetails(objUserBL); // calling Method of DataAccess 
            }
            catch
            {
                throw;
            }
        }

        public int SelectUserBL(UserBO objUserBL) 
        {
            try
            {
                UserDA objUserda = new UserDA(); 
                return objUserda.SelectUser(objUserBL); 
            }
            catch
            {
                throw;
            }
        }


    }
}

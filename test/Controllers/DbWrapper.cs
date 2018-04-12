﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class DbWrapper : Controller
    {
        public DbWrapper()
        {

        }
        public IQueryable<User> getUsers()
        {
            var dataContext = new UserDataContext();
            var users = (from m in dataContext.Users
                         select m);
            return users;
        }
        public void addUser(User user)
        {
            var dataContext = new UserDataContext();
            dataContext.Users.InsertOnSubmit(user);
            dataContext.SubmitChanges();
        }
        public User getUserById(int? id)
        {
           
            var dataContext = new UserDataContext();
            var query = (from m in dataContext.Users
                            where m.Id == id
                            select m);
            User user = query.First();

            return user;
            
        }

        public void updateUser(int id , User user)
        {
            var dataContext = new UserDataContext();
            var query = (from m in dataContext.Users
                         where m.Id == id
                         select m);
            query.First().Id = user.Id;
            query.First().username = user.username;
            query.First().password = user.password;
            query.First().type = user.type;
            dataContext.SubmitChanges();
        }

        public void deleteUserById(int? id)
        {
            var dataContext = new UserDataContext();
            var query = (from m in dataContext.Users
                         where m.Id == id
                         select m);
            dataContext.Users.DeleteOnSubmit(query.First());
            dataContext.SubmitChanges();
        }
    }
}
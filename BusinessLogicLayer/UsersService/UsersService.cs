using DataAccessLayer.UserRepository;
using Model.Entity;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.UsersService
{
    public class UsersService
    {
        private readonly IUserRepository usersRepo;

        public UsersService()
        {
            usersRepo = new UserRepository();
        }

        public List<UserViewModel> GetUsers()
        {
            return usersRepo.GetAll().Select(x => new UserViewModel
            {
                UserId = x.UserId,
                Full_name = x.Full_name, 
                ContactNo = x.ContactNo,
                Email = x.Email
            }).ToList();
        }

        public void AddUser(UserViewModel models)
        {
            Users users = new Users();
            users = usersRepo.FindBy(o => o.UserId == models.UserId).FirstOrDefault();
            if (users == null)
            {
                Users newUser = new Users();
                newUser.Full_name = models.Full_name;
                newUser.ContactNo = models.ContactNo;
                newUser.Email = models.Email;
                usersRepo.Add(newUser);
                usersRepo.Save();
            }

        }

        public UserViewModel GetUserById(long UserId)
        {
            return usersRepo.FindBy(o => o.UserId == UserId).Select(o => new UserViewModel {
                UserId = o.UserId, 
                Full_name = o.Full_name,
                ContactNo = o.ContactNo,
                Email = o.Email
            }).FirstOrDefault();
        }

        public void EditUser(UserViewModel userModel)
        {
            Users user = new Users();
            user = usersRepo.FindBy(o => o.UserId == userModel.UserId).FirstOrDefault();
            if (user != null)
            {

                user.Full_name = userModel.Full_name;
                user.ContactNo = userModel.ContactNo;
                user.Email = userModel.Email;
                usersRepo.Edit(user);
                usersRepo.Save();
            }
        }

        public String DeleteUserById(long UserId)
        {
            try
            {
                Users user = new Users();
                user = usersRepo.FindBy(o => o.UserId == UserId).FirstOrDefault();
                if (user != null)
                {
                    usersRepo.Delete(user);
                    usersRepo.Save();
                }
                return ("Delete Successful");
            }
            catch (Exception)
            {
                return ("error updating data");
            }
           
        }

 
    }
}

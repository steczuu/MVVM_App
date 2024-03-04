using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WMS_app.Model
{
    public interface IUserDepository
    {
            bool AuthenticateUser(NetworkCredential networkCredential);
            void Add(UserModel userModel);
            void Edit(UserModel userModel);
            void Remove(int id);
            UserModel GetById(int id);
            UserModel GetByFirstName(string firstName);
            IEnumerable<UserModel> GetAll();
    }
}

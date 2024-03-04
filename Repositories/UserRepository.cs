using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WMS_app.Model;


namespace WMS_app.Repositories
{
    public class UserRepository : RepositoryBase, IUserDepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential networkCredential)
        {
            bool validUser;
            using(var connection = CreateConnection())
            using (var command = new SQLiteCommand())
            {
                command.Connection = connection;
                command.CommandText = "select * from [Employees] where [Name] = @_firstName and [Password]=@_password";
                command.Parameters.Add("@_firstName", System.Data.DbType.String).Value=networkCredential.UserName;
                command.Parameters.Add("@_password", System.Data.DbType.String).Value = networkCredential.Password;
                validUser=command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetByFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

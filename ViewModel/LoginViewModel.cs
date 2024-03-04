using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WMS_app.Model;
using WMS_app.Repositories;

namespace WMS_app.ViewModel
{
    public class LoginViewModel : ViewModelBase  
    {
        private string _firstName;
        private SecureString _password;
        private bool _isVisible = true;
        private IUserDepository _userDepository;

        public string FirstName {
            get 
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        
        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public bool IsVisible
        { 
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel()
        {
            _userDepository = new UserRepository();
            LoginCommand = new RelayCommand(ExecuteLoginCommand,CanExecuteLoginCommand);
            RegisterCommand = new RelayCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
        }

        private bool CanExecuteRegisterCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(FirstName) || Password == null)
                validData = false;
            else
                validData = true;

            return validData;
        }

        private void ExecuteRegisterCommand(object obj)
        {
            
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if(string.IsNullOrWhiteSpace(FirstName) || Password==null ) 
                validData = false;
            else 
                validData = true;  

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = _userDepository.AuthenticateUser(new NetworkCredential(FirstName,Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(FirstName),null);
                IsVisible = false;
                Trace.WriteLine("Correct");
            }
            else
            {
                throw new Exception("Invalid firstname or password");
            }
        }
    }
}

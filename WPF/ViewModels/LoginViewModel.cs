using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Command;

namespace WPF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        IAuthManager authManager;
        public ICommand loginCommand { get; set; }
        public ICommand exitCommand { get; set; }

        string login;
        string password;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            private get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        //public LoginViewModel() { }
        public LoginViewModel(IAuthManager authManager)
        {
            loginCommand = new LoginCommand(this);
            exitCommand = new ExitCommand(this);
            this.authManager = authManager;
        }

        public bool LoginButton()
        {
            return authManager.Login(login, password);
        }

        public Action LoginSuccess { get; set; }
        public Action LoginFailed { get; set; }
        public Action Exit { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}

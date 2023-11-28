using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels;

namespace WPF.Command
{
    internal class LoginCommand : ICommand
    {
        private LoginViewModel loginViewModel;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public LoginCommand(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (loginViewModel.LoginButton())
            {
                loginViewModel.LoginSuccess?.Invoke();
            }
            else
            {
                loginViewModel.LoginFailed?.Invoke();
            }
        }

    }
}

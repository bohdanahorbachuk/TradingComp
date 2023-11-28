using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels;

namespace WPF.Command
{ 
    internal class LogOutCommand : ICommand
    {
        private SupplyListViewModel supplyListViewModel;

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

        public LogOutCommand(SupplyListViewModel loginViewModel)
        {
            this.supplyListViewModel = loginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            supplyListViewModel.LogOut?.Invoke();
        }
    }
}

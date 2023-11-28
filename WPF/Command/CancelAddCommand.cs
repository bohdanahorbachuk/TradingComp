using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels;

namespace WPF.Command
{
    internal class CancelAddCommand : ICommand
    {
        AddSupplyViewModel asvm;

        public CancelAddCommand(AddSupplyViewModel asvm)
        {
            this.asvm = asvm;
        }

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

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            asvm.Exit?.Invoke();
        }
    }
}

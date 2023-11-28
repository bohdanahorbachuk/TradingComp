using AutoMapper;
using BusinessLogic.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Command;
using WPF.Models;

namespace WPF.ViewModels
{
    public class AddSupplyViewModel : INotifyPropertyChanged
    {
        ISupplyManager supplyManager;
        SupplyModel supplyMod;
        public SupplyModel SupplyMod
        {
            get
            {
                return supplyMod;
            }
            set
            {
                supplyMod = value;
                OnPropertyChanged(nameof(SupplyMod));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public ICommand addCommand { get; set; }
        public ICommand cancelAddCommand { get; set; }

        public AddSupplyViewModel(ISupplyManager supplyManager, SupplyDTO supply = null)
        {
           
            addCommand = new AddCommand(this);
            cancelAddCommand = new CancelAddCommand(this);
            this.categoryv = supplyManager.GetNameCategory();
            this.persons = supplyManager.GetPersonLogin();

        }

        private List<string> categoryv;
        public List<string> CategoryName
        {
            get => categoryv;
            set
            {
                categoryv = value;
                OnPropertyChanged("CategoryName");
            }
        }

        private List<string> persons;
        public List<string> PeronLogin
        {
            get => persons;
            set
            {
                persons = value;
                OnPropertyChanged("PeronLogin");
            }
        }

        public Action Save { get; set; }
        public Action Exit { get; set; }

        public bool isValid()
        {
            return supplyMod.isValid();
        }

        public void Add()
        {
            var p = new SupplyDTO();
            supplyManager.AddSupply(p);
        }
    }
}

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
    public class SupplyListViewModel : INotifyPropertyChanged
    {
        ISupplyManager supplyManager;
        SupplyDTO supply;
        List<SupplyDTO> supplyList;
        bool listSorted;
        string searchSupply;
        int IdCatrgory, IdSupply;

        public string SearchSupply
        {
            get
            {
                return searchSupply;
            }
            set
            {
                searchSupply = value;
                OnPropertyChanged(nameof(SearchSupply));
            }
        }

        public bool ListSorted
        {
            get
            {
                return listSorted;
            }
            set
            {
                listSorted = value;
                OnPropertyChanged(nameof(ListSorted));
            }
        }

        public SupplyDTO Supply
        {
            get
            {
                return supply;
            }
            set
            {
                supply = value;
                OnPropertyChanged(nameof(Supply));
            }
        }

        public List<SupplyDTO> SupplyList
        {
            get
            {
                return supplyList;
            }
            set
            {
                supplyList = value;
                OnPropertyChanged(nameof(SupplyList));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public ICommand addCommand { get; set; }
        public ICommand deleteCommand { get; set; }
        public ICommand sortSupplyCommand { get; set; }
        public ICommand getSupplyCommand { get; set; }
        public ICommand logoutCommand { get; set; }
        public ICommand searchCommand { get; set; }
        public ICommand showAddSupplyCommand { get; set; }

        public SupplyListViewModel(ISupplyManager supplyManager)
        {
            deleteCommand = new DeleteCommand(this);
            sortSupplyCommand = new SortListCommand(this);
            getSupplyCommand = new GetListCommand(this);
            logoutCommand = new LogOutCommand(this);
            searchCommand = new SearchCommand(this);
            showAddSupplyCommand = new InfoCommand(this);
            this.categoryv = supplyManager.GetNameCategory();

            SupplyList = supplyManager.GetListOfSupply();
            this.supplyManager = supplyManager;
            listSorted = false;
        }

        public Action LogOut;
        public Action ShowAddS;

        public void GetSupplyList()
        {
            listSorted = false;
            SupplyList = supplyManager.GetListOfSupply();
        }

        public void GetSortedSupply()
        {
            listSorted = true;
            SupplyList = supplyManager.GetSort();
        }

        public void Delete()
        {
            if (supply != null)
            {
                supplyManager.DeleteSupply(IdSupply);
                SupplyList = supplyManager.GetListOfSupply();
            }
        }

        public void Search()
        {
            if (!String.IsNullOrEmpty(SearchSupply))
            {
                var supplys = new List<SupplyDTO>();
                if (!String.IsNullOrEmpty(searchSupply))
                {
                    supplys = supplyManager.SearchGoodsByCategory(IdCatrgory);
                }
                if (supplys.Count != 0)
                {
                    SupplyList = supplys;
                }
                else
                {
                    MessageBox.Show("No supply", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    SupplyList = supplyManager.GetListOfSupply();
                }
            }
            else
            {
                SupplyList = supplyManager.GetListOfSupply();
            }
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


        public void SupplyInfo(bool cmdInfo = false)
        {
            AddSupplyViewModel asvm = (supply != null && cmdInfo) ?
            new AddSupplyViewModel(supplyManager, Supply) :
            new AddSupplyViewModel(supplyManager);

            WindowAddSupply pI = new WindowAddSupply(asvm);
            var temp = pI.ShowDialog() ?? false;
            if (temp)
            {
                SupplyList = supplyManager.GetListOfSupply();
            } 
        }
    }
}

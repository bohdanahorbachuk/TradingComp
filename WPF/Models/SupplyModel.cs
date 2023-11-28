using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models
{
    public class SupplyModel : INotifyPropertyChanged, IDataErrorInfo
    {
 
        string nameGoods;
        int number;
        int priceUnit;


        public int ID_Supply { get; set; }
        public int ID_Person { get; set; }
        public int ID_Category { get; set; }
        public string NameGoods
        {
            get
            {
                return nameGoods;
            }
            set
            {
                nameGoods = value;
                OnPropertyChanged(nameof(NameGoods));
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        public int PriceUnit
        {
            get
            {
                return priceUnit;
            }
            set
            {
                priceUnit = value;
                OnPropertyChanged(nameof(PriceUnit));
            }
        }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }

        public bool isEmpty()
        {
            return this.PriceUnit == 0 &&
                Number == 0 &&
                NameGoods == null &&
                ID_Category == 0 &&
                ID_Person == 0 &&
                Number ==0 &&
                PriceUnit == 0;
        }

        public bool isValid()
        {
            return String.IsNullOrWhiteSpace(Error);
        }

        string IDataErrorInfo.this[string property]
        {
            get
            {
                return GetErrorInfo(property);
            }
        }

        string GetErrorInfo(string property)
        {
            switch (property)
            {
                case nameof(NameGoods):
                    return ValidateNameGoods();
                default:
                    return null;
            }
        }

        string ValidateNameGoods()
        {
            if (String.IsNullOrEmpty(NameGoods))
            {
                return "Enter name goods";
            }
            if (NameGoods.Any(x => Char.IsWhiteSpace(x)))
            {
                return "Can not have white spaces";
            }
            return null;
        }

        string[] validatedProperties
        {
            get
            {
                return new string[] {
                    nameof(NameGoods),
                };
            }
        }

        public string Error
        {
            get
            {
                StringBuilder strb = new StringBuilder();
                foreach (var item in validatedProperties)
                {
                    var err = GetErrorInfo(item);
                    if (!string.IsNullOrWhiteSpace(err))
                    {
                        strb.AppendLine(err);
                    }
                }
                return strb.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}

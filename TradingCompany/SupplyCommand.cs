using System;
using DAL.ADO;
using DTO;
using System.Configuration;

namespace TradingCompany
{
    public class SupplyCommand
    {
        public static void CreateSupply(SupplyDAL supplyDal)
        {
            string connStr = ConfigurationManager.ConnectionStrings["TraidingCompany"].ConnectionString;
            var personDal = new PersonDAL(connStr);
            var categoryDal = new CategoryDAL(connStr);

            Console.WriteLine("Creating New Supply");
            Console.WriteLine("Select a person id: ");
            PersonCommand.GetAllPerson(personDal);
            string _personId = (Console.ReadLine());
            int _person2 = Convert.ToInt32(_personId);

            Console.WriteLine("Select a category id: ");
            CategoryCommand.GetAllCategory(categoryDal);
            string _catId = (Console.ReadLine());
            int _cat2 = Convert.ToInt32(_catId);

            Console.WriteLine("Input NameGoods: ");
            string _nameGoods = Console.ReadLine();
            Console.WriteLine("Input Number: ");
            string _num = Console.ReadLine();
            int _num2 = Convert.ToInt32(_num);
            Console.WriteLine("Input price unit: ");
            string _pu = Console.ReadLine();
            int _put = Convert.ToInt32(_pu);


            SupplyDTO mySupply = new SupplyDTO
            {
                PersonID = _person2,
                CategoryID = _cat2,
                NameGoods = _nameGoods,
                Number = _num2,
                PriceUnit = _put
            };

            try
            {
                mySupply = supplyDal.CreatSupply(mySupply);
                Console.WriteLine($"New SupplyID is {mySupply.ID_Supply}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Data inputted incorrectly.");
            }
        }

        public static void GetAllSupply(SupplyDAL supplyDal)
        {
            var supply = supplyDal.GetAllSupply();
            Console.WriteLine("Supply:");
            foreach (var s in supply)
            {
                Console.WriteLine($"{s.CategoryID}\t{s.PersonID}\t{s.ID_Supply}\t{s.NameGoods}\t\t{s.Number}\t{s.PriceUnit}\t{s.RowInsertTime}\t{s.RowUpdateTime}");
            }
            
        }

        public static void DeleteSupply(SupplyDAL supplyDal)
        {
            Console.WriteLine("Deleting Supply");
            Console.WriteLine("Input SupplyID: ");
            string ids = Console.ReadLine();
            int id = Convert.ToInt32(ids); supplyDal.DeleteSupply(id);
            Console.WriteLine("Successfully deleted");
        }

        public static void UpdateSupply(SupplyDAL supplyDal)
        {
            Console.WriteLine("Updating supply");
            Console.WriteLine("Input SupplyID: ");
            string connStr = ConfigurationManager.ConnectionStrings["TraidingCompany"].ConnectionString;
            var supDal = new SupplyDAL(connStr);
            GetAllSupply(supDal);

            string ids = Console.ReadLine();
            int id = Convert.ToInt32(ids);

            SupplyDTO mySupply = supplyDal.GetSupplyById(id);

            if (mySupply is null)
            {
                Console.WriteLine("Invalid input!\n");
                return;
            }

            Console.WriteLine("~ Updating Supply:",
            mySupply.PersonID,
            mySupply.CategoryID,
            mySupply.NameGoods,
            mySupply.Number,
            mySupply.PriceUnit
            );
            try
            {
                while (true)
                {
                    Console.WriteLine(@"
        1 - update Id_Person
        2 - update ID_Category
        3 - update name goods
        4 - update number
        5 - update price unit

");

                    string m = Console.ReadLine();
                    Console.WriteLine("\t");
                    switch (m)
                    {
                        case "1":
                            Console.WriteLine("Input PersonID: ");
                            var perDal = new PersonDAL(connStr);
                            PersonCommand.GetAllPerson(perDal);
                            string idst = Console.ReadLine();
                            int idr = Convert.ToInt32(ids);
                            mySupply.PersonID = idr;
                            mySupply.RowUpdateTime = DateTime.UtcNow;
                            mySupply = supplyDal.UpdateSupply(mySupply, id);
                            Console.WriteLine($"Updated successfully!");
                            break;
                        case "2":
                            Console.WriteLine("Input CategoryID: ");
                            mySupply.CategoryID = Convert.ToInt32(Console.ReadLine());
                            var catDal = new CategoryDAL(connStr);
                            CategoryCommand.GetAllCategory(catDal);                            
                            mySupply.CategoryID = Convert.ToInt32(Console.ReadLine());
                            mySupply.RowUpdateTime = DateTime.UtcNow;
                            mySupply = supplyDal.UpdateSupply(mySupply, id);
                            Console.WriteLine($"Updated successfully!");
                            break;
                            
                        case "3":
                            Console.WriteLine("Input new Name goods: ");
                            mySupply.NameGoods = Console.ReadLine();
                            mySupply.RowUpdateTime = DateTime.UtcNow;
                            mySupply = supplyDal.UpdateSupply(mySupply, id);
                            Console.WriteLine($"Updated successfully!");
                            break;
                        case "4":
                            Console.WriteLine("Input new number: ");
                            string b = Console.ReadLine();
                            mySupply.Number = Convert.ToInt32(b);
                            mySupply.RowUpdateTime = DateTime.UtcNow;
                            mySupply = supplyDal.UpdateSupply(mySupply, id);
                            Console.WriteLine($"Updated successfully!");
                            break;
                        case "5":
                            Console.WriteLine("Input new price unit: ");
                            mySupply.PriceUnit = Convert.ToInt32(Console.ReadLine());
                            mySupply.RowUpdateTime = DateTime.UtcNow;
                            mySupply = supplyDal.UpdateSupply(mySupply, id);
                            Console.WriteLine($"Updated successfully!");
                            break;
                        case "0": return;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("ERROR.");
            }
        }
    }
}

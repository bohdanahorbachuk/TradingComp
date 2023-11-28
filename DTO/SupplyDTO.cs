using System;


namespace DTO
{
    public class SupplyDTO
    {
        public int ID_Supply { get; set; }
        public int PersonID { get; set; }
        public int CategoryID { get; set; }
        public string NameGoods { get; set; }
        public int Number { get; set; }
        public int PriceUnit { get; set; }
        public DateTime RowInsertTime { get; set;}
        public DateTime RowUpdateTime { get; set; }
    }
}

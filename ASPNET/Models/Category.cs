using System.ComponentModel.DataAnnotations;

namespace ASPNET.Models
{
    public class Category
    {
        [Key]
        public int ID_Category { get; set; }
        public string CategoryName { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
    }
}

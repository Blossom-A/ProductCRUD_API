using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations; //used to set rules for validation, display, and relationships in models.

namespace Assignment1_redo1.Models //1
{
    public class Product
    {
        [Key] //this makes the productid the primary key
        public int ProductId { get; set; } //PascalCasing - first charater of each work is a capital

        public string Name { get; set; } = ""; // we initialize these properties with their default values to remove the warning of nullable

        public string Description { get; set; } = "";

        [Precision(18, 2)] //decimal(p, s) where p is the total number of digits and s is the number of decimal places -- for currency this one (18, 2) is fine
        public decimal Price { get; set; }
    }
    //After creating a model class, we can create a dB context class
    //The dB contect class will act as an intermediate between the db model classes and the physical db
}

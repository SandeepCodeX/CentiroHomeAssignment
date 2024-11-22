using System;
using System.Numerics;

namespace CentiroHomeAssignment.Models
{
    public class FileModel
    {
        public string OrderNumber { get; set; }
        public int OrderLineNumber { get; set; }
        public string ProductNumber { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductGroup { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
    }
}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CarDealership.Data.Models
//{
//    internal class Invoice
//    {
//        public int Id { get; set; }
//        [ForeignKey]
//        public int CustomerRefId { get; set; }
//        public Customer CustomerId  { get; set; }

//        public string InvoiceNumber { get; set; }

//        public DateTime InvoiceDate { get; set; }
//        public decimal Amount { get; set; }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcApplication1.Models
{
    public class TransactionModel
    {
        [Required]
        [DisplayName("Sender Account")]
        public int SenderAccountNo { get; set; }
        [Required]
        [DisplayName("Receiver Account")]
        public int ReceiverAccountNo { get; set; }
        [Required]
        [DisplayName("Amount")]
        public int Amount { get; set; }
    }
}
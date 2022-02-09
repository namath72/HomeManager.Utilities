using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeManager.Utilities
{
    public class TransactionDto
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public string Type { get; set; }
    }
}

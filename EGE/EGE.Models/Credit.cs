

using System;
using System.ComponentModel.DataAnnotations;

namespace EGE.Models
{
    public class Credit
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser Owner { get; set; }
        public bool IsUsed { get; set; }
        public string  Barcode { get; set; }
        public decimal Sum { get; set; }
        public Type Type { get; set; }
        public DateTime LastUsed { get; set; }
    }
}

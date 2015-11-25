using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using AutoMapper;
using EGE.Models;
using EGE.Web.Infrastructure;
using Type = EGE.Models.Type;

namespace EGE.Web.Models
{
    public class CreditInputModel : IMapFrom<Credit> 
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Barcode")]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Barcode { get; set; }

        [Required]
        [Range(1, 10000)]
        public decimal Sum { get; set; }

        [Required]
        public bool IsUsed { get; set; }

        public string OwnerId { get; set; }
       // public ApplicationUser Owner { get; set; }
     
        [Required]
        public Type Type { get; set; }

        public DateTime LastUsed { get; set; }
        
    }
}
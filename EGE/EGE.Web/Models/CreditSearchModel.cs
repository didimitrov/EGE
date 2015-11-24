using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EGE.Models;
using EGE.Web.Infrastructure;

namespace EGE.Web.Models
{
    public class CreditSearchModel:IMapFrom<Credit>
    {
        public int Id { get; set; }
        [Display(Name = "Баркод")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Трябва да е между {2} и {1} символа")]
        public string Barcode { get; set; }

        public int TotalRecords { get; set; }

        public List<Credit> Credits { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UnitOfWork.Domain.Entities;

namespace UnitOfWork.Web.Models.Home
{
    public class IndexViewModel
    {
        public IList<Product> Products { get; set; }

        [Required]
        public string ProductName { get; set; }
    }
}
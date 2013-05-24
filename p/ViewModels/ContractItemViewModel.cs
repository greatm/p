using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p.Models;
using System.Web.Mvc;

namespace p.ViewModels
{
    public class ContractItemViewModel
    {
        public ContractItem ci;
        public SelectList Products { get; set; }
    }
}
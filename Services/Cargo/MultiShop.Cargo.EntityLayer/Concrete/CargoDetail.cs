using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.EntityLayer.Concrete
{
    public class CargoDetail
    {
        public int CargoDetailId { get; set; }
        public string CargoSenderId { get; set; }
        public string ReceiverCustomer { get; set; }
        public int Barkod { get; set; }
        public int CargoCompanyId { get; set; }
        public CargoComponay CargoCompany { get; set; }
    }
    }

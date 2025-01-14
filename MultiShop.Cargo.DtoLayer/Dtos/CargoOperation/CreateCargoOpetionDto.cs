using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.Dtos.CargoOperation
{
    public class CreateCargoOpetionDto
    {
        public string Barkod { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}

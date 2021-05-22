using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Model
{
    public class Electronics : ProductBase
    {
        public ElectronicType ElectronicType { get; set; }
        public int EnergySaving {get;set;}
    }
}

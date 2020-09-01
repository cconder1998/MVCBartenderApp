using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBartenderApplication.Models
{
    public class OrderQueueModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public float Price { get; set; }
    }
}
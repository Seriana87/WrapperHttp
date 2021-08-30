using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Business.Model
{
    public class Source
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Url { get; set; }
        public int Crawl_rate { get; set; }
    }
}

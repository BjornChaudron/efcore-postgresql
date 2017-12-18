using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace efcore_postgresql_web_api.Entities
{
    public class Blog
    {
        [Key]
        public int? BlogId { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }

}

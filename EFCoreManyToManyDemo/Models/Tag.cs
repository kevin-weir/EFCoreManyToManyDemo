using System.Collections.Generic;

namespace EFCoreManyToManyDemo.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        public string TagName { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }
}

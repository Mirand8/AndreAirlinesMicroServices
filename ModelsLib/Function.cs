using System.Collections.Generic;

namespace ModelsLib
{
    public class Function
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Access> Access { get; set; }
    }
}
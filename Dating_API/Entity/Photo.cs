using System.ComponentModel.DataAnnotations.Schema;

namespace Dating_API.Entity
{
    [Table("Photes")]
    public class Photos
    {
        public int id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
    }
}
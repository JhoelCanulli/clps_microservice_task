using System.ComponentModel.DataAnnotations.Schema;

namespace BE_clps.Models
{
    [Table("Subjct")]
    public class Subjct
    {
        public int SubjctId { get; set; }
        public string DocumentSub { get; set; } = null!;
        public string NameSub { get; set; } = null!;
        public string CitySub { get; set; } = null!;
        public string DateSub { get; set; } = null!;
        public string LiveinSub { get; set; } = null!;
        public ICollection<Complaint>? Complaints { get; set; } = new List<Complaint>();
    }
}

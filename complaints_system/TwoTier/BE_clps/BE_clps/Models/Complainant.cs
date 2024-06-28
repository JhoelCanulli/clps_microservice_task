using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BE_clps.Models
{
    [Table("Complainant")]
    public class Complainant
    {
        public int ComplainantId { get; set; }
        public string DocumentCnant { get; set; } = null!;
        public string NameCnant { get; set; } = null!;
        public string CityCnant { get; set; } = null!;
        public string DateCnant { get; set; } = null!;
        public string LiveinCnant { get; set; } = null!;
        public ICollection<Complaint>? Complaints { get; set; } = new List<Complaint>();
    }
}

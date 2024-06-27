using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BE_clps.Models
{
    [Table("Complaint")]
    public class Complaint
    {
        public int ComplaintId { get; set; }
        public string ComplaintNumber { get; set; } = null!;
        public int CnantRIF { get; set; }
        public int SubRIF { get; set; }

        [JsonIgnore]
        public Complainant? Complainant { get; set; } = null!;

        [JsonIgnore]
        public Subjct? Subject { get; set; } = null!;

    }
}

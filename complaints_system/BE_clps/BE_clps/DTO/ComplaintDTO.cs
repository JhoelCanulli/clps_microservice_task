using BE_clps.Models;
using System.Text.Json.Serialization;

namespace BE_clps.DTO
{
    public class ComplaintDTO
    {
        public string Code { get; set; } = null!;
        public int CRIF { get; set; }
        public int SRIF { get; set; }

        [JsonIgnore]
        public Complainant? Cnant { get; set; } = null!;

        [JsonIgnore]
        public Subjct? Sjct { get; set; } = null!;
    }
}

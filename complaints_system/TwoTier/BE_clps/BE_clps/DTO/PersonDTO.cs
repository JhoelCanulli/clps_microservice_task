using BE_clps.Models;

namespace BE_clps.DTO
{
    public abstract class PersonDTO
    {
        public string DocN { get; set; } = null!;
        public string NCnt { get; set; } = null!;
        public string CCnt { get; set; } = null!;
        public string DCnt { get; set; } = null!;
        public string LCnt { get; set; } = null!;
        public ICollection<Complaint>? Cnts { get; set; } = new List<Complaint>();
    }
}

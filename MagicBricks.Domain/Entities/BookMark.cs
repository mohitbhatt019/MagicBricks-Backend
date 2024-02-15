using System.Text.Json.Serialization;

namespace MagicBricks.Domain.Entities
{
    public class BookMark
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public int PropertyId { get; set; }
        [JsonIgnore]
        public Property Property { get; set; }
        public string? ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser applicationUser { get; set; }

    }
}

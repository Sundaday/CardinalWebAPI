using System.Text.Json.Serialization;

namespace WebAppCardinal.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Stars { get; set; } = 0;
        [JsonIgnore]
        public List<Character> Characters { get; set; }

    }
}

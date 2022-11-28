using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAppCardinal.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string NameCharacter { get; set; } = string.Empty;
        public string RpgClass { get; set; } = "Knight";
        [ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Weapon Weapon { get; set; }
        public List<Skill> SkillList { get; set; }
    }
}

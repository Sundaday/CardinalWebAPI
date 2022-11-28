namespace WebAppCardinal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public List<Character> UserCharacters { get; set; }
    }
}

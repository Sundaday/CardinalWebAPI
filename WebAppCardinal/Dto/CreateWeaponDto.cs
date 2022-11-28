namespace WebAppCardinal.Dto
{
    public class CreateWeaponDto 
    {
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; } = 0;
        public int CharacterId { get; set; } = 0;
    }
}

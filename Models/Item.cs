namespace JDR.Models
{
    public class Item
    {
        public string Name { get; set; }
        public int StaminaBonus { get; set; }
        public int StrengthBonus { get; set; }
        public int IntellectBonus { get; set; }
        public int AgilityBonus { get; set; }
        public int SpiritBonus { get; set; }
        public int ArmorBonus { get; set; }
        public int DamageBonus { get; set; }
        public int CriticalChanceBonus { get; set; }
        public int HasteBonus { get; set; }
        public int DodgeBonus { get; set; }

        public Item(
            string name,
            int staminaBonus = 0,
            int strengthBonus = 0,
            int intellectBonus = 0,
            int agilityBonus = 0,
            int spiritBonus = 0,
            int armorBonus = 0,
            int damageBonus = 0,
            int criticalChanceBonus = 0,
            int hasteBonus = 0,
            int dodgeBonus = 0
        )
        {
            Name = name;
            StaminaBonus = staminaBonus;
            StrengthBonus = strengthBonus;
            IntellectBonus = intellectBonus;
            AgilityBonus = agilityBonus;
            SpiritBonus = spiritBonus;
            ArmorBonus = armorBonus;
            DamageBonus = damageBonus;
            CriticalChanceBonus = criticalChanceBonus;
            HasteBonus = hasteBonus;
            DodgeBonus = dodgeBonus;
        }
    }
}
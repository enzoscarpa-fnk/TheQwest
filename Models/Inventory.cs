using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace JDR.Models
{
    public class Inventory
    {
        public List<Item> weaponItems {get; private set; }
        public List<Item> armorItems {get; private set; }
        public Inventory()
        {
            weaponItems = new List<Item>();
            armorItems = new List<Item>();
        }
        public void CheckGameOver(bool isGameOver)
        {
            if (isGameOver)
            {
                Clear();
            }
        }
        public void Clear()
        {
            weaponItems.Clear();
            armorItems.Clear();
        }
        public int InventoryLenght = 12;
        public void AddWeaponItem(Item item)
        {
            if (item != null)
            {
                weaponItems.Add(item);
            }
        }
        public void AddArmorItem(Item item)
        {
            if (item != null)
            {
                armorItems.Add(item);
            }
        }
        public void RemoveItem(Item item)
        {
            if (item != null)
            {
                weaponItems.Remove(item);
            }
        // Pour mettre en place le remove de l'ancienne arme/armure (Si + puissant trouvé) 
        // if (item == weapon)
        //     {
        //         if (weaponItems.Contains(item))
        //         {
        //             weaponItems.Remove(item);
        //             Console.WriteLine($"Item {item.Name} removed from inventory.");
        //         }
        //         else
        //         {
        //             Console.WriteLine($"Item {item.Name} not found in inventory.");
        //         }
        //     }
        //     else if (item == armor)
        //     {
        //         if (armorItems.Contains(item))
        //         {
        //             armorItems.Remove(item);
        //             Console.WriteLine($"Item {item.Name} removed from inventory.");
        //         }
        //         else
        //         {
        //             Console.WriteLine($"Item {item.Name} not found in inventory.");
        //         }
        //     }
        }
        public void AfficherInventaire()
        {
            if (weaponItems.Count == 0)
            {
                Console.WriteLine("L'inventaire est vide");
                return;
            }
            foreach (var item in weaponItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}
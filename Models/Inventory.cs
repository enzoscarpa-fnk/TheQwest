using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace JDR.Models
{
    public class Inventory
    {
        public List<Item> Items {get; private set; }
        public Inventory()
        {
            Items = new List<Item>();
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
            Items.Clear();
        }
        public int InventoryLenght = 12;
        public void AddItem(Item item)
        {
            if (item != null)
            {
                Items.Add(item);
            }
        }
        public void RemoveItem(Item item)
        {
            if (item != null)
            {
                Items.Remove(item);
            }
        }
        public void AfficherInventaire()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("L'inventaire est vide");
                return;
            }
            foreach (var item in Items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
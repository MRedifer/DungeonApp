using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory
{
    public abstract class ObtainableItem
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int MaximumStackableQuantity { get; set; }

        protected ObtainableItem()
        {
            MaximumStackableQuantity = 1;
        }
    }
    public class Weapon : ObtainableItem
    {

    }
    public class InventorySystem
    {
        private const int MAXIMUM_SLOTS_IN_INVENTORY = 10;

        public readonly List<InventoryRecord> InventoryRecords = new List<InventoryRecord>();

        public void AddItem(ObtainableItem item, int quantityToAdd)
        {
            while (quantityToAdd > 0)
            {
               
                if (InventoryRecords.Exists(x => (x.InventoryItem.ID == item.ID) && (x.Quantity < item.MaximumStackableQuantity)))
                {
                    
                    InventoryRecord inventoryRecord =
                    InventoryRecords.First(x => (x.InventoryItem.ID == item.ID) && (x.Quantity < item.MaximumStackableQuantity));

                    
                    int maximumQuantityYouCanAddToThisStack = (item.MaximumStackableQuantity - inventoryRecord.Quantity);

                    
                    int quantityToAddToStack = Math.Min(quantityToAdd, maximumQuantityYouCanAddToThisStack);

                    inventoryRecord.AddToQuantity(quantityToAddToStack);

                    
                    quantityToAdd -= quantityToAddToStack;
                }
                else
                {
                    
                    if (InventoryRecords.Count < MAXIMUM_SLOTS_IN_INVENTORY)
                    {
                        
                        InventoryRecords.Add(new InventoryRecord(item, 0));
                    }
                    else
                    {
                        
                        throw new Exception("There is no more space in the inventory");
                    }
                }
            }
        }
        public class InventoryRecord
        {
            public ObtainableItem InventoryItem { get; private set; }
            public int Quantity { get; private set; }

            public InventoryRecord(ObtainableItem item, int quantity)
            {
                InventoryItem = item;
                Quantity = quantity;
            }

            public void AddToQuantity(int amountToAdd)
            {
                Quantity += amountToAdd;
            }
        }
    }
}
    

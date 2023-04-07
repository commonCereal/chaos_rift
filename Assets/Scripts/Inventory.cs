using System.Collections.Generic;
using Unity.VisualScripting;

namespace StarterAssets {
    public class Inventory {
        private List<Item> items;
        int maxSlots;

        public Inventory(int maxSlots, int maxSlotStack) {
            items = new List<Item>();
            
        }
        
        List<Item> getItems() {
            List<Item> itemsCpy = new List<Item>();
            itemsCpy.AddRange(items);
            return itemsCpy;
        }
        
        bool addItem(Item item) { 
            if (item.IsStackable) { 
                // see if there is a stack this can be added to
                bool added = false;
                int i = 0;
                while (!added && i < items.Count) {
                    Item addTo = items[i];
                    if (item.Name == addTo.Name) {
                        int addAmount = addTo.MaxStackSize - addTo.StackSize;
                        if (item.StackSize <= addAmount && addAmount > 0) {
                            addTo.StackSize += item.StackSize;
                            item.StackSize = 0;
                        } else {
                            item.StackSize -= addAmount;
                            addTo.StackSize += addAmount;
                        }
                    }
                    i++;
                }
            }
            
            if (item.StackSize > 0 && items.Count < maxSlots) {
                items.Add(item);
            }
            return true;
        }
        
        bool removeItem(Item item) {
            bool removed = false;
            int i = 0;
            while(!removed && i < items.Count) {
                Item removeItem = items[i];
                if (removeItem.Name == item.Name) {
                    removeItem.StackSize--;
                    if (removeItem.StackSize == 0) {
                        items.Remove(removeItem);
                    }
                    removed = true;
                }
                i++;
            }
            return removed;
        }
        
    }
}
using Unity.VisualScripting;

namespace StarterAssets {
    public abstract class Item {
        public string Name {get; set;}
        public bool IsStackable {get; set;}
        public int StackSize {get; set;}
        
        public int MaxStackSize {get; set;}
        
        public Item(string name, bool isStackable) {
            Name = name;
            IsStackable = isStackable;
            StackSize = 1;
        }
    }
}
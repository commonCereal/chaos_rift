namespace StarterAssets {
    public abstract class Weapon : Item {
        
        // How many shots can be made before needing to reload.
        // todo: FireWeapon anim trigger vs LastRoundFireWeapon anim trigger (this one used for transition from fire anim to reload anim).
        public int clipSize {get; set;}
        
        // This is how many rounds are currently left in the clip.
        public int clipCount {get; set;}
        
        // AmmoType required to use weapon
        // public AmmoType ammoType;
        
        public Weapon(string name, bool isStackable) : base(name, isStackable) { }
    }
}
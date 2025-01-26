using Unity.VisualScripting;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    
    public static Upgrade[] upgrades = new Upgrade[]
    {
        new Upgrade("SpeedUp", "Gotta go fast, Increase speed by 5.", Upgrade.UpgradeType.StatChange),
        new Upgrade("DamageUp","The Stronger, the Dirtier. Increase damage by 5",Upgrade.UpgradeType.StatChange),
        new Upgrade("AddBuddy","Bacteria never fights alone. Add a buddy to help you!", Upgrade.UpgradeType.WeaponChange),
        new Upgrade("BuddyDamageUp", "Strength in Numbers! Make your allies stronger.", Upgrade.UpgradeType.StatChange),
        
        new Upgrade("BeamEm", "Blast Through them", Upgrade.UpgradeType.WeaponChange),
        new Upgrade("RadialBlast", "Attack All Around", Upgrade.UpgradeType.WeaponChange),
    };


    public static void ApplyUpgrade(int UID)
    {
        switch (UID)
        {
            case 0: //SpeedUp
                PlayerManager.Instance.playerSpeed += 5;
                break;
            case 1: //DamageUp
                PlayerManager.Instance.damage += 5;
                break;
            case 2: //BeamEm
                PlayerManager.Instance.fireType = PlayerManager.FireType.Beam;
                break;
                
        }
    }

    public class Upgrade
    {
        public static int NextUID = 0;
        public string Name;
        public string Description;
        public UpgradeType Type;
        public int UID;

        public Upgrade(string Name, string Description, UpgradeType Type)
        {
            this.Name = Name;
            this.Description = Description;
            this.Type = Type;
            UID = NextUID++;
        }
        
        public enum UpgradeType { StatChange, WeaponChange }
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    
    public static PlayerManager player;

    void Start()
    {
        player = FindObjectOfType<PlayerManager>();
    }
    
    public static Upgrade[] upgrades = new Upgrade[]
    {
        new Upgrade("SpeedUp", "Gotta go fast, Increase speed by 1.", Upgrade.UpgradeType.StatChange),
        new Upgrade("DamageUp","The Stronger, the Dirtier. Increase damage by 1",Upgrade.UpgradeType.StatChange),
        
        new Upgrade("BeamEm", "Blast Through them", Upgrade.UpgradeType.WeaponChange),
        new Upgrade("RadialBlast", "Attack All Around", Upgrade.UpgradeType.WeaponChange),
    };

    public static void ApplyUpgrade(int UID)
    {
        switch (UID)
        {
            case 1: //SpeedUp
                player.playerSpeed++;
                break;
            case 2: //DamageUp
                PlayerManager.damage++;
                break;
            case 3: //BeamEm
                player.fireType = PlayerManager.FireType.Beam;
                break;
                
        }
    }

    public class Upgrade : MonoBehaviour
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

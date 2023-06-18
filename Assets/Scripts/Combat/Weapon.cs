using UnityEngine;

namespace RL.Combat
{
    
    [CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 0)]
    public class Weapon : ScriptableObject {
        public enum weaponTypes{
            longWeapon,
            shortWeapon,
            
        }
        [SerializeField] public GameObject weaponPrefab;
        public int baseDamage;
        public int weaponLevel;
        public weaponTypes waponType;
    }

}
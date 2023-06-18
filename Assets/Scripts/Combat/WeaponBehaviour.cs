using UnityEngine;

namespace RL.Combat{
  public class WeaponBehaviour : MonoBehaviour {
    [SerializeField] const int ROTATION_CONST = -100;
    private int weaponDamage;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.tag == "Enemy" ) {
                other.GetComponent<Health>().TakeDamage(weaponDamage);
            }
  
        }
          private void Update() {
            transform.Rotate(0, 0, ROTATION_CONST * Time.deltaTime, Space.Self);
            
            }
        public void SetWeaponDamage(int damage){
            weaponDamage = damage;
            
        }
    }
}
using UnityEngine;

namespace RL.Combat{
    
    public class Health : MonoBehaviour {
        [SerializeField] int health = 10;
        public void TakeDamage(int damage){
            health -=damage;
            gameObject.GetComponent<Rigidbody2D>().velocity *= -5f;
            if (health <= 0){
                Destroy(gameObject);
            }

        }
        
    }
}
using UnityEngine;
using RL.Combat;

namespace RL.Control {
    
    public class PlayerControl : MonoBehaviour {
        #region Components
        Animator animator;
        SpriteRenderer spriteRenderer;
        #endregion

        #region Config Params
        
        public Weapon[] weapons;
        [SerializeField] private float speed = 5f;
        #endregion
        private void Awake()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            SpawnWeapons();
        }



        private void Update() {
            Movement();
        }

        private void Movement() {

            float velocityHorizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            float velocityVertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
            if (velocityHorizontal < 0) {
                spriteRenderer.flipX = true;
            } else if (velocityHorizontal > 0) {
                spriteRenderer.flipX = false;

            }
            transform.Translate(velocityHorizontal, velocityVertical, 0);
            
            if (velocityHorizontal != 0 || velocityVertical != 0) {
                animator.SetBool("isRunnig", true);
            } else {
                animator.SetBool("isRunnig", false);
            }
        } 
        private void SpawnWeapons(){
            Transform rightHand = gameObject.transform.Find("LongSwordPlaceRight");
            Transform leftHand = gameObject.transform.Find("LongSwordPlaceLeft");
            GameObject rightHandSword = Instantiate(weapons[0].weaponPrefab, rightHand.position, Quaternion.identity);
            GameObject leftHandSword = Instantiate(weapons[1].weaponPrefab, leftHand.position, Quaternion.identity);
            rightHandSword.GetComponent<WeaponBehaviour>().SetWeaponDamage(weapons[0].baseDamage * weapons[0].weaponLevel);
            leftHandSword.GetComponent<WeaponBehaviour>().SetWeaponDamage(weapons[1].baseDamage * weapons[1].weaponLevel);
            rightHandSword.transform.parent = rightHand;
            leftHandSword.transform.parent = leftHand;
        }
    }
}
using System;
using UnityEngine;

namespace RL.Control {
    public class EnemyControl : MonoBehaviour {
       #region Components
       GameObject player; 
       Animator animator;
       SpriteRenderer spriteRenderer; 
       #endregion

       [SerializeField] private float attackRange = 5f;
       [SerializeField] private float speed = 5f;
       private void Awake() {
            player = GameObject.FindGameObjectWithTag("Player");
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
       }
       private void Update() {
        MoveToPlayer();
       }

        private void MoveToPlayer()
        {
            Vector3 targetVector = player.transform.position - transform.position;
            spriteRenderer.flipX = (targetVector.x < 0);
            float vectorLen = Vector3.Magnitude(targetVector);
            if (vectorLen <= attackRange ) {
                animator.SetBool("isFollowing", false);
            } else {
                animator.SetBool("isFollowing", true);
                Vector3 moveDir = new Vector3(targetVector.x / vectorLen , targetVector.y / vectorLen , 0);
                transform.Translate(moveDir * speed * Time.deltaTime);
            }

        }
    }

}
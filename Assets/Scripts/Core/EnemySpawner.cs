using System.Collections;
using UnityEngine;

namespace RL.Core {
    
    public class EnemySpawner : MonoBehaviour {
        [SerializeField] private GameObject bigZombiePrefab;
        [SerializeField] Transform[] spawnPoints;

        private float interval = 3.5f;
        private void Start() {
            StartCoroutine(spawnEnemy(interval, bigZombiePrefab, 5, Random.Range(0,5)));
        }

        public IEnumerator spawnEnemy(float interval, GameObject enemyPrefab, int enemyCount, int spawnPointIndex) {
            yield return new WaitForSeconds(interval);

            for(int i = 0; i < enemyCount; i++) {
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);

            }

        }
        
    }
}
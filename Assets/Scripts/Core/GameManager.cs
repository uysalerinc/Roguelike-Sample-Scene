using System.Collections;
using UnityEngine;

namespace RL.Core{
    public class GameManager : MonoBehaviour {
        [SerializeField] GameObject waveControllerPrefab;
        WaveController waveController;
        bool isNextWaveStarted = false;
        private void Start() {
           GameObject newWaveController = Instantiate(waveControllerPrefab, new Vector3(0,0,0), Quaternion.identity);
           waveController = newWaveController.GetComponent<WaveController>();
           waveController.StartWave();
        }
        private void Update() {
            if (waveController.isWaveEnded){
                GameObject[] aliveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in aliveEnemies)
                {
                    Destroy(enemy);   
                }
                if(waveController.currentWaveIndex == waveController.waves.Count -1){
                    return;
                }
                if (!isNextWaveStarted) StartCoroutine(StartNextWave());
            }
        }

        private IEnumerator StartNextWave(){
            isNextWaveStarted = true;
            yield return new WaitForSeconds(5f);
            waveController.isWaveEnded = false;
            waveController.currentWaveIndex ++;
            waveController.StartWave();
            Time.timeScale = 1;
            isNextWaveStarted = false;
        }
    }
}
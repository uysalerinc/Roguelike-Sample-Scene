using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace RL.Core {
    public class WaveController : MonoBehaviour
    {
        #region Components
        [SerializeField] public List<WaveSO> waves;
        [SerializeField] private GameObject waveNumberInGameObject;
        [SerializeField] private GameObject waveTimerInGameObject;
        [SerializeField] Transform[] spawnPoints;
        private TextMeshProUGUI waveNumberText;
        private TextMeshProUGUI waveTimerText;
        private WaveSO currentWave;
        #endregion
        #region Params
        private int waveDuration;
        [HideInInspector] public int currentWaveIndex = 0;
        [HideInInspector] public bool isWaveEnded = false;
        #endregion

        private void Awake() {
            waveNumberText = waveNumberInGameObject.GetComponent<TextMeshProUGUI>();
            waveTimerText = waveTimerInGameObject.GetComponent<TextMeshProUGUI>();
        }

        public void StartWave()
        {
            currentWave = waves[currentWaveIndex];
            waveDuration = currentWave.waveDuration;
            StartCoroutine(Timer());
            StartCoroutine(SpawnEnemy(currentWave.enemyPrefabs, 5));
            waveNumberText.text = "Wave: " + (currentWaveIndex + 1);
        }

        private void Update() {
        }

        public IEnumerator Timer(){
            while(waveDuration >= 0) {
                waveTimerText.text = waveDuration.ToString();
                if (waveDuration <= 10){
                    waveTimerText.color = Color.red;
                } 
                if (waveDuration <= 0){
                    isWaveEnded = true;
                }
                yield return new WaitForSeconds(1f);
                waveDuration--;
            }

        }
        public IEnumerator SpawnEnemy(List<GameObject> enemyPrefabs, int enemyCount) {
            yield return new WaitForSeconds(0.5f);
            while(!isWaveEnded){
                int spawnPointIndex = Random.Range(0,spawnPoints.Length);
                for(int i = 0; i < enemyCount; i++) {
                    if (isWaveEnded) yield break;
                    GameObject newEnemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawnPoints[spawnPointIndex].position, Quaternion.identity);
                    print(i);
                    yield return new WaitForSeconds(0.3f);
                    
                }
                yield return new WaitForSeconds(currentWave.interval);
            }
       } 
    }
}


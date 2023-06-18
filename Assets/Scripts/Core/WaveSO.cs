using System.Collections.Generic;
using UnityEngine;

namespace RL.Core{
    
    [CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/Wave", order = 0)]
    public class WaveSO : ScriptableObject {
        public List<GameObject> enemyPrefabs;
        public int waveDuration;
        GameObject bossPrefab;
        public bool hasBoss;
        public float interval;
        
    }
}
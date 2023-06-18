using Cinemachine;
using UnityEngine;

namespace RL.Core {

    public class CameraController : MonoBehaviour {
        Transform player;
        CinemachineVirtualCamera virtualCamera;
        private void Awake() {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            player = GameObject.FindWithTag("Player").transform;
            virtualCamera.Follow = player;
            
        }
        
    }
}
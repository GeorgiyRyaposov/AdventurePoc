using Cinemachine;
using UnityEngine;
using Zenject;

namespace Game.Characters.Player
{
    public class PlayerFollowCameraController : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<PlayerFollowCameraController>
        {
            
        }

        [SerializeField] 
        private CinemachineVirtualCamera virtualCamera;

        public void SetFollowTarget(GameObject cinemachineCameraTarget)
        {
            virtualCamera.Follow = cinemachineCameraTarget.transform;
        }
    }
}
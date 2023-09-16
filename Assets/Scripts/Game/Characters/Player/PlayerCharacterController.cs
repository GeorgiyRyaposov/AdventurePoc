using Common.ServiceLocator;
using StarterAssets;
using UnityEngine;

namespace Game.Characters.Player
{
    [CreateAssetMenu(fileName = "PlayerCharacterController", menuName = "Services/PlayerCharacterController")]
    public class PlayerCharacterController : ScriptableObject, IService
    {
        [SerializeField] ThirdPersonController thirdPersonControllerPrefab;
        [SerializeField] PlayerFollowCameraController playerFollowCameraControllerPrefab;

        public void SpawnPlayer(Vector3 spawnPoint)
        {
            var thirdPersonController = Instantiate(thirdPersonControllerPrefab, spawnPoint, Quaternion.identity);
            var playerFollowCameraController = Instantiate(playerFollowCameraControllerPrefab);

            playerFollowCameraController.SetFollowTarget(thirdPersonController.CinemachineCameraTarget);
        }
    }
}
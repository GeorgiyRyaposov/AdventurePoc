using StarterAssets;
using UnityEngine;

namespace Game.Characters.Player
{
    public class PlayerCharacterController
    {
        private readonly ThirdPersonController.Factory thirdPersonControllerFactory;
        private readonly PlayerFollowCameraController.Factory playerFollowCameraControllerFactory;


        public PlayerCharacterController(ThirdPersonController.Factory thirdPersonControllerFactory,
            PlayerFollowCameraController.Factory playerFollowCameraControllerFactory)
        {
            this.thirdPersonControllerFactory = thirdPersonControllerFactory;
            this.playerFollowCameraControllerFactory = playerFollowCameraControllerFactory;
        }
        
        public void SpawnPlayer(Vector3 spawnPoint)
        {
            var thirdPersonController = thirdPersonControllerFactory.Create();
            thirdPersonController.transform.position = spawnPoint;
            var playerFollowCameraController = playerFollowCameraControllerFactory.Create();

            playerFollowCameraController.SetFollowTarget(thirdPersonController.CinemachineCameraTarget);
        }
    }
}
using StarterAssets;

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
        
        public void SpawnPlayer()
        {
            var thirdPersonController = thirdPersonControllerFactory.Create();
            var playerFollowCameraController = playerFollowCameraControllerFactory.Create();

            playerFollowCameraController.SetFollowTarget(thirdPersonController.CinemachineCameraTarget);
        }
    }
}
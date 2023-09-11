using StarterAssets;
using UnityEngine;
using Zenject;

namespace Game.Characters.Player
{
    public class PlayerCharacterInstaller : MonoInstaller
    {
        [SerializeField] private PlayerFollowCameraController playerFollowCameraController;
        [SerializeField] private ThirdPersonController thirdPersonController;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerCharacterController>().AsSingle();
            
            Container.BindFactory<PlayerFollowCameraController, PlayerFollowCameraController.Factory>()
                .FromComponentInNewPrefab(playerFollowCameraController)
                .AsSingle();
            
            Container.BindFactory<ThirdPersonController, ThirdPersonController.Factory>()
                .FromComponentInNewPrefab(thirdPersonController)
                .AsSingle();
        }
    }
}
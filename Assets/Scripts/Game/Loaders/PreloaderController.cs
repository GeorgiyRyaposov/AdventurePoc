using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Game.Loaders
{
    public class PreloaderController
    {
        private readonly TechnicalData technicalData;
        
        public PreloaderController(TechnicalData technicalData)
        {
            this.technicalData = technicalData;
        }
        
        public async Task Show()
        {
            var op = SceneManager.LoadSceneAsync(technicalData.PreloaderSceneName, LoadSceneMode.Additive);
            op.allowSceneActivation = true;
            while (!op.isDone)
            {
                await Task.Yield();
            }
        }
        
        public async Task Hide()
        {
            var op = SceneManager.UnloadSceneAsync(technicalData.PreloaderSceneName);
            while (!op.isDone)
            {
                await Task.Yield();
            }
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gui.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        private Button newGameButton;
        
        [SerializeField]
        private Button loadGameButton;
        
        [SerializeField]
        private Button exitButton;

        public Button NewGame => newGameButton;
        public Button LoadGame => loadGameButton;
        public Button Exit => exitButton;
    }
}
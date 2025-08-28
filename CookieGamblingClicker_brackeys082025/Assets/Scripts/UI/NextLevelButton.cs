using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CookieGambler.UI
{
    public class NextLevelButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private Image _background;
        private GameController _gameController;

        private void Awake()
        {
            _gameController = FindFirstObjectByType<GameController>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!CanBeClicked())
                return;

            LevelManager.IncrementLevel();
            SceneManager.LoadScene("__Test_Ju");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!CanBeClicked())
                return;

            _background.color = Color.yellow;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!CanBeClicked())
                return;

            _background.color = Color.white;
        }

        public bool CanBeClicked()
        {
            return _gameController.CurrentState == Utils.ActionState.Victory;
        }
    }
}

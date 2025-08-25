using TMPro;
using UnityEngine;

namespace CookieGambler
{
    public class RemainingActionDisplayer : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI remainingActionText;
        [SerializeField]
        private int remainingActionCount = 5;

        public int RemainingActionCount
        {
            get => remainingActionCount;
            set
            {
                remainingActionCount = Mathf.Min(value, 0);

                if (remainingActionCount <= 0)
                {
                    GameManager.Instance.Monster.Attack();
                }

                UpdateRemainingAction();
            }
        }

        private void Start()
        {
            UpdateRemainingAction();
        }

        private void UpdateRemainingAction()
        {
            remainingActionText.text = "Ramaining Action: " + remainingActionCount;
        }
    }
}
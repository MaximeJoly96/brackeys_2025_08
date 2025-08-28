using UnityEngine;
using TMPro;

namespace CookieGambler.UI
{
    public class CookieGain : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _gainText;

        public void UpdateText(int value)
        {
            string symbol = value >= 0 ? "+" : "-";
            _gainText.text = symbol + value.ToString();
        }

        public void Show()
        {
            GetComponent<Animator>().Play("Show");
        }
    }
}

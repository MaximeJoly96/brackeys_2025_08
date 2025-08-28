using UnityEngine;
using UnityEngine.UI;

namespace CookieGambler
{
    public class HungerMeterBar : MonoBehaviour
    {
        [SerializeField]
        private Slider cookiesGauge;
        [SerializeField]
        private float min = 0f;
        [SerializeField]
        private float max = 100f;
        [SerializeField]
        private float value = 0f;

        public float Min
        {
            get => min;
            set
            {
                min = value;
                UpdateGauge();
            }
        }
        public float Max
        {
            get => max;
            set
            {
                max = value;
                UpdateGauge();
            }
        }
        public float Value
        {
            get => value;
            set
            {
                if (GameManager.Instance.IsGameOver)
                    return;

                if (value >= max)
                {
                    GameManager.Instance.Monster.TummyFull();
                }
                else
                {
                    GameManager.Instance.Monster.Eat();
                }
                this.value += value;
                this.value = Mathf.Clamp(value, min, max);

                UpdateGauge();
            }
        }

        private void Start()
        {
            Init();
            UpdateGauge();
        }

        private void UpdateGauge()
        {
            cookiesGauge.minValue = min;
            cookiesGauge.maxValue = max;
            cookiesGauge.value = value;
        }

        private void Init()
        {
            switch(LevelManager.CurrentLevel)
            {
                case 0:
                    max = 20;
                    break;
                case 1:
                    max = 35;
                    break;
                case 2:
                    max = 50;
                    break;
                case 3:
                    max = 80;
                    break;
                case 4:
                    max = 150;
                    break;
            }
        }
    }
}
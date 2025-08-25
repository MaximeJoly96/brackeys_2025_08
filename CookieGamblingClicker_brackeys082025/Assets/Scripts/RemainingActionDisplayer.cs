using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CookieGambler
{
    public class RemainingActionDisplayer : MonoBehaviour
    {
        [SerializeField]
        private Vector3 CandleSizeFactor = new Vector3(0f, 0.8f, 0f);

        [SerializeField]
        private GameObject candleBody;
        [SerializeField]
        private TMP_Text remainingActionText;
        [SerializeField]
        private int remainingActionMax = 5;
        [SerializeField]
        private Light[] allLights;
        private int remainingActionCount;

        public int RemainingActionCount
        {
            get => remainingActionCount;
            set
            {
                remainingActionCount = Mathf.Clamp(value, 0, remainingActionMax);

                if (remainingActionCount <= 0)
                {
                    GameManager.Instance.Monster.Attack();
                }

                UpdateRemainingAction();
            }
        }

        public int RemainingActionMax
        {
            get => remainingActionMax;
            set
            {
                remainingActionMax = value;
                remainingActionCount = remainingActionMax;
            }
        }

        private void Start()
        {
            RemainingActionMax = remainingActionMax;
            UpdateRemainingAction();
        }

        private void UpdateRemainingAction()
        {
            remainingActionText.text = RemainingActionCount.ToString();
            StartCoroutine(ConsumeCandle());
        }

        private IEnumerator ConsumeCandle()
        {
            Vector3 initScale = candleBody.transform.localScale;
            Vector3 finalScale = Vector3.one + (CandleSizeFactor * (1f - RemainingActionCount / (float)RemainingActionMax));

            float time = 0;
            while(Vector3.Distance(candleBody.transform.localScale, finalScale) > Mathf.Epsilon)
            {
                time += Time.deltaTime;
                candleBody.transform.localScale = Vector3.Lerp(initScale, finalScale, time);
                foreach (var light in allLights)
                {
                    light.intensity *= 0.999f;
                }
                yield return null;
            }
        }
    }
}
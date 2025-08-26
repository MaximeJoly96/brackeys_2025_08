using UnityEngine;
using System.Collections.Generic;
using CookieGambler.Effects;

namespace CookieGambler
{
    public class Card : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _front;
        [SerializeField]
        private SpriteRenderer _back;
        [SerializeField]
        private List<CardEffect> _effects;

        public List<CardEffect> Effects
        {
            get
            {
                return _effects;
            }
        }

        private void Awake()
        {
            ShowBack();
        }

        public void ShowFront()
        {
            _front.sortingOrder = 1;
            _back.sortingOrder = 0;
        }

        public void ShowBack()
        {
            _front.sortingOrder = 0;
            _back.sortingOrder = 1;
        }
    }
}


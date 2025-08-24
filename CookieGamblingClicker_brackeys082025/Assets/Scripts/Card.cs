using UnityEngine;
using System.Collections.Generic;

namespace CookieGambler
{
    public class Card : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _front;
        [SerializeField]
        private SpriteRenderer _back;

        private List<CardEffect> _effects;

        public float CardWidth
        {
            get
            {
                return _front.sprite.bounds.extents.x * 2.0f * transform.lossyScale.x;
            }
        }

        private void Awake()
        {
            ShowBack();
        }

        public void PlayCard()
        {
            if (_effects == null)
                return;

            for(int i = 0; i < _effects.Count; i++)
            {
                _effects[i].Apply();
            }
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


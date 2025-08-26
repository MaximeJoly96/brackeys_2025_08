using CookieGambler.Effects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System.Text;

namespace CookieGambler.UI
{
    public class CardInHand : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        [SerializeField]
        private Outline _outline;
        [SerializeField]
        private TMP_Text _cardText;

        private List<CardEffect> _effects;
        private UnityEvent<CardInHand> _cardWasClicked;
        private UnityEvent<CardInHand> _cardWasPlayed;

        public UnityEvent<CardInHand> CardWasClicked
        {
            get
            {
                if (_cardWasClicked == null)
                    _cardWasClicked = new UnityEvent<CardInHand>();

                return _cardWasClicked;
            }
        }

        public UnityEvent<CardInHand> CardWasPlayed
        {
            get
            {
                if(_cardWasPlayed == null)
                    _cardWasPlayed = new UnityEvent<CardInHand>();

                return _cardWasPlayed;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            CardWasClicked.Invoke(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _outline.enabled = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _outline.enabled = false;
        }

        public void PlayCard()
        {
            if (_effects == null)
                return;

            for (int i = 0; i < _effects.Count; i++)
            {
                _effects[i].Apply();
            }

            CardWasPlayed.Invoke(this);
        }

        public void Select()
        {
            GetComponent<Image>().color = Color.yellow;
        }

        public void Unselect()
        {
            GetComponent<Image>().color = Color.white;
        }

        public void SetEffects(List<CardEffect> effects)
        {
            _effects = effects;

            UpdateCardText();
        }

        public void UpdateCardText()
        {
            if (_effects == null)
                return;

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < _effects.Count; i++)
            {
                sb.AppendLine(_effects[i].ToString());
            }

            _cardText.text = sb.ToString();
        }
    }
}

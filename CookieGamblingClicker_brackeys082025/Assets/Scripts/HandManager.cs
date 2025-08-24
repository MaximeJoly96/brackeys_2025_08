using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace CookieGambler
{
    public class HandManager : MonoBehaviour
    {
        [SerializeField]
        private Deck _deck;

        private List<Card> _cardsInHand;

        private void Awake()
        {
            BindEvents();
        }

        public void BindEvents()
        {
            _deck.CardWasDrawn.AddListener(AddCardToHand);
        }

        public void AddCardToHand(Card card)
        {
            if(_cardsInHand == null)
                _cardsInHand = new List<Card>();

            _cardsInHand.Add(card);

            card.transform.SetParent(transform);
            card.ShowFront();

            Render();
        }

        public void Render()
        {
            if (_cardsInHand == null || _cardsInHand.Count == 0)
                return;

            float cardWidth = _cardsInHand[0].CardWidth;
            float totalWidth = cardWidth * _cardsInHand.Count;
            Vector3 startPos = new Vector3(0.0f - totalWidth / 2.0f, transform.position.y, 0.0f);

            for (int i = 0; i < _cardsInHand.Count; i++)
            {
                _cardsInHand[i].transform.position = new Vector3(cardWidth / 2.0f + startPos.x + cardWidth * i,
                                                                 startPos.y, 
                                                                 startPos.z);
            }
        }
    }
}

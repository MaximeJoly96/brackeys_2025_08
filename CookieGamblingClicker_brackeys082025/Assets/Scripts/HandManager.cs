using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using CookieGambler.UI;

namespace CookieGambler
{
    public class HandManager : MonoBehaviour
    {
        [SerializeField]
        private Deck _deck;
        [SerializeField]
        private CardInHand _cardInHandPrefab;
        [SerializeField]
        private Transform _wrapper;
        [SerializeField]
        private int _handSize;

        private List<CardInHand> _cardsInHand;
        private CardInHand _selectedCard;

        public CardInHand SelectedCard { get { return _selectedCard; } }
        public bool IsHandFull
        {
            get
            {
                if (_cardsInHand == null)
                    return false;

                return _cardsInHand.Count >= _handSize;
            }
        }

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
                _cardsInHand = new List<CardInHand>();

            CardInHand instCard = Instantiate(_cardInHandPrefab, _wrapper);
            _cardsInHand.Add(instCard);

            instCard.SetEffects(card.Effects);
            instCard.CardWasClicked.AddListener(SelectCard);
            instCard.CardWasPlayed.AddListener(PlayCard);

            Destroy(card.gameObject);
        }

        public void SelectCard(CardInHand card)
        {
            if(_selectedCard == card)
            {
                _selectedCard.Unselect();
                _selectedCard = null;
                return;
            }

            if (_selectedCard)
                _selectedCard.Unselect();

            _selectedCard = card;
            _selectedCard.Select();
        }

        public void PlayCard(CardInHand card)
        {
            if(card)
            {
                _cardsInHand.Remove(card);

                Destroy(card.gameObject);
                _selectedCard = null;
            }
        }
    }
}

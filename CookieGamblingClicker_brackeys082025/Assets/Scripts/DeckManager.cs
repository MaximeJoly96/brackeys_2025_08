using UnityEngine;
using System.Collections.Generic;

namespace CookieGambler
{
    public class DeckManager : MonoBehaviour
    {
        [SerializeField]
        private Deck _deck;

        // Subject to change when we need to load the actual cards of the player
        [SerializeField]
        private List<Card> _cards;

        private void Awake()
        {
            InitDeck(_cards);
        }

        public void InitDeck(List<Card> cards)
        {
            _deck.Init();
            _deck.Shuffle();

            for (int i = 0; i < cards.Count; i++)
            {
                _deck.AddCard(cards[i]);
            }

            _deck.Render();
        }
    }
}

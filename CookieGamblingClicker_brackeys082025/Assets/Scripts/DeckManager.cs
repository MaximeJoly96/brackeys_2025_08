using UnityEngine;
using System.Collections.Generic;
using System;

namespace CookieGambler
{
    [Serializable]
    public class DeckData
    {
        [SerializeField]
        private int _level;
        [SerializeField]
        private List<Card> _cards;

        public int Level { get { return _level; } }
        public List<Card> Cards { get { return _cards; } }
    }

    public class DeckManager : MonoBehaviour
    {
        [SerializeField]
        private Deck _deck;

        [SerializeField]
        private DeckData[] _decks;

        private void Awake()
        {
            InitDeck(_decks[LevelManager.CurrentLevel].Cards);
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

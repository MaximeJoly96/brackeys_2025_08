using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace CookieGambler
{
    public class Deck : MonoBehaviour
    {
        [SerializeField]
        private Transform _hoverAura;
        [SerializeField]
        private AudioClip _cardDrawSound;
        [SerializeField]
        private AudioClip _deckEmptySound;

        private Stack<Card> _cards;
        private System.Random _rng;
        private UnityEvent<Card> _cardWasDrawn;

        public UnityEvent<Card> CardWasDrawn
        {
            get
            {
                if (_cardWasDrawn == null)
                    _cardWasDrawn = new UnityEvent<Card>();

                return _cardWasDrawn;
            }
        }

        public AudioSource Source
        {
            get { return GetComponent<AudioSource>(); }
        }

        public void Init()
        {
            _cards = new Stack<Card>();
            _rng = new System.Random();
        }

        public void AddCard(Card card)
        {
            Card instCard = Instantiate(card, transform);

            _cards.Push(instCard);
        }

        public Card Draw()
        {
            return _cards.Count == 0 ? null : _cards.Pop();
        }

        public void Shuffle()
        {
            if (_cards == null)
                return;

            List<Card> shuffled = _cards.ToList();

            int n = shuffled.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                Card value = shuffled[k];
                shuffled[k] = shuffled[n];
                shuffled[n] = value;
            }

            Init();

            for(int i = 0; i < shuffled.Count; i++)
                AddCard(shuffled[i]);
        }

        private void Update()
        {
            if (IsMouseWithinBounds())
            {
                if(!_hoverAura.gameObject.activeSelf)
                    _hoverAura.gameObject.SetActive(true);
            }
            else
            {
                _hoverAura.gameObject.SetActive(false);
            }

            HandleClicks();
        }

        public void HandleClicks()
        {
            if (Input.GetMouseButtonDown(0) && IsMouseWithinBounds())
            {
                Card drawnCard = Draw();

                if (drawnCard)
                {
                    Source.clip = _cardDrawSound;
                    CardWasDrawn.Invoke(drawnCard);
                }
                else
                {
                    Source.clip = _deckEmptySound;
                }

                Source.Play();
            }
        }

        public bool IsMouseWithinBounds()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            return Physics.Raycast(ray);
        }

        public void Render()
        {
            List<Card> cardsList = _cards.ToList();

            for(int i = 0; i < cardsList.Count; i++)
            {
                cardsList[i].transform.localPosition = new Vector3(0.05f * i, 0.05f * i);
            }
        }
    }
}

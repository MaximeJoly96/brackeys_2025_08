using System;
using UnityEngine;

namespace CookieGambler
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private Transform _loseScreen;
        [SerializeField]
        private Transform _winScreen;

        public static GameManager Instance { get; private set; }

        public MonsterAnimation Monster;
        public HungerMeterBar HungerBar;
        public RemainingActionDisplayer ActionDisplayer;
        private GameController _gameController;

        public EventHandler<bool> GameOverEvent;

        public bool IsGameOver { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(Instance);
                Instance = this;
            }

            _gameController = FindFirstObjectByType<GameController>();
        }

        private void Start()
        {
            GameOverEvent = new EventHandler<bool>((obj, arg) => CheckEndOfLevel(arg));
        }

        public void CheckEndOfLevel(bool isGameOver)
        {
            IsGameOver = isGameOver;

            if(_gameController.CurrentState == Utils.ActionState.MonsterTurn)
            {
                _loseScreen.GetComponent<Animator>().Play("Show");
            }
            else
            {
                _gameController.CurrentState = Utils.ActionState.Victory;
                _winScreen.GetComponent<Animator>().Play("Show");
            }
        }
    }
}
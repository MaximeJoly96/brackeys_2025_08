using System;
using System.Collections;
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
        }

        private IEnumerator PlayLose()
        {
            GameManager.Instance.Monster.Attack();
            yield return new WaitUntil(() => !GameManager.Instance.Monster.AnimationInProgress);

            _loseScreen.GetComponent<Animator>().Play("Show");
        }
        private IEnumerator PlayVictory()
        {
            GameManager.Instance.Monster.TummyFull();
            yield return new WaitUntil(() => !GameManager.Instance.Monster.AnimationInProgress);
            _gameController.CurrentState = Utils.ActionState.Victory;
            _winScreen.GetComponent<Animator>().Play("Show");
        }

        public void CheckEndOfLevel(bool isGameOver)
        {
            IsGameOver = isGameOver;

            StartCoroutine(_gameController.CurrentState == Utils.ActionState.MonsterTurn ? PlayLose() : PlayVictory());
        }
    }
}
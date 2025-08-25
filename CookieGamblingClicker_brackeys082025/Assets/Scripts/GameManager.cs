using System;
using UnityEngine;

namespace CookieGambler
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public MonsterAnimation Monster;
        public HungerMeterBar HungerBar;
        public RemainingActionDisplayer ActionDisplayer;

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
        }

        private void Start()
        {
            GameOverEvent = new EventHandler<bool>((obj, arg) => IsGameOver = true);
        }
    }
}
using CookieGambler.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CookieGambler
{
    public class CookiesStock : BaseAction
    {
        [SerializeField]
        private GameObject _cookieGO;
        [SerializeField]
        private Transform _fallPoint;
        [SerializeField] 
        private HungerMeterBar _hungerMeter;

        [SerializeField]
        private TextMeshPro _textMeshPro;

        private List<GameObject> _cookies;

        public int CookiesCount { get; private set; }

        public override ActionState ActionType => ActionState.GiveCookies;

        public override void DoInit(Action onActionDone)
        {   
            base.DoInit(onActionDone);
            _cookies = new List<GameObject>();
        }

        public void AddCookie()
        {
            UpdateCurrentCookiesCount(1);
        }

        public void UpdateCurrentCookiesCount(int cookiesCount)
        {
            CookiesCount += cookiesCount;
            if(CookiesCount%20 == 0)
            {
                foreach (GameObject cookie in _cookies)
                    Destroy(cookie);
                _cookies = new List<GameObject>();
            }
                
            _cookies.Add(GameObject.Instantiate(_cookieGO, _fallPoint));
            _textMeshPro.text = CookiesCount.ToString();
        }

        public override void OnClickAction()
        {
            GiveCoookies();
        }

        private void GiveCoookies()
        {
            _hungerMeter.Value = CookiesCount;
            CookiesCount = 0;
            foreach (GameObject cookie in _cookies) 
            { 
                Destroy(cookie);
            }
            _textMeshPro.text = CookiesCount.ToString();
            ActionDone();
        }
    }
}


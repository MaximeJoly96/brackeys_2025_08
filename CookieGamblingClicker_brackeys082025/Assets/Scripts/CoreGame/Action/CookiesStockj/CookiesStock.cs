using CookieGambler.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookieGambler
{
    public class CookiesStock : BaseAction
    {
        [SerializeField]
        private GameObject _cookieGO;
        [SerializeField]
        private Transform _fallPoint;

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
            _cookies.Add(GameObject.Instantiate(_cookieGO, _fallPoint));
        }

        public override void OnClickAction()
        {
            GiveCoookies();
        }

        private void GiveCoookies()
        {
            CookiesCount = 0;
            foreach (GameObject cookie in _cookies) 
            { 
                Destroy(cookie);
            }
            ActionDone();
        }
    }
}


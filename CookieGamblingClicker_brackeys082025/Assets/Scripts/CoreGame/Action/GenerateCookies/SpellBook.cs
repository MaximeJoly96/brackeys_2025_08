using CookieGambler.Utils;
using System;
using System.Collections;
using UnityEngine;
namespace CookieGambler
{
    /// <summary>
    /// Action to generate some cookies
    /// </summary>
    public class SpellBook : BaseAction
    {
        [SerializeField]
        private CookiesStock _cookiesStock;

        private Spell _spell;
        public override ActionState ActionType => ActionState.SpellBook;
        public override void DoInit(Action onActionDone)
        {
            base.DoInit(onActionDone);
            _spell = new Spell();
        }

        public override void OnClickAction()
        {
            SummonCookies();
        }

        private void SummonCookies()
        {
            StartCoroutine(SpawnCookies(_spell.CastCookieSpell()));
        }

        private IEnumerator SpawnCookies(int amountOfCookies)
        {
            for(int i = 0; i < amountOfCookies; i++)
            {
                _cookiesStock.AddCookie();
                yield return new WaitForSeconds(0.5f);
            }

            ActionDone();
        }

        public void UpdateSpell()
        {

        }
    }
}


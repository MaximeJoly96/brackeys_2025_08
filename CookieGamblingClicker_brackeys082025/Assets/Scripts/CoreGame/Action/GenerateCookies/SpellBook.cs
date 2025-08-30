using CookieGambler.Effects;
using CookieGambler.UI;
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
        [SerializeField]
        private CookieGain _gain;

        private Animator _animation;

        private Spell _spell;
        public override ActionState ActionType => ActionState.SpellBook;
        public override void DoInit(Action onActionDone)
        {
            base.DoInit(onActionDone);
            _spell = new Spell();
            _animation = GetComponent<Animator>();
        }

        public override void OnClickAction()
        {
            HandManager hand = FindFirstObjectByType<HandManager>();
            if (hand && hand.SelectedCard)
                hand.SelectedCard.PlayCard();
            else
                _animation.Play("Armature_ArmatureAction", 0, 0.0f);
        }

        public void SummonCookies()
        {
            SummonCookies(_spell.CastCookieSpell());
        }

        public void SummonCookies(int amount)
        {
            _gain.UpdateText(amount);
            _gain.Show();

            StartCoroutine(SpawnCookies(amount));
        }

        private IEnumerator SpawnCookies(int amountOfCookies)
        {
            for(int i = 0; i < amountOfCookies; i++)
            {
                _cookiesStock.AddCookie();
                yield return new WaitForSeconds(0.25f);
            } 
            // Warning, the ActionDone is called when the animation ends
        }

        public void UpdateSpell(CardEffect effect)
        {
            if(effect is IncreaseRange)
            {
                IncreaseRange increase = effect as IncreaseRange;
                _spell = new Spell();
                _spell.IncreaseMinBounds(increase.Amount);
                _spell.IncreaseMaxBounds(increase.Amount);
            }
            else if(effect is ReduceRangeGap)
            {
                ReduceRangeGap reduce = effect as ReduceRangeGap;
                _spell = new Spell();
                _spell.IncreaseMinBounds(reduce.Change);
                _spell.IncreaseMaxBounds(-reduce.Change);
            }

            ActionDone();
        }
    }
}


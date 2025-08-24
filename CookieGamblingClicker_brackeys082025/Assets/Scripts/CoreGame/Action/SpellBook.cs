using UnityEngine;
namespace CookieGambler
{
    /// <summary>
    /// Action to generate some cookies
    /// </summary>
    public class SpellBook : BaseAction
    {
        private Spell _spell;
        private void Awake()
        {
            _spell = new Spell();
        }

        public override void OnClickAction()
        {
            SummonCookies();
        }

        private void SummonCookies()
        {
            CookiesStock.Instance.UpdateCurrentCookiesCount(_spell.CastCookieSpell());
        }

        public void UpdateSpell()
        {

        }
    }
}


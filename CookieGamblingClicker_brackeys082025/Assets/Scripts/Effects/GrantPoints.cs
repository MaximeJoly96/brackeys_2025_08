using UnityEngine;

namespace CookieGambler.Effects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GrantPointsEffect", order = 1)]
    public class GrantPoints : CardEffect
    {
        [SerializeField]
        private int _amount;

        public override void Apply()
        {
            FindFirstObjectByType<SpellBook>().SummonCookies(_amount);
        }

        public override string ToString()
        {
            return "+" + _amount + " Cookies";
        }
    }
}

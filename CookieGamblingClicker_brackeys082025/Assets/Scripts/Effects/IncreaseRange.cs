using UnityEngine;

namespace CookieGambler.Effects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/IncreaseRangeEffect", order = 1)]
    public class IncreaseRange : CardEffect
    {
        [SerializeField]
        private int _amount;

        public int Amount { get { return _amount; } }

        public override void Apply()
        {
            FindFirstObjectByType<SpellBook>().UpdateSpell(this);
        }

        public override string ToString()
        {
            return "+" + _amount + " Cookies per click";
        }
    }
}

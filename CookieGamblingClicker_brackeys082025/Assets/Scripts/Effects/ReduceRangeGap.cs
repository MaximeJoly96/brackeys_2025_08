using UnityEngine;

namespace CookieGambler.Effects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ReduceRangeGapEffect", order = 1)]
    public class ReduceRangeGap : CardEffect
    {
        [SerializeField]
        private int _change;

        public int Change { get { return _change; } }

        public override void Apply()
        {
            FindFirstObjectByType<SpellBook>().UpdateSpell(this);
        }

        public override string ToString()
        {
            return "Reduce random range by " + _change;
        }
    }
}

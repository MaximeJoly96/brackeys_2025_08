using CookieGambler.Utils;
using System;
using UnityEngine;
namespace CookieGambler
{
    /// <summary>
    /// All the player’s actions must inherit from this class
    /// </summary>
    public abstract class BaseAction : MonoBehaviour
    {
        protected event Action OnActionDone;

        private Collider _collider;
        public Collider Collider => _collider ??= GetComponent<Collider>();
        public abstract ActionState ActionType { get; }
       
        /// <summary>
        /// This is the method that the subclasses must overload.
        /// </summary>
        public abstract void OnClickAction();
        public virtual void DoInit(Action onActionDone)
        {
            OnActionDone += onActionDone;
        }

        protected void ActionDone()
        {
            OnActionDone?.Invoke();
        }
    }
}


using CookieGambler.Utils;
using UnityEngine;

namespace CookieGambler
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private RemainingActionDisplayer _remainingActionDisplayer;

        [SerializeField]
        private SpellBook _spellBook;
        [SerializeField]
        private CookiesStock _cookiesStock;

        public ActionState CurrentState { get; set; }

        private void Awake()
        {
            CurrentState = ActionState.None;
            InitActions();
        }

        private void InitActions()
        {
            _spellBook.DoInit(ResetCurrentState);
            _cookiesStock.DoInit(ResetCurrentState);
        }

        public void ResetCurrentState()
        {
            _remainingActionDisplayer.RemainingActionCount--;
            CurrentState = _remainingActionDisplayer.RemainingActionCount == 0 ? ActionState.MonsterTurn : ActionState.None;
        }

        private void Update() 
        {
            if (CurrentState == ActionState.None && 
                Input.GetMouseButtonDown(0)) 
            {
                IsMouseWithinBounds();
            }
        }

        private void IsMouseWithinBounds()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                BaseAction action = hit.collider.gameObject.GetComponent<BaseAction>();
                if(action != null)
                {
                    CurrentState = action.ActionType;
                    action.OnClickAction();
                }
            }
        }
    }
}


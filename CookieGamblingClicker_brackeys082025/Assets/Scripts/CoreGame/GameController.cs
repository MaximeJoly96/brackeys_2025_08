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

        [SerializeField]
        private HungerMeterBar _hungerMeterBar;

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
            if (_hungerMeterBar.FullyBelly) 
            {
                CurrentState = ActionState.Victory;
                GameManager.Instance.CheckEndOfLevel(true);
                return;
            }

            if(_remainingActionDisplayer.RemainingActionCount <= 0)
            {
                CurrentState = ActionState.MonsterTurn;
                GameManager.Instance.CheckEndOfLevel(false);
                return;
            }
            CurrentState = _remainingActionDisplayer.RemainingActionCount == 0 ? ActionState.MonsterTurn : ActionState.None;
        }

        private void Update() 
        {
            if (CurrentState == ActionState.None && 
                !_remainingActionDisplayer.AnimationInProgess &&
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
                    _remainingActionDisplayer.RemainingActionCount--;
                    CurrentState = action.ActionType;
                    action.OnClickAction();
                }
            }
        }
    }
}


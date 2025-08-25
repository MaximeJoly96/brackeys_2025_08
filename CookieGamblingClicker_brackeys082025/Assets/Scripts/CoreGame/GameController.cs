using CookieGambler.Utils;
using UnityEngine;

namespace CookieGambler
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private SpellBook _spellBook;
        [SerializeField]
        private CookiesStock _cookiesStock;

        private int _turnLeft = 10;

        public ActionState CurrentState { get; private set; }

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
            _turnLeft--;
            CurrentState = _turnLeft == 0 ? ActionState.MonsterTurn : ActionState.None;
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


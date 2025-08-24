using UnityEngine;
namespace CookieGambler
{
    /// <summary>
    /// All the player’s actions must inherit from this class
    /// </summary>
    public abstract class BaseAction : MonoBehaviour
    {
        protected virtual void Update()
        {
            if (Input.GetMouseButtonDown(0) && IsMouseWithinBounds())
            {
                OnClickAction();
                DecrementActionCount();
            }
        }

        /// <summary>
        /// This method decreases the number of actions achievable
        /// </summary>
        protected void DecrementActionCount()
        {
            // Update me when action count per turn is implemented
        }

        /// <summary>
        /// Checks whether the mouse is currently pointing at any collider in the scene.
        /// Casts a ray from the main camera to the mouse position and
        /// <returns> true if it hits any object with a collider.</returns>
        private bool IsMouseWithinBounds()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            return Physics.Raycast(ray);
        }
        /// <summary>
        /// This is the method that the subclasses must overload.
        /// </summary>
        public abstract void OnClickAction();
    }
}


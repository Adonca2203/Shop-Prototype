using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.HeroScripts 
{
    /// <summary>
    /// Checks trigger collision on player
    /// </summary>
    public class CollisionCheck : MonoBehaviour
    {
        [HideInInspector] public UnityEvent interact;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(gameObject.CompareTag("Player") && other.CompareTag("interact"))
            {
                interact?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (gameObject.CompareTag("Player") && other.CompareTag("interact"))
            {
                interact?.Invoke();
            }
        }
    }
}
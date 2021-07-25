using UnityEngine;

namespace Assets.Scripts.HeroScripts
{
    /// <summary>
    /// Movement handler for the player
    /// </summary>
    public class Movement : MonoBehaviour
    {
        Rigidbody2D myRigidbody;
        public float speed;
        private Vector3 change;
        private GameManager gameManager;
        void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        void Update()
        {
            if (gameManager.currentState != GameManager.GameState.play)
                return;

            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");

            change.Normalize();

            if(change != Vector3.zero)
            {
                myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
            }
        }
    }
}
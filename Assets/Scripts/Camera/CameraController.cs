using UnityEngine;

namespace Assets.Scripts.Camera
{
    /// <summary>
    /// Basic Camera Controller with fixed bounds
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        public Transform target;
        public float smoothing;
        public Vector2 maxPosition;
        public Vector2 minPosition;

        private void Start()
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }

        void LateUpdate()
        {
            if (transform.position != target.position)
            {
                Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

                targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
                targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            }
        }
    }
}

using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;            // The position that that camera will be following.
        public float smoothing = 5f;        // The speed with which the camera will be following.
        public float topLimit = 12f;
        public float bottomLimit = -8f;

        //Vector3 offset;                     // The initial offset from the target.
        float m;
        float x;

        void Start ()
        {
            // Calculate the initial offset.
      //      offset = transform.position - target.position;
        }

        void FixedUpdate ()
        {
            //// Create a postion the camera is aiming for based on the offset from the target.
            //Vector3 targetCamPos = target.position + offset;

            //// Smoothly interpolate between the camera's current position and it's target position.
            //transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

            m = -Input.GetAxis("Mouse Y");

            x = transform.localEulerAngles.x;

            if (x > topLimit) x = x - 360;

            if (x + m > topLimit || x + m < bottomLimit) return;

            transform.Rotate(m, 0, 0);

        }
    }
}
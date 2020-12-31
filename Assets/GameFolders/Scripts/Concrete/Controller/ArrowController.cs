using System;
using UnityEngine;

namespace GameFolders.Scripts.Concrete.Controller
{
    public class ArrowController : MonoBehaviour
    {
        [SerializeField] private Transform arrow;
        public GameObject GameObject => arrow.gameObject;

        public void RotateArrow(Vector3 direction)
        {
            direction.y = 0;
            arrow.rotation = Quaternion.LookRotation(direction);

            Vector3 scale = arrow.transform.localScale;
            scale.z = direction.magnitude;
            arrow.transform.localScale = scale;
        }

        public void ResetScale()
        {
            arrow.transform.localScale = Vector3.one;
        }
    }
}
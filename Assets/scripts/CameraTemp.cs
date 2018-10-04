using UnityEngine;
using System.Collections;

namespace RTS
{
    public class CameraTemp: MonoBehaviour
    {
        public float startZoom;

        Transform cameraTrans;

        void Start()
        {
            cameraTrans = Camera.main.transform;

            cameraTrans.position = Vector3.zero;

            cameraTrans.eulerAngles = new Vector3(45f, 0f, 0f);

            cameraTrans.Translate(-Vector3.forward * startZoom);
        }
    }

}
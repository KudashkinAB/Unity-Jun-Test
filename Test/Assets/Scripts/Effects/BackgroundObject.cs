using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Effects
{
    public class BackgroundObject : MonoBehaviour //Для объектов заднего плана
    {
        [SerializeField]
        private float movingSpeed;

        void Update()
        {
            transform.Translate(0, movingSpeed * Time.deltaTime, 0);
        }
    }
}

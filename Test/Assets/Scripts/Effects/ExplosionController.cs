using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class ExplosionController : MonoBehaviour //Контроллер взрывов
    {
        [SerializeField]
        GameObject explosionPrefab;

        public static ExplosionController explosionControllerSingleton;

        private void Awake()
        {
            explosionControllerSingleton = this;
        }

        public void Explode(Vector2 explosionPosition) //Взрыв на заданной позиции
        {
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = explosionPosition;
        }
    }
}

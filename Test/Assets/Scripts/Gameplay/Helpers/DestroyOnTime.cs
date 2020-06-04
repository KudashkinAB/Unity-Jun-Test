using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Helpers
{
    public class DestroyOnTime : MonoBehaviour //Уничтожение объекта через определенное время
    {
        [SerializeField]
        private float destroyTime = 1f;

        private void Start()
        {
            StartCoroutine(DestroyCoroutine());
        }

        IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(destroyTime);
            Destroy(gameObject);
        }
    }
}

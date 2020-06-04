using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Helpers
{
    public class OutOfBorderRestraint : MonoBehaviour //Удержание объекта в границах камеры
    {
        [SerializeField]
        private SpriteRenderer _representation;

        void LateUpdate()
        {
            GameAreaHelper.EncloseInBorders(transform, _representation.bounds);
        }
    }
}

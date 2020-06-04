using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Weapons
{
    public class Turret : MonoBehaviour //Туррель, поворачивающаяся за игроком
    {
        Transform target;
        void Start()
        {
            target = GameController.gameControllerSingleton.playerSpaceship.transform;
        }

        void Update()
        {
            if(target != null)
                transform.right = target.position - transform.position;
        }
    }
}

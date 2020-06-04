using System.Collections;
using System.Collections.Generic;
using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class EnemySinShipController : EnemyShipController //Контроллер кораблей, движущихся по синусоиде(нелинейная)
    {
        [SerializeField]
        private float amplitude = 1f; //Амплитуда синусоиды

        [SerializeField]
        private float frequency = 1f; //Частота

        private float startArguement;


        protected override void Init()
        {
            base.Init();
            startArguement = Random.Range(-10, 10); //Рандомизация начального положения синусоиды
        }

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movementSystem.LongitudinalMovement(Time.deltaTime);
            movementSystem.SetPosition(new Vector2(Mathf.Sign(startArguement) * amplitude * Mathf.Sin(startArguement + transform.position.y / frequency),
                transform.position.y));
        }
    }
}

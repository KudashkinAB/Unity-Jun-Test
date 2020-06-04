using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.ShipSystems;

namespace Gameplay.Bonuses
{
    public class Bonus : MonoBehaviour //Игровые бонусы
    {
        [SerializeField]
        MovementSystem _movementSystem;

        public void Update()
        {
            _movementSystem.LongitudinalMovement(Time.deltaTime);
        }

        protected void OnTriggerEnter2D(Collider2D collision) //При заходе в триггер игрока
        {
            if (collision.gameObject == GameController.gameControllerSingleton.playerSpaceship.gameObject)
            {
                ApplyBonus();
                Destroy(gameObject);
            }
        }

        public virtual void ApplyBonus() { } //Применение бонуса

    }
}

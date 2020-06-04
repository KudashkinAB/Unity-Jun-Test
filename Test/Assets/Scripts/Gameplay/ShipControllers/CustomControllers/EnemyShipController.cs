using System.Collections;
using System.Collections.Generic;
using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class EnemyShipController : ShipController
    {

        [SerializeField]
        private Vector2 _fireDelay;

        [SerializeField]
        private Vector2 _altFireDelay; //По аналогии с _fireDelay для альтернативных атак

        protected bool _fire = false;

        protected bool _altFire = false; //По аналогии с _fire для альтернативных атак

        protected void Start()
        {
            Init();
        }

        protected virtual void Init()
        {
            StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y))); //Чтобы не было мгновенной атаки на старте
            StartCoroutine(AlternativeFireDelay(Random.Range(_altFireDelay.x, _altFireDelay.y)));
        }

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movementSystem.LongitudinalMovement(Time.deltaTime);
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (_fire)
            {
                fireSystem.TriggerFire();
                StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
            }
            if (_altFire)
            {
                fireSystem.TriggerAlternativeFire();
                StartCoroutine(AlternativeFireDelay(Random.Range(_altFireDelay.x, _altFireDelay.y)));
            }
        }

        protected IEnumerator FireDelay(float delay)
        {
            _fire = false;
            yield return new WaitForSeconds(delay);
            _fire = true;
        }

        protected IEnumerator AlternativeFireDelay(float delay) //По аналогии с FireDelay для альтернативных атак
        {
            _altFire = false;
            yield return new WaitForSeconds(delay);
            _altFire = true;
        }
    }
}

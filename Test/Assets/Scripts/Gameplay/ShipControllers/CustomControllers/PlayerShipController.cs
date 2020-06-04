using System.Collections;
using Gameplay.ShipSystems;
using UnityEngine;
using GameUI;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        [SerializeField]
        private float rocketReloadingTime = 2f; //Время кулдауна ракет

        bool rocketReadyToFire = true; //Готовность ракет

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movementSystem.LateralMovement(Input.GetAxis("Mouse X") * Time.deltaTime);
            movementSystem.LongitudinalMovement(Input.GetAxis("Mouse Y") * Time.deltaTime);
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if ((Input.GetMouseButton(0)))
            {
                fireSystem.TriggerFire();
            }
            if((Input.GetMouseButton(1) && rocketReadyToFire))
            {
                fireSystem.TriggerAlternativeFire();
                UIController.UIControllerSingleton.ReloadRocket(rocketReloadingTime);
                StartCoroutine(RocketReloading());
            }
        }

        IEnumerator RocketReloading() //Короутин презарядки
        {
            rocketReadyToFire = false;
            yield return new WaitForSeconds(rocketReloadingTime);
            rocketReadyToFire = true;
        }
    }
}

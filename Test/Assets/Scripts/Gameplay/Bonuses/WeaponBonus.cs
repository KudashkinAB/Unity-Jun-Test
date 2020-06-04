using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI;

namespace Gameplay.Bonuses
{
    public class WeaponBonus : Bonus //Бонус оружия
    {
        [SerializeField]
        float weaponCooldownModifer = 1f;

        [SerializeField]
        float bonusTime;

        public override void ApplyBonus()
        {
            GameController.gameControllerSingleton.playerSpaceship.StartCoroutine(
                GameController.gameControllerSingleton.playerSpaceship.WeaponBonusCoroutine(weaponCooldownModifer, bonusTime));
            UIController.UIControllerSingleton.AddMessage("Бонус оружия " + (1f - weaponCooldownModifer) * 10 + "% на " + bonusTime + " секунд");
        }
    }
}

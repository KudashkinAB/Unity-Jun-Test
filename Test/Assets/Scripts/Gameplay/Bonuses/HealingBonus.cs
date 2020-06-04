using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI;

namespace Gameplay.Bonuses
{
    public class HealingBonus : Bonus //Бонус лечения
    { 
        [SerializeField]
        float healAmount = 50f;
        public override void ApplyBonus()
        {
            GameController.gameControllerSingleton.playerSpaceship.ApplyHeal(healAmount);
            UIController.UIControllerSingleton.AddMessage("Ремонт " + healAmount + " очков брони");
        }
    }
}
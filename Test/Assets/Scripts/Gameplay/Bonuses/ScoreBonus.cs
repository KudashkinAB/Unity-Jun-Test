using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI;

namespace Gameplay.Bonuses
{
    public class ScoreBonus : Bonus //Бонус увеличивающий количество очков
    {
        [SerializeField]
        float time = 20f;

        [SerializeField]
        float scoreModifer = 1f;

        public override void ApplyBonus()
        {
            GameController.gameControllerSingleton.StartCoroutine(GameController.gameControllerSingleton.ScoreModiferCoroutine(scoreModifer, time));
            UIController.UIControllerSingleton.AddMessage("Бонус очков x" + scoreModifer + " на " + time + " секунд");
        }
    }
}

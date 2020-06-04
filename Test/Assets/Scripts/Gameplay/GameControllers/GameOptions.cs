using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Info
{
    public class GameOptions : ScriptableObject //Сохрание данных игры
    {
        public SpaceshipInfo selectedSpaceship;

        public float highScore = 0f;

        public bool countScore(float score)
        {
            if (score > highScore)
            {
                highScore = score;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

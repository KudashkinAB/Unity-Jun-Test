using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Info
{
    [CreateAssetMenu(fileName = "Spaceship", menuName = "Spaceship", order = 99)]
    public class SpaceshipInfo : ScriptableObject //Информация о кораблях, доступных игроку
    {
        public string spaceshipName; //Имя корабля
        public string spaceshipDescription; //Описание
        public GameObject spaceshipPrefab; //Префаб
        public float needScore = 0f; //Количество очков необходимое для открытия корабля
        public Sprite sprite; //Спрайт кнопки
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Gameplay.Info;

namespace GameUI.MainMenu
{
    public class MainMenuUI : MonoBehaviour //Контроллер главного меню
    {
        [SerializeField]
        GameOptions gameOptions;
        [SerializeField]
        Text spaceshipDescriptionText;
        [SerializeField]
        Button playButton;
        [SerializeField]
        Text playButtonText;
        [SerializeField]
        SpaceshipInfo startSpaceship;
        [SerializeField]
        Text highScoreText;

        private void Start()
        {
            ChooseSpaceship(startSpaceship);
            highScoreText.text = "Рекорд: " + gameOptions.highScore.ToString("0");
        }

        public void ChooseSpaceship(SpaceshipInfo spaceshipInfo) //Выбор космического корабля
        {
            spaceshipDescriptionText.text = "<size=25>"+spaceshipInfo.spaceshipName+ "</size>";
            spaceshipDescriptionText.text += "\n" + spaceshipInfo.spaceshipDescription;
            if(spaceshipInfo.needScore > gameOptions.highScore)
            {
                playButton.interactable = false;
                playButtonText.text = "Требуется " + spaceshipInfo.needScore + " очков";
            }
            else
            {
                playButton.interactable = true;
                playButtonText.text = "Играть!";
                gameOptions.selectedSpaceship = spaceshipInfo;
            }
        }

        public void Play() //Закрузка сцены сражения
        {
            SceneManager.LoadSceneAsync(1);
            playButtonText.text = "Загрузка...";
        }

        public void Exit() //Выход?
        {
            Application.Quit();
        }
    }
}

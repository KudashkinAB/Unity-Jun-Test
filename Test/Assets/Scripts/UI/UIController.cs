using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GameUI {
    public class UIController : MonoBehaviour //Контоль игрового UI и менеджмент сцен
    {

        [SerializeField]
        GameObject healthBarLine, rocketBarLine; //Полоски жизни и ракет

        [SerializeField]
        Text scoreText; //текст очков

        List<string> messagesList = new List<string>(); //Список сообщений

        static float messagesReadingTime = 1.5f; //Время чтения сообщения

        [SerializeField]
        Text messagesText; //Текст для сообщений

        [SerializeField]
        GameObject gameOverPanel; //Панель поражения

        [SerializeField]
        Text gameOverScore; //Поле текста финальных очков

        public static UIController UIControllerSingleton { get; private set; }

        private void Awake()
        {
            UIControllerSingleton = this;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void SetHealth(float scale) //установка значения полосы здоровья
        {
            healthBarLine.transform.localScale = new Vector3(scale, 1f, 1f);
        }

        public void ReloadRocket(float reloadingTime) //Перезарядка ракеты
        {
            rocketBarLine.transform.localScale = new Vector3(0f, 1f, 1f);
            StartCoroutine("RocketreLoading", reloadingTime);
        }

        public void SetScore(float score, float modifer) //Установка значения очков
        {
            scoreText.text = score.ToString("0");
            if (modifer != 1f)
                scoreText.text += " x" + modifer.ToString("0");
        }

        public void GameOver(bool isHighScore, float score) //Поражение
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameOverPanel.SetActive(true);
            gameOverScore.text = score.ToString("0");
            if (isHighScore)
                gameOverScore.text += "\n" + "Новый рекорд!";
        }

        public void RestartScene() 
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void OpenMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        public void AddMessage(string message) //Добавить сообщение 
        {
            messagesList.Add(message);
            if (messagesList.Count == 1)
            {
                StartCoroutine(ReadMessage(messagesList[0]));
            }
        }

        IEnumerator RocketreLoading(float time) //Короутин перезагрузки полосы готовности ракеты
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(time / 10);
                rocketBarLine.transform.localScale += new Vector3(0.1f, 0f, 0f);
            }
        }

        IEnumerator ReadMessage(string message) //Чтение сообщения с последующим угасанием и переход к следующему сообщению
        {
            messagesText.text = message;
            messagesText.color += new Color(0, 0, 0, 1f - messagesText.color.a);
            yield return new WaitForSeconds(messagesReadingTime / 2f);
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(messagesReadingTime / (2 * 10f));
                messagesText.color -= new Color(0, 0, 0, 0.1f);
            }
            messagesText.text = "";
            messagesList.RemoveAt(0);
            if (messagesList.Count != 0)
            {
                StartCoroutine(ReadMessage(messagesList[0]));
            }
        }
    }
}

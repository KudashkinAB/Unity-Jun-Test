using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Spaceships;
using GameUI;
using Gameplay.Info;

public class GameController : MonoBehaviour
{
    private float score = 0f;

    private float scoreModifer = 1f;

    public static GameController gameControllerSingleton { get; private set; }

    public Spaceship playerSpaceship;

    [SerializeField]
    GameOptions gameOptions;
    

    void Awake()
    {
        gameControllerSingleton = this;
        GameObject player = Instantiate(gameOptions.selectedSpaceship.spaceshipPrefab);
        playerSpaceship = player.GetComponent<Spaceship>();
        transform.position = new Vector3(0, 0, 0);
    }

    public void AddScore(float addedScore)
    {
        score += addedScore * scoreModifer;
        UIController.UIControllerSingleton.SetScore(score, scoreModifer);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        UIController.UIControllerSingleton.GameOver(gameOptions.countScore(score), score);
    }

    public IEnumerator ScoreModiferCoroutine(float value, float time)
    {
        scoreModifer *= value;
        UIController.UIControllerSingleton.SetScore(score, scoreModifer);
        yield return new WaitForSeconds(time);
        scoreModifer /= value;
        UIController.UIControllerSingleton.SetScore(score, scoreModifer);
    }
}

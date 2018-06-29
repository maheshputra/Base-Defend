using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public static int Lives;
    public static int Scores;
    public int startMoney = 1000;
    public int startLives = 100;
    public int startScores = 0;

    public GameObject GameOverUI;

    public Text gold;
    public Text hp;

    public AudioSource SoundGame;
    public GameObject SoundGameOver;

    void Start() {
        Money = startMoney;
        Lives = startLives;
        Scores = startScores;
        SoundGameOver.SetActive(false);
    }

    void Update()
    {
        hp.text = "" + Lives;
        gold.text = "$" + Money;

        if (Lives <= 0) {
            GameOverUI.SetActive(true);
            SoundGame.Stop();
            SoundGameOver.SetActive(true);
        }
    }


}

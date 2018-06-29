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

    public Text gold;
    public Text hp;

    void Start() {
        Money = startMoney;
        Lives = startLives;
        Scores = startScores;
    }

    void Update()
    {
        hp.text = "" + Lives;
        gold.text = "$" + Money;

        if (Lives <= 0) {
            SceneManager.LoadScene("GameOver");
        }
    }


}

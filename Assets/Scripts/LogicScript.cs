using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Burst.CompilerServices;

public class LogicScript : MonoBehaviour
{
    public int score;
    public Text scoreText;

    private int coin;
    public Text coinText;

    public GameObject gameOverScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // retrieving amount of coins at start of game
        coin = PlayerPrefs.GetInt("CoinAmount", 0);
        coinText.text = coin.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Increase Score")]
    public void addScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void addCoin(int amount)
    {
        coin += amount;
        coinText.text = coin.ToString();
    }

    public void restartGame()
    {
        // saving coin amount so that it does not delete on game reload
        PlayerPrefs.SetInt("CoinAmount", coin);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loadGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
}

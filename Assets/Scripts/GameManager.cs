using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text ScoreText;
    public GameObject GameOver;
    public float WallSpeed = 2f;

    int score = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(SpeedUpRoutine());
    }

    public void AddScore()
    {
        score++;
        ScoreText.text = score.ToString();
        Debug.Log("Score : " + score);
    }

    IEnumerator SpeedUpRoutine()
    {
        while(WallSpeed < 3f)
        {
            yield return new WaitForSeconds(1.0f);

            WallSpeed += 0.1f;
        }
    }

    public void RestartGame()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}

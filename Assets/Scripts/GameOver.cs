using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject healthBarCanvas, scoreCanvas, panel;
    [SerializeField] TextMeshProUGUI scoreText;
    Score score;
    int gecenZaman = 0;
    private void Awake()
    {
        score = GameObject.FindGameObjectWithTag("GameCanvas").GetComponent<Score>();
    }
    void Start()
    {
        Invoke("CloseGame", 3.5f);
    }
    void CloseGame()
    {
        scoreCanvas.SetActive(false);
        healthBarCanvas.SetActive(false);
        panel.SetActive(true);
        scoreText.text = score.GetCurrentScore().ToString();
        Time.timeScale = 0;
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }



}

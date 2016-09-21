using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{

    public GameObject winPanel;
    public Text score;
    public Text winText;

    GameObject gameManager;
    ResetBall resetBall;
    int points;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        resetBall = gameManager.GetComponent<ResetBall>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(transform.tag == "PlayerOne")
        {
            if (other.name == "Ball")
            {
                Destroy(other.gameObject);
                points++;
                score.text = "" + points;
                resetBall.Scored();
                if (points >= 10)
                {
                    winPanel.SetActive(true);
                    winText.text = "Player One Wins!";
                    Time.timeScale = 0;
                }
            }
        }
        if (transform.tag == "PlayerTwo")
        {
            if (other.name == "Ball")
            {
                Destroy(other.gameObject);
                points++;
                score.text = "" + points;
                resetBall.Scored();
                if (points >= 10)
                {
                    winPanel.SetActive(true);
                    winText.text = "Player Two Wins!";
                    Time.timeScale = 0;
                }
            }
        }
    }
}

using TMPro;
using UnityEngine;

public class ShootingSceneController : MonoBehaviour
{
    public int points = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] IntroductionController introductionController;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            introductionController.EnterHelp();
        }

        if(points == 10)
        {
            introductionController.ShowCongrats();
        }
    }

    public void IncreasePoints()
    {
        points++;
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Punkty: " + points + "/10";
    }
}

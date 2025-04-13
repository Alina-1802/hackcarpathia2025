using UnityEngine;

public class IntroductionController : MonoBehaviour
{
    [SerializeField] GameObject basicUI;
    [SerializeField] GameObject introductionUI;
    [SerializeField] GameObject helpUI;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject helpDialog1;
    [SerializeField] GameObject helpDialog2;
    [SerializeField] GameObject player;

    public void ExitIntroduction()
    {
        introductionUI.SetActive(false);
        basicUI.SetActive(true);
    }

    public void EnterHelp()
    {
        helpUI.SetActive(true);
        basicUI.SetActive(false);

        player.GetComponent<PlayerShooting>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
    }

    public void ExitHelp()
    {
        helpUI.SetActive(false);
        basicUI.SetActive(true);

        player.GetComponent<PlayerShooting>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
    }

    public void ShowCongrats()
    {
        winUI.SetActive(true);
        basicUI.SetActive(false);
    }

    public void Send()
    {
        helpDialog1.SetActive(false);
        helpDialog2.SetActive(true);
    }
}

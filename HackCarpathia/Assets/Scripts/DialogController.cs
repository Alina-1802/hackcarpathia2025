using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] GameObject[] welcomeDialogs;
    [SerializeField] GameObject botIcon;
    [SerializeField] GameObject player;
    private int currentDialogIndex = 0;

    /*    public void Start()
        {
            currentDialogIndex = 0;
        }*/

    [SerializeField] GameObject[] categoryPanels;

    public GameObject currentPanel;
    public void ChangePanel()
    {
        if(currentDialogIndex + 1 < welcomeDialogs.Length)
        {
            welcomeDialogs[currentDialogIndex].SetActive(false);
            currentDialogIndex++;
            welcomeDialogs[currentDialogIndex].SetActive(true);
        }
    }

    public void ExitDialogs()
    {
        welcomeDialogs[currentDialogIndex].SetActive(false);
        botIcon.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
    }

    public void ShowPanel(int id)
    {
        categoryPanels[id].SetActive(true);
        currentPanel = categoryPanels[id];
    }

    public void ClosePanel()
    {
        currentPanel.SetActive(false);
    }

}

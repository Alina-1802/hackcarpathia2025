using UnityEngine;

public class Collision : MonoBehaviour
{
    public int id;
    [SerializeField] DialogController controller;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // show panel
            controller.ShowPanel(id);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // hide panel
            controller.ClosePanel();
        }
    }
}

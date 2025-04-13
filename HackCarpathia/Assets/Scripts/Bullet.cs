using UnityEngine;

public class Bullet : MonoBehaviour
{
    ShootingSceneController shootingSceneController;
    public float lifetime = 6f;

    void Start()
    {
        Destroy(gameObject, lifetime);
        shootingSceneController = GameObject.FindAnyObjectByType<ShootingSceneController>();
    }

    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if(other.gameObject.CompareTag("Target"))
        {
            // to do:  add points
            // to do: update ui
            shootingSceneController.IncreasePoints();
            shootingSceneController.UpdateScoreText();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

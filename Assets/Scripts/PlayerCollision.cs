using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public TextMeshProUGUI message;
    public GameManager gm;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!GameManager.gameOver && col.gameObject.CompareTag("Box")) // camera can shake even if shielded
        {
            CameraShake camShake = Camera.main.GetComponent<CameraShake>();
            if (camShake != null)
            {
                StartCoroutine(camShake.Shake(0.2f, 0.15f));
            }
            if (!GameManager.hasShield) // only lose if not shielded
            {
                gm.Lose();
            }
        }
    }
}

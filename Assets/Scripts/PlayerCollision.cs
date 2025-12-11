using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public TextMeshProUGUI message;
    public GameManager gm;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Box") && !GameManager.hasShield) // only let the player lose on collision if no shield
        {
            gm.Lose();
        }
    }
}

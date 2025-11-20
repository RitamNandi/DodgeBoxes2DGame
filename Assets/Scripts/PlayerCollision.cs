using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public TextMeshProUGUI message;
    public GameManager gm;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Box"))
        {
            gm.Lose();
        }
    }
}

using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            PlayerScript.hit = true;
        }
    }
}

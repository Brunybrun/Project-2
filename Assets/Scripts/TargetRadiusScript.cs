using UnityEngine;

public class TargetRadiusScript : MonoBehaviour
{
    public static bool move = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = true;
        }
    }
}

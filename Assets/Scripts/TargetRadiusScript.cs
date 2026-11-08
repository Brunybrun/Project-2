using UnityEngine;

public class TargetRadiusScript : MonoBehaviour
{
    public static bool move = false;

    //Allows the enemy to start moving
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = true;
        }
    }

    //Stops the enemy from moving
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = false;
        }
    }
}

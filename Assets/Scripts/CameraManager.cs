using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private CinemachineCamera Camera;
    public GameObject playerChar;
    public GameObject ghostChar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera = GetComponent<CinemachineCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.hit == false)
        {
            Camera.Target.TrackingTarget = playerChar.transform;
        }
        else if (PlayerScript.hit)
        {
            Camera.Target.TrackingTarget = ghostChar.transform;
        }
    }
}

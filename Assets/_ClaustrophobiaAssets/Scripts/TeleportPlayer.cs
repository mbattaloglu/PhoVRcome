using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    private static TeleportPlayer instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public static TeleportPlayer GetInstance()
    {
        return instance;
    }

    public GameObject player;
    public Camera playerHead;

    public void Teleport(Transform point)
    {
        var rotationAngleY = point.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;

        player.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = point.position - playerHead.transform.position;

        player.transform.position += distanceDiff;
    }

}

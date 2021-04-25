using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCam : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform topRight;
    [SerializeField] Transform bottomLeft;

    private float widthOffset = 28.5f;
    private float heightOffset = 15.0f;

    // Update is called once per frame
    void Update()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        if (IsInXBound())
        {
            newX = Mathf.Lerp(transform.position.x, player.position.x, 0.1f);
        }

        if (IsInYBound())
        {
            newY = Mathf.Lerp(transform.position.y, player.position.y, 0.1f);
        }

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    private bool IsInXBound()
    {
        float playerX = player.position.x;
        bool notPassLeftEdge = playerX - widthOffset >= bottomLeft.position.x;
        bool notPassRightEdge = playerX + widthOffset <= topRight.position.x;
        if (notPassLeftEdge && notPassRightEdge)
            return true;

        return false;
    }

    private bool IsInYBound()
    {
        float playerY = player.position.y;
        bool notPassTopEdge = playerY + heightOffset <= topRight.position.y;
        bool notPassBottomEdge = playerY - heightOffset >= bottomLeft.position.y;
        if (notPassTopEdge && notPassBottomEdge)
            return true;

        return false;
    }
}

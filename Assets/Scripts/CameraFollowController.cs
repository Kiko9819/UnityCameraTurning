using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public Player player;
    public float timeOffset = 2.5f;
    public bool canMoveY = false;

    public Vector3 posOffset;

    private void FixedUpdate()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = player.transform.position;
        
        if(player.FacingDirection == Player.Direction.RIGHT)
        {
            endPosition.x += posOffset.x;
        }

        if(player.FacingDirection == Player.Direction.LEFT)
        {
            endPosition.x -= posOffset.x;
        }

        if (!canMoveY)
        {
            endPosition.y = 0;
        }
        endPosition.z = -10;

        transform.position = Vector3.Lerp(startPosition, endPosition, Time.fixedDeltaTime * timeOffset);
    }
}

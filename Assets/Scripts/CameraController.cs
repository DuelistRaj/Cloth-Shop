using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector2 minXY, maxXY;

    [SerializeField]
    private float smoothing = 0.1f;

    private void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(targetPos.x, minXY.x, maxXY.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minXY.y, maxXY.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}

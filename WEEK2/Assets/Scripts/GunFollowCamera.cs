using UnityEngine;

public class GunFollowCamera : MonoBehaviour
{
    public Transform cam;
    public Vector3 positionOffset;

    void LateUpdate()
    {
        // カメラ基準で位置追従
        transform.position = cam.position + cam.TransformDirection(positionOffset);

        // カメラの向きに追従（TPSはこれでOK）
        transform.rotation = cam.rotation;
    }
}
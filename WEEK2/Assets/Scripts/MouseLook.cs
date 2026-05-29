using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform cameraPivot; // 上下
    public Transform playerBody;   // 左右

    public float sensitivity = 200f;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // 左右回転（プレイヤー本体）
        playerBody.Rotate(Vector3.up * mouseX);

        // 上下回転（X軸を自前管理）
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
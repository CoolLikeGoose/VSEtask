using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float _rotationX = 0;

    private void Update()
    {
        RotateYAxis();
    }

    private void RotateYAxis()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * GameManager.Instance.verticalMouseSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -90, 90);

        Vector3 rotation = transform.localEulerAngles;
        rotation.x = _rotationX;

        transform.localEulerAngles = rotation;
    }
}

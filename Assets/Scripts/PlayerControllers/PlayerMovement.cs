using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10f;

    private void Update()
    {
        Move();
        RotateXAxis();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * playerSpeed;
        movement = Vector3.ClampMagnitude(movement, playerSpeed);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }

    private void RotateXAxis()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * GameManager.Instance.horizontalMouseSpeed, 0);
    }
}

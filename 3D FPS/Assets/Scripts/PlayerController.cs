
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float lookSensitivity = 3;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();

    }

    void Update()
    {
        //Calculate movement veocity as a 3D vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _movVerticle = transform.forward * _zMov;

        //Final Movement Vector
        Vector3 _velocity = (_moveHorizontal + _movVerticle).normalized * speed;
        //Apply Movement
        motor.Move(_velocity);

        //Calculate rotation as a 3D vector (turning arround)
        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;
        //Apply Rotate
        motor.Rotate(_rotation);

        //Calculate Camera rotation as a 3D vector
        float _xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;
        //Apply Camera Rotation
        motor.rotateCamera(_cameraRotation);
    }
        
}

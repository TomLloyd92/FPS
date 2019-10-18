using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;




    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    //Gets Movement Vec
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //Gets Rotate Vec
    public void Rotate( Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //Gets Camera Rotate vec
    public void rotateCamera( Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }


    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Perform Movement based on the vel vec
    void PerformMovement ()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }


    //Perform Rotation based on the Rot Vec
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if(cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }

}

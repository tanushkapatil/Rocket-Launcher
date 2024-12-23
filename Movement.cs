using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation ;
    [SerializeField] float thrustStrength = 1000f;
    [SerializeField] float rotationStrength = 100f;
    
    Rigidbody rb ;

    private void Start() {
       rb = GetComponent<Rigidbody>();  
    }

    private void OnEnable() {
        thrust.Enable();
        rotation.Enable();  
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }

    private void ProcessRotation() {
        float rotationinput = rotation.ReadValue<float>() ; 
        if(rotationinput > 0) {
            ApplyRotation(-rotationStrength);
        }
        else if(rotationinput < 0)
        {
            ApplyRotation(rotationStrength);
        }
    }

    private void ApplyRotation(float rotationframe)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationframe * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}

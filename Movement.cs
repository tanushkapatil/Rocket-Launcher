using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] float thrustStrength = 1000f;
    Rigidbody rb ;

    private void Start() {
       rb = GetComponent<Rigidbody>();  
    }

    private void OnEnable() {
        thrust.Enable();
    }

    private void FixedUpdate() {
        if(thrust.IsPressed()){
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }
    
}

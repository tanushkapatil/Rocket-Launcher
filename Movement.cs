using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
        [SerializeField] InputAction thrust;

        private void OnEnable() {
            thrust.Enable();
        }
    
}

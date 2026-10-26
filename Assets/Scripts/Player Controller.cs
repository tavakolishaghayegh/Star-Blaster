using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MoveSpeed=10f;
    InputAction moveAction;
    Vector3 moveVector;

     
    void Start()
    {
        moveAction=InputSystem.actions.FindAction("Move");
        
    }

    
    void Update()
    {
        MovePlayer();
        
    }
    void MovePlayer()
    {
        moveVector=moveAction.ReadValue<Vector2>();
        transform.position +=moveVector * MoveSpeed * Time.deltaTime;
        
    }
}

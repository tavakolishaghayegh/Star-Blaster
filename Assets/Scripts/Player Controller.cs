using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MoveSpeed=10f;
    [SerializeField] float leftBoundPadding; 
    [SerializeField] float rightBoundPadding; 
    [SerializeField] float upBoundPadding;
    [SerializeField] float downBoundPadding;
    InputAction moveAction;
    Vector3 moveVector;
    Vector2 minBounds;
    Vector2 maxBounds;

     
    void Start()
    {
        moveAction=InputSystem.actions.FindAction("Move");
        InitBounds();

        
        
    }

    
    void Update()
    {
        MovePlayer();
        
    }
    void InitBounds()
    {
        Camera mainCamera = Camera.main; 
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        
        
        
        
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * MoveSpeed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + leftBoundPadding, maxBounds.x - rightBoundPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + downBoundPadding, maxBounds.y - upBoundPadding); 
       
        transform.position = newPos;
       

         

        
        
    }
}

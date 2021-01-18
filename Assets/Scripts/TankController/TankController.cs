using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Collider))]
public class TankController : MonoBehaviour
{  
    [SerializeField] private float moveSpeed = 2f;
    private CharacterController ch;
    private Vector3 moveDir;

    private void Awake()
    {
        ch = GetComponent<CharacterController>();
        moveDir = new Vector3();
    }

    private void Update()
    {
        float yPrev = moveDir.y;

        //Keyboard input
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.y = 0f;
        moveDir.z = Input.GetAxis("Vertical");
        moveDir = moveDir.normalized;

        //Adding speed
        moveDir *= moveSpeed * Time.deltaTime;

        //Gravity
        if (!ch.isGrounded || ch.velocity.y < 0f)
        {
            moveDir.y = yPrev - (9.81f * Time.deltaTime * Time.deltaTime);
        }
             
        //Move in forward direction
        moveDir = transform.TransformDirection(moveDir);

        ch.Move(moveDir);
    }
}

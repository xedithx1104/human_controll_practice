using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;  //���ⱱ�
    public Transform cam;  //�۾�

    public Transform groundCheck;  //���ݮy�СA�ΨӧP�_�O�_�ۦa
    public Animator ani;  //�ʵe

    public float speed = 6f;  //�����t��
    public float gravity = -9.81f;  //���O�[�t��
    public float jumpHeight = 2f;  //���D����
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private Vector3 velocity;
    private bool isGrounded = true;

    private void Start()
    {
        ani = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        PlayerMove();
    }


    ///<summary>
    ///�H�����M�]
    /// </summary>
    public void PlayerMove() 
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 diretion = new Vector3(horizontal, 0f, vertical).normalized;

        if (diretion.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(diretion.x, diretion.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);


            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                speed = 10f;
                ani.SetFloat("Blend", 2);
            }
            else
            {
                speed = 6f;
                ani.SetFloat("Blend", 1);
            }
        }
        else {
            ani.SetFloat("Blend", 0);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            ani.SetTrigger("jump1");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("attack");
        }


        velocity.y += gravity * 2 * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

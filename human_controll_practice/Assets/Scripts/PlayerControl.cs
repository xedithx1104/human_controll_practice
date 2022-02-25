using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator ani; 

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        Vector3 diretion = new Vector3(horizontal, 0f, vertical).normalized;

        if (diretion.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(diretion.x, diretion.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(diretion * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) { ani.SetBool("run", true); }
            else {
                ani.SetBool("run", false);
                ani.SetBool("walk", true);
                
            }

        }
        else {
            ani.SetBool("walk", false);
        }
    }
}

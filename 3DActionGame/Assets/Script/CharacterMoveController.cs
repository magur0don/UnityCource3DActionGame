using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    public float Speed = 6f;

    private Animator m_animator = null;
    private Rigidbody m_rigidbody = null;
    private Vector3 m_direction = Vector3.zero;

    private CharacterController m_characterController = null;
    private float m_turnSmoothVerocity = 0f;
    private float m_turnSmoothTime = 0.1f;

    private float m_gravityValue = -9.81f;
    private Vector3 m_playerGravityVelocity = Vector3.zero;

    private bool m_jumpFlag = false;

    private bool m_punchFlag = false;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
        m_characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        m_jumpFlag = Input.GetKeyDown(KeyCode.Space);

        m_punchFlag = Input.GetKeyDown(KeyCode.Z);

        Move(h, v);
    }

    private void Move(float horizontal, float vertical)
    {
        if (m_punchFlag)
        {
            m_animator.SetTrigger("Punch");
        }

        if (m_jumpFlag && m_characterController.isGrounded)
        {
            m_playerGravityVelocity.y = 6;
            m_animator.SetTrigger("Jump");
            m_characterController.Move(m_playerGravityVelocity * Time.deltaTime);
            m_jumpFlag = false;
        }

        var cameraFoward = Camera.main.transform.forward;
        cameraFoward.y = 0;
        cameraFoward = cameraFoward.normalized;
        if (cameraFoward.sqrMagnitude < 0.01f)
            return;

        Quaternion inputFrame = Quaternion.LookRotation(cameraFoward, Vector3.up);
        var input = new Vector3(horizontal, 0, vertical);
        var cameraFromPlayer = inputFrame * input;

        if (cameraFromPlayer.sqrMagnitude >= 0.1f)
        {
            var targetAngle = Mathf.Atan2(cameraFromPlayer.x, cameraFromPlayer.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref m_turnSmoothVerocity, m_turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            m_characterController.Move(cameraFromPlayer * Speed * Time.deltaTime);
        }
        
        if (!m_jumpFlag && !m_characterController.isGrounded)
        {
            m_playerGravityVelocity.y += m_gravityValue * Time.deltaTime;
            m_characterController.Move(m_playerGravityVelocity * Time.deltaTime);
        }

        m_animator.SetFloat("FrontVelocity", cameraFromPlayer.magnitude);
    }

    public void FootR()
    {
    }
    public void FootL()
    {
    }
}

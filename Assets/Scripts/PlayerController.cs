using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
    {

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private int attackPower;
    
    [SerializeField] private float attackDuration;
    [SerializeField] public GameObject attackBox;
      
    public GameObject AttackBox { get => attackBox; set => attackBox = value; }
    public int AttackPower { get => attackPower; set => attackPower = value; }
      

    //used to enable double Jump
    private bool canDoubleJump;
    public Animator _anim;
    public float jumpVal = 10;


    //Use to disable the movement according to the timer
    public bool canMove = true;
    public bool canAttack = true;
    private bool IsGrounded = true;

    //To use the method of cameracontrol script
    private CameraControll cameControl;
    private HealthController health;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        //To get the CameraControl script and assign our name to it
        cameControl = FindObjectOfType<CameraControll>();
        health = GetComponent<HealthController>();
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        transform.position += new Vector3(body.velocity.x, body.velocity.y, 0) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        health.HealthBarActive(canMove);
        if (DialogManager.isActive == true)
        {
            return;
        }

        if (canAttack)
        {
            if (canMove)
            {
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, body.velocity.y);
                if (body.velocity.x < -0.1)
                {
                    transform.localScale = new Vector3(-1, transform.localScale.y);
                }
                else if (body.velocity.x > 0.1)
                {
                    transform.localScale = new Vector3(1, transform.localScale.y);
                }

                if (Input.GetButtonDown("Jump"))
                {
                    FindObjectOfType<AudioManager>().PlaySFX(5);
                    Jump();
                }

                if (Input.GetButtonDown("Fire1"))
                {
                    _anim.SetTrigger("attack");
                    canAttack = false;
                }

                if (Input.GetKeyDown(KeyCode.U))
                {
                    _anim.SetTrigger("attack");
                    canMove = false;
                }

                cameControl.UpdatePlayer(this.gameObject);
            } else {
                body.velocity = Vector2.zero;
            }
        } else {
            body.velocity = Vector2.zero;
        }

        _anim.SetBool("jump", IsGrounded);
        _anim.SetFloat("move", Mathf.Abs(body.velocity.x));

    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.name == "ground") {
            IsGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if(other.transform.name == "ground") {
            IsGrounded = false;
        } 
    }

    private void Jump()
    {
        if (IsGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, verticalSpeed);
            canDoubleJump = true;
        }
        else
        {
            if (canDoubleJump)
            {
                canDoubleJump = false;
                body.velocity = new Vector2(body.velocity.x, verticalSpeed);
            }
        }
    }
    
    private IEnumerator ActivateAttack()
    {
        attackBox.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackBox.SetActive(false);
    }

    public void ActiveInScene(bool swapPlayer)
    {
        canMove = swapPlayer;
    }
}

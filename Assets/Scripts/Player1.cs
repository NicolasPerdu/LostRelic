using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player1 : PhysicsObject
{

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private int attackPower;
    
    [SerializeField] private float attackDuration;
    [SerializeField] private GameObject attackBox;
      
    public GameObject AttackBox { get => attackBox; set => attackBox = value; }
    public int AttackPower { get => attackPower; set => attackPower = value; }
      

    //used to enable double Jump
    private bool canDoubleJump;    

    //Use to disable the movement according to the timer
    private bool canMove = true;
 


    //singleton instantiation 
    private static Player1 instance;
    public static Player1 Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<Player1>();
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //The update will only work if the canMove is true currently it is set true coz its the first player
        if (canMove)
        {
            targetVelocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, 0);
            if (targetVelocity.x < -0.1)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y);
            }
            else if (targetVelocity.x > 0.1)
            {
                transform.localScale = new Vector3(1, transform.localScale.y);
            }
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(ActivateAttack());
            }
            
        }

    }
    private void Jump()
    {
        if (grounded)
        {
            velocity.y = verticalSpeed;
            canDoubleJump = true;
        }
        else
        {
            if (canDoubleJump)
            {
                canDoubleJump = false;
                velocity.y = verticalSpeed;
            }
        }

    }
    

    
    private IEnumerator ActivateAttack()
    {
        attackBox.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackBox.SetActive(false);
    }

    //Public function that will determine whether canmove is true or not via the passed in parameter
    public void ActiveInScene(bool swapPlayer)
    {
        //As canMove is true in the start so it will be false when swapplayer is true and next  time it will true
        canMove = !swapPlayer;
       
    }
}

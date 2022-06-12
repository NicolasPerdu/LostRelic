using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player2 : PhysicsObject
{
    /* public float speed = 15f;




     // Update is called once per frame
     void //Update()
     {
         float movement = Input.GetAxis("Horizontal");
         transform.Translate(Vector3.right * movement * Time.deltaTime * speed);


     } */

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private int attackPower;
    [SerializeField] private int health;
    [SerializeField] private float attackDuration;
    [SerializeField] private GameObject attackBox;
    [SerializeField] private Image healthBar;


    public int Health { get => health; set => health = value; }
    public GameObject AttackBox { get => attackBox; set => attackBox = value; }
    public int AttackPower { get => attackPower; set => attackPower = value; }


    private Vector2 healthBarOriginalSize;

    //used to enable double Jump
    private bool canDoubleJump;

    //constrain Player max health to 100
    private int maxHealth = 100;

    //Use to disable the movement, Currently player 2 is disabled
    private bool canMove = false;


    //singleton instantiation 
    private static Player2 instance;
    public static Player2 Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<Player2>();
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
       
        healthBarOriginalSize = healthBar.rectTransform.sizeDelta;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
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
            Die();
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
    public void UpdateUI()
    {
        float healthBarSize = healthBarOriginalSize.x * ((float)Health / (float)maxHealth);
        healthBar.rectTransform.sizeDelta = new Vector2(healthBarSize, healthBar.rectTransform.sizeDelta.y);
    }

    private void Die()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
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
        //As canMove is false in the start so it will be true when swapplayer is true and next  time it will false
        canMove = swapPlayer;

    }

}

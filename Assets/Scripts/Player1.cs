using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : PhysicsObject
{

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private GameObject attackBox;
    [SerializeField] private int attackPower;
    [SerializeField] private int health;
    [SerializeField] private float attackDuration;


    public int Health { get => health; set => health = value; }
    public GameObject AttackBox { get => attackBox; set => attackBox = value; }
    public int AttackPower { get => attackPower; set => attackPower = value; }

    private bool canDoubleJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}

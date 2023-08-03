using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float dashForce = 10f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;

    public Weapon currentWeapon;
    public GameObject bullet;
    private float nextTimeOfFire = 0;


    public Animator animator;

    private Rigidbody2D playerRigidbody2D;
    private Vector2 playerDirection;
    private bool isDashing;
    private bool canDash;



    private void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        canDash = true;
        
    }

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextTimeOfFire)
            {
                currentWeapon.Shoot();
                nextTimeOfFire = Time.time + 0.3f / currentWeapon.fireRate;
            }
        }

        

        playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && canDash)
        {
            isDashing = true;
            canDash = false;
            StartCoroutine(DashCoroutine());
        }

        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));

        animator.SetFloat("Speed", playerDirection.sqrMagnitude);
            
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            playerRigidbody2D.MovePosition(playerRigidbody2D.position + playerDirection * playerSpeed * Time.fixedDeltaTime);
        }
    }

    private IEnumerator DashCoroutine()
    {
        float elapsedTime = 0f;
        Vector2 dashDirection = playerDirection.normalized;

        while (elapsedTime < dashDuration)
        {
            playerRigidbody2D.velocity = dashDirection * dashForce;
            elapsedTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        playerRigidbody2D.velocity = Vector2.zero;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
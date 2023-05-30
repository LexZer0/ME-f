using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("�haracteristic")]
    public int Health;
    public float moveSpeed;
    public float ArrowSpeed;
    public float ArrowRange;
    public float shootingRecoilBase;

    [Space]
    [Header("System Settings")]
    public Animator animator;
    public Rigidbody2D rb;
    public GameObject crossHair;
    private Vector2 moveDirection;
    private Vector2 aim;
    public float distanceOfCrossHair = 1;
    public float shootingRecoil = 0;
    public bool endOfAiming;
    public bool isAiming;
    public GameObject Arrow;
    private float InGameMoveSpeed;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
        ProcessInputs();
        Shoot();
        Move();
        MoveCrossHair();

    }
    private void FixedUpdate()
    {
        if (Health == 0)
        {
            //Destroy();


        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        moveDirection = new Vector2(moveX, movey).normalized;
        Vector2 mouseMovement = new Vector2(mouseX, mouseY);
        isAiming = Input.GetButton("Fire1");
        aim += mouseMovement;
        endOfAiming = Input.GetButtonUp("Fire1"); //Ctrl or mouseLeftclick

        
        if (isAiming)
        {
            InGameMoveSpeed = moveSpeed / 2;
        }
        else
        {
            InGameMoveSpeed = moveSpeed;
        }

    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * InGameMoveSpeed, moveDirection.y * InGameMoveSpeed);
    }
    private void MoveCrossHair()
    {


        if (aim != Vector2.zero)
        {
            aim.Normalize();
            aim *= distanceOfCrossHair;
            crossHair.transform.localPosition = aim;
        }
        else
        {
            crossHair.transform.localPosition = new Vector3(0, 0, -100);
        }

    }
    void Shoot()
    {
        Vector2 shootingDirection = crossHair.transform.localPosition;
        shootingDirection.Normalize();
        if (shootingRecoil > 0)
        {
            shootingRecoil -= Time.deltaTime;
        }
        if (endOfAiming && shootingRecoil<=0)
        {
            GameObject arrow = Instantiate(Arrow, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * ArrowSpeed;
            arrow.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            Destroy(arrow, ArrowRange);           
            shootingRecoil = shootingRecoilBase;
            
        }
    }


}



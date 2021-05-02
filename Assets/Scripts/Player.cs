using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float rotattingSpeed = 5f;
    public Transform gunJoint, gun, barrel;
    public GameObject playerProjectilePrefab;
    private Rigidbody2D rb;
    private Vector2 movement;

    private int greens, reds = 0;
    public int health = 100;
    public TextMeshProUGUI redsText, GreensText, healthText;
    public List<GameObject> lives;
    private int currentDamage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void Start()
    {
        currentDamage = 500;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (greens > 0 && reds > 0)
            {
                reds--;
                redsText.text = reds.ToString();
                greens--;
                GreensText.text = greens.ToString();
                var go = Instantiate(playerProjectilePrefab, barrel.position, barrel.transform.rotation);
                go.transform.SetParent(null);
                go.GetComponent<Rigidbody2D>().AddForce(barrel.up * 20f, ForceMode2D.Impulse);
                go.GetComponent<PlayerProjectile>().SetDamage(currentDamage);
            }
        }
       
    }
    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);


        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    public void RedAbsorbed(GameObject redObj)
    {
        Destroy(redObj);
        reds++;
        redsText.text = reds.ToString();
    }

    public void GreenAbsorbed(GameObject greenObj)
    {
        Destroy(greenObj);
        greens++;
        GreensText.text = greens.ToString();
    }

    public void DealWithDamage(int enemyProjectileDamage)
    {
        health -=enemyProjectileDamage;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            health = 100;
            Destroy(lives.First());
        }        
    }
}

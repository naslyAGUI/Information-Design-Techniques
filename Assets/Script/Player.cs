using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {

    
    public float speed;
    private Rigidbody2D rb2d;






    public AudioSource PicUpSound;
    public Animator anim;

    Rigidbody2D rb;
    public Text countText;
    public Text winText;
    public Text socialText;
    float dirX, dirY;
    public float moveSpeed = 6f;
    public static float lifeAmount;
    float x = 1.32f;
    float y = 1.03f;
    private int count;
    public Text GameOverText;
    //public Text LifeCountShow;
    
    public AudioSource winSound;
    public AudioSource GameOverSound;
    

    //public Animator animator;
    

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();



        lifeAmount = 0.4f;
        anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        PicUpSound = GetComponent<AudioSource>();

       


        count = 0;
        winText.text = "";
        SetCountText();
        GameOverText.text = "";
        //socialText.text = "";


    }

   
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * moveSpeed;
        dirY = Input.GetAxis("Vertical") * moveSpeed;

   
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            anim.Play("idle");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            anim.Play("walking");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            anim.Play("New State");
        }


        if (lifeAmount <= 0.1)
        {
            GameOverSound.Play();
            Destroy(gameObject);

            GameOverText.text = "Game Over :(";

            

        }
       

      
    }

    public void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);

        anim.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        anim.SetFloat("Speed", Mathf.Abs(moveVertical));
        //animator.SetTrigger("pickups");



        rb.velocity = new Vector2(dirX, dirY);



        

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PickUp"))
        {

            x += 0.1f; y += 0.1f;
            transform.localScale = new Vector3(x, y);
            col.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            PicUpSound.Play();
       }
        
        if (col.gameObject.name.Equals("Wall_1"))
        {
            
            GameOverSound.Play();
            Destroy(gameObject);
            GameOverText.text = "Game Over :(";

        }
        if (col.gameObject.name.Equals("Wall_2"))
        {
            
            GameOverSound.Play();
            Destroy(gameObject);
            GameOverText.text = "Game Over :(";
        }
        if (col.gameObject.name.Equals("Wall_3"))
        {
            
            GameOverSound.Play();
            Destroy(gameObject);
            GameOverText.text = "Game Over :(";

        }

        if (col.gameObject.name.Equals("Wall_4"))
        {
            
            GameOverSound.Play();
            Destroy(gameObject);
            GameOverText.text = "GAME OVER :(";
            
        }
       

        if (col.gameObject.name.Equals("Enemy_1"))
        {
            
            GameOverSound.Play();
            //b.Play();
            //col.gameObject.SetActive(false);
           //socialText.text = "be careful";
        }
        if (col.gameObject.name.Equals("Enemy_2"))
        {
            
            GameOverSound.Play();


        }
        if (col.gameObject.name.Equals("Enemy_3"))
        {
          
            GameOverSound.Play();


        }

        if (col.gameObject.name.Equals("Enemy_4"))
        {
           
            
            GameOverSound.Play();

        }

        if (col.gameObject.name.Equals("Enemy_5"))
        {
            
            GameOverSound.Play();


        }
        if (col.gameObject.name.Equals("Emeny_5"))
        {
            
            GameOverSound.Play();
        }
        
            

    }
   
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 25)
        {
           winSound.Play();
            winText.text = " YOU WON! ";
           
        }
    }
  
     



}

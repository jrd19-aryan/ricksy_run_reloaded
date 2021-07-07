using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscr : MonoBehaviour
{   
    public GameObject player;
    public GameObject portalin;
    public GameObject portalout;
    public GameObject pausemenu;
    public GameObject scorer;

    public float speed;   //speed of player
    public float placeR;  //radius in which portals can be placed
    public float moveHorizontal;
    public int leftright;

    private Vector3 target;  //mouse click position
    private Rigidbody2D rb;  
    private float dist;      //distance of player from click position
    //private int count;       //collectible count
    private float timer;     //timer to stop gun animation
    public string level;     //current level name
    float touchDuration;
    Touch touch;



    public Animator animator;

    private SpriteRenderer mySpriteRenderer;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //players rigidbody component is stored
        //count = 0;  //score set to zero
        mySpriteRenderer = GetComponent<SpriteRenderer>(); //sprtie renderer componenet is stored
        //scorer = GameObject.FindWithTag("score");
        //score playerScript = scorer.GetComponent<score>();
        //GameObject.FindWithTag("score").GetComponent<score>();
    }

    IEnumerator singleOrDouble()
    {
        yield return new WaitForSeconds(0.3f);
        if (touch.tapCount == 1)
        {
            //tapperno = 1;
            Debug.Log("Single");
            portalin.transform.position = target;    //places portal
            animator.SetBool("shoot", true);         //plays shoot animation
            GameObject.FindWithTag("score").GetComponent<score>().clicks += 1;
        }
        else if (touch.tapCount == 2)
        {
            //this coroutine has been called twice. We should stop the next one here otherwise we get two double tap
            StopCoroutine("singleOrDouble");
            Debug.Log("Double");
            //tapperno = 2;
            portalout.transform.position = target;
            animator.SetBool("shoot", true);
            GameObject.FindWithTag("score").GetComponent<score>().clicks += 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis ("Horizontal");  //input from left/right key

        Vector2 movement = new Vector2 (moveHorizontal, 0.0f);  //motion
        

        rb.AddForce (movement * speed);

        animator.SetFloat("speed",Mathf.Abs(moveHorizontal)); //movement animation

        if (moveHorizontal < 0)
        {
            Vector3 scale = player.transform.localScale;
            scale.x = -1;
            player.transform.localScale = scale;
            animator.SetBool("shoot",false);  //stops shoot animation on moving
        }
        if (moveHorizontal > 0)
        {
            Vector3 scale = player.transform.localScale;
            scale.x = 1;
            player.transform.localScale = scale;
            animator.SetBool("shoot",false);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "portal in") 
		{
			Debug.Log("hit");
            transform.position = portalout.transform.position;  //teleportation
		}

        /*if (other.gameObject.tag == "collect")
        {
            other.gameObject.SetActive (false);
            count = count + 1;
        }*/

        if (other.gameObject.tag == "morty" && level != "Level 3")
        {
            FindObjectOfType<gamemanager>().levelcomplete();  //level completes on reaching morty except on 3rd level
        }

        
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            FindObjectOfType<gamemanager>().Gameover();  //game over on touching enemy
        }
        if (other.gameObject.tag == "boss")
        {
            Debug.Log("kill");
            FindObjectOfType<gamemanager>().Gameover();  //game over on touching enemy
        }
    }

    /*public static bool IsDoubleTap()
    {
        bool result = false;
        float MaxTimeWait = 1;
        float VariancePosition = 3;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch(0).deltaTime;
            float DeltaPositionLenght = Input.GetTouch(0).deltaPosition.magnitude;

            if (DeltaTime > 0 && DeltaTime < MaxTimeWait && DeltaPositionLenght < VariancePosition)
                result = true;
        }
        return result;
    }*/



    void Update()
    {
        timer += Time.deltaTime;   //timer for shoot animation

        /*if (Input.GetMouseButtonDown(0) && !pausemenu.activeSelf)    //left click for in portal
        {
            timer = 0;                                                          //sets timer to 0
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);       //target is position of mouse, z value of target must be 0
            target.z = 0;
            dist = Vector3.Distance(player.transform.position, target);         //distance between click and player

            RaycastHit2D hit = Physics2D.Raycast(target, Vector2.zero);
            if (hit.collider != null)
            {
                if (dist <= placeR && hit.collider.gameObject.tag == "background")   //if click is within radius
                {
                    portalin.transform.position = target;   //places portal
                    animator.SetBool("shoot", true);         //plays shoot animation
                    GameObject.FindWithTag("score").GetComponent<score>().clicks += 1;
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && !pausemenu.activeSelf)      //right click for blue portal
        {
            timer = 0;
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            dist = Vector3.Distance(player.transform.position, target);

            RaycastHit2D hit = Physics2D.Raycast(target, Vector2.zero);
            if (hit.collider != null)
            {
                if (dist <= placeR && hit.collider.gameObject.tag == "background")
                {
                    portalout.transform.position = target;
                    animator.SetBool("shoot", true);
                    GameObject.FindWithTag("score").GetComponent<score>().clicks += 1;
                }
            }
        }*/

        
        if (Input.touchCount > 0 && !pausemenu.activeSelf)
        {
            timer = 0;
            touchDuration += Time.deltaTime;
            touch = Input.GetTouch(0 + leftright);
            target = Camera.main.ScreenToWorldPoint(touch.position);
            target.z = 0;
            dist = Vector3.Distance(player.transform.position, target);

            

            RaycastHit2D hit = Physics2D.Raycast(target, Vector2.zero);
            if (hit.collider != null && dist <= placeR && (hit.collider.gameObject.tag == "background" || hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "enemy" || hit.collider.gameObject.tag == "killsphere"))
            {
                /*if (tapperno == 2)
                {
                    portalout.transform.position = target;
                    animator.SetBool("shoot", true);
                    GameObject.FindWithTag("score").GetComponent<score>().clicks += 1;
                }
                else if (tapperno == 1)
                {
                    portalin.transform.position = target;    //places portal
                    animator.SetBool("shoot", true);         //plays shoot animation
                    GameObject.FindWithTag("score").GetComponent<score>().clicks += 1;
                }*/
                if (touch.phase == TouchPhase.Ended && touchDuration < 0.2f) //making sure it only check the touch once && it was a short touch/tap and not a dragging.
                {
                    StartCoroutine("singleOrDouble");
                }
                else
                {
                    touchDuration = 0.0f;
                }
            }
        }

            if (timer > 1)    //after one second, stop shoot animation
            {
                animator.SetBool("shoot",false);
            }

        GameObject.FindWithTag("score").GetComponent<score>().time += Time.deltaTime;
    }
}

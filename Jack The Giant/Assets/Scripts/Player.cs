using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public float speed = 8f, maxVelocity = 4f;

    [SerializeField]
    private Rigidbody2D myBody;
    private Animator anim;

    //Awake method is a function that inherited from MonoBehaviour
    //Read more about Awake and Start method here : https://stackoverflow.com/questions/34652036/awake-and-start#:~:text=The%20Awake%20function%20is%20called,object's%20Start%20function%20is%20called.&text=I%20would%20say%20that%20Awake,something%20before%20a%20game%20starts.
    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start(){
        
    }

    // Update is called once per frame
    void FixedUpdate(){
        PlayerMove();
    }

    void PlayerMove() {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x); //get velocity of x line (Horizontal)
        float input = Input.GetAxisRaw("Horizontal"); //get or capture an input from horizontal or x axis when user press left or right controll
        //Note : when user press left it'll return negative number when user press right it'll return positive number -1 0 1
        if (input > 0)
        { //it means positive (right)
            if (vel < maxVelocity)
            {
                forceX = speed;
                anim.SetBool("Walk", true);
            }
        }
        else if (input < 0)
        { //it means negative (left)
            if (vel < maxVelocity)
            {
                forceX = -speed;
                anim.SetBool("Walk", true);
            }
        }
        else { //if player don't move
            anim.SetBool("Walk", false);
        }
        myBody.AddForce(new Vector2(forceX, 0)); //set the position or move the object based on the x
    }
}
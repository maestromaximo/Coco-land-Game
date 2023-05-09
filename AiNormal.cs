using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiNormal : MonoBehaviour
{


    public GameObject[] pillarsArray;
    bool isTouchingPillar = false;
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public float timeF = 0.05f;
    public int timeCounter = 30;
    float horizontalMove = 0f;

    public Transform topStair, bottomStair;

    public bool thereIsBone = false;

    public Animator animator;

    public Rigidbody2D rigidbody;

    float playerSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWandering());

        
    }

    // Update is called once per frame
    void Update()
    {
        playerSpeed = rigidbody.velocity.magnitude;
        //Debug.Log(playerSpeed);
        animator.SetFloat("Speed", playerSpeed);
    }


    void OnCollisionEnter(Collider other)
    {
       
    }




    IEnumerator StartWandering()
    {
        // Select a new destination and start wandering towards it
        // ...
        bool isOn = true;
        int counter = 0;
        float randomN = Random.Range(-1, 1);
        float delim = 0.5f;


        if (gameObject.transform.position.x < topStair.position.x)
        {
            randomN = Random.Range(-0.5f, 1);
        }

        if (Mathf.Abs(randomN) < delim){
            randomN = Mathf.Sign(randomN) * delim;
        }//delim

        

        float randomVelocity = randomN * runSpeed;
        while (isOn) { 

            controller.Move(randomVelocity * Time.fixedDeltaTime, false, false);
            yield return new WaitForSeconds(timeF);

            if (counter >= timeCounter)
            {
                isOn = false;
            }
            counter += 1;
        }//end of while on

        if(isInsideStairs())
        {
            
            rigidbody.gravityScale = 0;
            
        }
        if (!isInsideStairs())
        {
            rigidbody.gravityScale = 1;
        }

        //wait period
        int willWaitInt = Random.Range(1, 5);

        if(willWaitInt == 3)
        {
            yield return new WaitForSeconds(2f);
        }


        //wait period

        // Wait for a certain amount of time before starting the wandering behavior again
        // Replace 5.0f with the desired waiting time

        // Start the wandering behavior again
        yield return new WaitForSeconds(0.7f);

        StartCoroutine(StartWandering());
    }

    public void clickedBoneAI()
    {
        thereIsBone = !thereIsBone;

        if (thereIsBone)
        {
            StopAllCoroutines();
            Debug.Log("clik1");
        }
        else
        {
            StartCoroutine(StartWandering());
            Debug.Log("clik2");
        }
    }
    public bool isInsideStairs()
    {

        if (gameObject.transform.position.x < bottomStair.position.x && gameObject.transform.position.x > topStair.position.x && gameObject.transform.position.y > bottomStair.position.y && gameObject.transform.position.y < topStair.position.y)
        {
            return true;

        }
        else
        {
            return false;
        }
        
    }


}//AINormal

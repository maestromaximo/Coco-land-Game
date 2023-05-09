using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonClickEvents : MonoBehaviour
{
    public GameObject bone;
    bool isBoneSpawned = false;
    public Transform randomPos;
    GameObject newBone;
    float directionS = 0;
    //public float latency = 0.1f;
    public GameObject doggy;
    public CharacterController2D controller;
    public float runSpeed = 40f;

    public float radius = 0.5f;
    //public Transform objectToMove;
    public void generateRandomBone()
    {

        if (!isBoneSpawned)
        {
            randomPos.position = new Vector3(Random.Range(-8f, 8f), 3f, 0f);
            newBone = Instantiate(bone, randomPos.position, Quaternion.identity);
            isBoneSpawned = true;

            StartCoroutine(SearchBone());
        }
        else
        {
            Destroy(newBone);
            isBoneSpawned = false;
            StopCoroutine(SearchBone());
        }


    }

    IEnumerator SearchBone()
    {

        while (true)
        {
            Debug.Log("Working");
            while (Mathf.Abs(doggy.transform.position.x - newBone.transform.position.x) > radius)
            {
                Debug.Log(Mathf.Abs(doggy.transform.position.x - newBone.transform.position.x));

                if ((doggy.transform.position.x - newBone.transform.position.x) > 0)
                {
                    directionS = -1;
                }
                else
                {
                    directionS = 1;
                }
                controller.Move(directionS*runSpeed* Time.fixedDeltaTime, false, false);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(0.05f);
        }

        
    }

}

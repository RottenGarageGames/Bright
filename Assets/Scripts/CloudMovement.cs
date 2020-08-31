using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    public float Speed;
    public GameObject CloudPrefab;
    public float ScaleFactor;
    public float CurrentTime;
    public float TimeBetweenChanges;
    public float randomNum;

    private void Start()
    {
        TimeBetweenChanges = Random.Range(0f, 3f);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Speed);

        CurrentTime += Time.deltaTime;

        if (CurrentTime > TimeBetweenChanges)
        {
            randomNum = Random.Range(0f, 3f);
            CurrentTime = 0f;


            switch ((int)randomNum)
            {
                case 0:
                    //Go Faster
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Speed);
                    break;
                case 1:
                    //Scale Down
                   // transform.localScale = new Vector3(transform.position.x - ScaleFactor, transform.position.y - ScaleFactor, transform.position.z - ScaleFactor);
                    break;
                case 2:
                    //Scale up
                  //  transform. = new Vector3(transform.position.x + ScaleFactor, transform.position.y + ScaleFactor, transform.position.z + ScaleFactor);
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                default:
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 30f;

     private bool isCoroutineExecuting = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Outch!");
    }

    IEnumerator OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Boost")
        {
            Debug.Log("Boost");
            moveSpeed = boostSpeed;
            yield return new WaitForSeconds(3.0f);
            moveSpeed = baseSpeed;
        }
        else if (other.tag == "Road")
        {
            Debug.Log("Road");
            moveSpeed = baseSpeed;
        }
        else if (other.tag == "Out Of Road")
        {
            Debug.Log("Out Of Road");
            moveSpeed = slowSpeed;
            yield return new WaitForSeconds(2.0f);
            moveSpeed = baseSpeed;
        }
    }

    // private void OnTriggerExit2D(Collider2D other) {
    //     if (other.tag == "Road")
    //     {
    //         moveSpeed = slowSpeed;
    //         Debug.Log("SLOW!");
    //     }
    // }

    IEnumerator refreshBaseSpeedAfterTime(float seconds)
    {
        if (isCoroutineExecuting)
         yield break;
        
             isCoroutineExecuting = true;

        yield return new WaitForSeconds(seconds) ;// Wait for one second
        moveSpeed = baseSpeed;
             isCoroutineExecuting = false;

    }
}

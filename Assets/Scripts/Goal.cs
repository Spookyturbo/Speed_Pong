using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    public UnityEvent goalEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Remove the ball and increase the score
        if(collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
            goalEvent.Invoke();
        }
    }
}

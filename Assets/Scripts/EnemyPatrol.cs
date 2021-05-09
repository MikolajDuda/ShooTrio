using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPatrol : MonoBehaviour
{
    //private Vector3 start;
    private AIDestinationSetter destinationSetter;
    [SerializeField] private Transform start; 
    [SerializeField] private Transform end; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        //start = transform.position;
        destinationSetter = GetComponent<AIDestinationSetter>();
     //   Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((transform.position.x - destinationSetter.target.position.x) <= 0.3f)
        {
            destinationSetter.target.position = destinationSetter.target.position == end.position ?  
                start.position 
                : end.position;
            
            /*
             * if target == player:
             *  debuglog("Kill player")
             *  Animacja ataku - podniesiony łeb
             *  destination.target = start
             */
        }
    }
}

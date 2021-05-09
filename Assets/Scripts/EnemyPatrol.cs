using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPatrol : MonoBehaviour
{
    //private Vector3 start;
    private Transform start;
    private Transform destinationSetterTarget;
    [SerializeField] private Transform end; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        start = transform;
        destinationSetterTarget = GetComponent<AIDestinationSetter>().target;
     //   Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((transform.position.x - destinationSetterTarget.position.x) <= 0.05f)
        {
            GetComponent<EnemyAI>().target = (destinationSetterTarget.position == end.position)
                ? start 
                : end;
            
            /*
             * if target == player:
             *  debuglog("Kill player")
             *  Animacja ataku - podniesiony łeb
             *  destination.target = start
             */
        }
    }
}

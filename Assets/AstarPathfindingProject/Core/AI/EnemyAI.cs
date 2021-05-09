using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEditor;

public class EnemyAI : MonoBehaviour
{

    public Transform target;

    public float speed = 40f;
    public float nextWaypointDistance = 3f;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    private Seeker seeker;
    private Rigidbody2D rb;
    private float floor;
    
    private Vector3 scale;
    
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        floor = rb.position.y;
        scale = transform.localScale;

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, new Vector3(target.position.x, floor, target.position.z), OnPathComplete);
        }
    }
    
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = (Vector2)path.vectorPath[currentWaypoint] - rb.position;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);
        
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // Flip img to the target 
        /*
        bool isSignTheSame = (force.x >= 0.01f || force.x <= -0.01f);
        transform.localScale = isSignTheSame ?  
            new Vector3(-scale.x, scale.y, scale.z) 
            : new Vector3(scale.x,scale.y, scale.z);
            */
        if (force.x >= 0.01f)
        {
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
        }
        else if (force.x <= -0.01f)
        {
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath AIPath;
    
    // Update is called once per frame
    void Update()
    {
        float horizontal = AIPath.desiredVelocity.x;
        Vector3 scale = transform.localScale;
        
        // Check if scale and horizontal have the same sign
        bool isSignTheSame = (scale.x >= 0 && horizontal >= 0 || scale.x <= 0 && horizontal <= 0);
        transform.localScale = isSignTheSame ?  
            new Vector3(-scale.x, scale.y, scale.z) 
            : new Vector3(scale.x,scale.y, scale.z);
        
    }
}

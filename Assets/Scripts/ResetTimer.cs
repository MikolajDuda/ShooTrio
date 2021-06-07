using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ResetTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Timer>().StartClock();
    }
}

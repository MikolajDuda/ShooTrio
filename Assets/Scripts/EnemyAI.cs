using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEditor;
using UnityEngine.Serialization;

public class EnemyAI : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;
    public float triggerSpeed = 200f;
    public float nextWaypointDistance = 3f;
    public float edgeToPatrol;
    public Transform ImgTransform;

    private Path _path;
    private int _currentWaypoint = 0;
    private bool _reachedEndOfPath = false;
    private Vector2 _previousForce = new Vector2(0,0);
    private Seeker _seeker;
    private Rigidbody2D _rb;
    
    private float _endX;             // Patrol positions
    private float _startX;
    private float _floor;
    private float _goalX;
    
    private Vector3 _scale;

    // Start is called before the first frame update
    void Start()
    {
        
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();
        var position = _rb.position;
        _startX = position.x;
        _endX = position.x + edgeToPatrol;
        _floor = position.y;
        _scale = ImgTransform.localScale;
        target = null;
        
        InvokeRepeating(nameof(UpdatePath), 0f, .5f);
    }

    private void UpdatePath()
    {
        // Patrol or trigger Player
        Invoke(target != null ? nameof(TriggerPlayer) : nameof(Stray), 0f);
    }
    
    private void TriggerPlayer()
    {
        if (!_seeker.IsDone()) return;
        var position = target.position;
        _seeker.StartPath(_rb.position, new Vector3(position.x, _floor, position.z), OnPathComplete);
    }

    private void Stray()
    {
        var position1 = _rb.position;

        if (Mathf.Abs(position1.x - _endX) < 2f)
        {
          //  StartCoroutine(waiter());
            _goalX = _startX;
          // Invoke("changeGoal", 2);
        }
        else if (Mathf.Abs(position1.x - _startX) < 2f)
        {
            //    StartCoroutine(waiter());
            _goalX = _endX;
            //    Invoke("changeGoal", 2);
        }
        
        _seeker.StartPath(position1, new Vector3(_goalX, _floor, 0),OnPathComplete);

    }

    private void changeGoal(float newGoal)
    {
        _goalX = newGoal;
    }
    
    private void OnPathComplete(Path p)
    {
        if (p.error) return;
        _path = p;
        _currentWaypoint = 0;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (_path == null)
        {
            return;
        }

        if (_currentWaypoint >= _path.vectorPath.Count)
        {
            _reachedEndOfPath = true;
            return;
        } 
        
        _reachedEndOfPath = false;

        Vector2 direction = (Vector2)_path.vectorPath[_currentWaypoint] - _rb.position;
        Vector2 force = direction * (speed * Time.deltaTime);

        _rb.AddForce(force);
        
        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            _currentWaypoint++;
        }

        if (ImgTransform != null)
        {
            // Flip img
            if (force.x >= 0.01f)
            {
                ImgTransform.localScale = new Vector3(-_scale.x, _scale.y, _scale.z);
            }
            else if (force.x < -0.01f)
            {
                ImgTransform.localScale = new Vector3(_scale.x, _scale.y, _scale.z);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class movement : MonoBehaviour
{
    private List<GameObject> targets;
    Seeker seeker;
    Rigidbody2D rb;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath;
    private int nextTarget = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject theCamera = GameObject.Find("Main Camera");
        Engine engine = theCamera.GetComponent<Engine>();
        targets = engine.enemies;

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnPathComplete(Path p) {
        Debug.Log("reached");
        if(!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null) {
            if(targets.Count > 0) {
                if(targets[nextTarget]) {
                    seeker.StartPath(rb.position, targets[nextTarget].GetComponent<Rigidbody2D>().position, OnPathComplete);
                } else {
                    nextTarget++;
                }
            }
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count) {
            reachedEndOfPath = true;
            if(nextTarget < targets.Count - 1) {
                nextTarget++;
                seeker.StartPath(rb.position, targets[nextTarget].GetComponent<Rigidbody2D>().position, OnPathComplete);
            }
            return;
        } else {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance) {
            currentWaypoint++;
        }
    }
}

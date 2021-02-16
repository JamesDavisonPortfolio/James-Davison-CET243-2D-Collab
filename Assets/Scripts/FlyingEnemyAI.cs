using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemyAI : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public Transform target;
    public AIPath aIPath;
    public float speed;
    public float stopWaypointDistance = 3f;
    public float sightRange;

    private Path path;
    private int currentWaypoint = 0;
    private float playerDistance;
    private Seeker seeker;
    private Rigidbody2D rb;
    private bool reachedEndOfPath = false;
    public bool playerSpotted = false;
    public bool playerInSight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckSight();
    }
    // Update is called once per frame
    void FixedUpdate()
    {


        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < stopWaypointDistance)
        {
            currentWaypoint++;
        }

    }

    void CheckSight()
    {
        RaycastHit2D hitObject;
        playerDistance = Vector2.Distance(transform.position, player.transform.position);
        hitObject = Physics2D.Linecast(transform.position, player.transform.position);

        if (hitObject.collider.tag == "Player"  && playerDistance <= sightRange)
        {
            playerInSight = true;

            if (!playerSpotted)
            {
                playerSpotted = true;
                InvokeRepeating("SetPath", 0f, 1f);
                InvokeRepeating("FireBullet", 0f, 2f);
            }
        }
        else
        {
            playerInSight = false;
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

    void SetPath()
    {
        if (!playerInSight)
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void FireBullet()
    {
        Instantiate(projectile, transform.position, projectile.transform.rotation);
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void DirectionFacing()
    {
        if (aIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (aIPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}

using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour{

    float speed = 35f;
    Vector2[] path;
    int targetIndex;

    bool pathToPlayer = true;

    public void Start()
    {
        //StartPathing(GameObject.FindGameObjectWithTag("Player").transform);
    }

    public void StartPathing(Transform target)
    {
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }

    public void OnPathFound(Vector2[] newPath, bool pathSuccessful)
    {
        pathToPlayer = pathSuccessful;
        if (pathSuccessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    public IEnumerator FollowPath()
    {
        Vector2 currentWaypoint = path[0];
        while (pathToPlayer)
        {
            if (transform.position.x == currentWaypoint.x && transform.position.y == currentWaypoint.y)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }

            transform.position = Vector2.MoveTowards(transform.position, currentWaypoint, speed*Time.deltaTime);
            //Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
            //rigidbody.velocity = -Vector2.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime).normalized * speed * Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one * 5);
                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
}

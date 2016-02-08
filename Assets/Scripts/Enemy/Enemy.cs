using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Unit))]
public class Enemy : MonoBehaviour {

    Unit unit;
    bool hasTarget;
    float refreshRate = 0.5f;
    Transform target;
    int time = 0;

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform)
        {
            hasTarget = true;
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Start()
    {
        unit = this.gameObject.GetComponent<Unit>();
        StartCoroutine(StartFollowPath());
    }

    public IEnumerator StartFollowPath()
    {
        while (hasTarget)
        {
            unit.StartPathing(target);
            yield return new WaitForSeconds(refreshRate); 
        }
    }
   
}

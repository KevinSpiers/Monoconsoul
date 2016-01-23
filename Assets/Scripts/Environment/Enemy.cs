using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    Unit unit;
    bool hasTarget;
    float refreshRate = 0.5f;
    Transform target;

    void Awake()
    {
        unit = GetComponent<Unit>();
        if (GameObject.FindGameObjectWithTag("Player").transform)
        {
            hasTarget = true;
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Start()
    {
        StartCoroutine(updatePath());
    }

    IEnumerator updatePath()
    {
        while (hasTarget)
        {
            unit.StartPathing(target);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}

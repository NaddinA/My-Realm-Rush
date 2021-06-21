
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem hitBaseFX;
	void Start ()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
	}

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol..."); 
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        OnBaseHit();
    }
        void OnBaseHit()
        {
          var hitBase = Instantiate(hitBaseFX, transform.position, Quaternion.identity);
        hitBase.Play();
        Destroy(hitBase.gameObject, hitBase.main.duration);
        Destroy(gameObject);
        }
}

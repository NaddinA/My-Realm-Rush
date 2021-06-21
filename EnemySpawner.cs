using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] AudioClip enemySpawnSFX;
    int score;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnedEnemies.text = score.ToString();
	}
	
    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // forever
        {   score++;
             spawnedEnemies.text = score.ToString();
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(enemySpawnSFX);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        
    }
}

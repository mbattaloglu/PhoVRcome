using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourist : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Walk());
    }

    private IEnumerator Walk()
    {
        while (true)
        { 
            bool walk = Random.Range(0, 10) < 7;
            bool direction = Random.Range(0, 1) == 1; 
            animator.SetBool("Walk", walk);
            float time = Random.Range(3f, 5f);
            if(walk)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.forward * (direction ? 1 : -1) * 10, 1);
            }
            yield return new WaitForSeconds(time);
        }
    }
}

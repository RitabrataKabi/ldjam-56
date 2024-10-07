using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerChaseAI : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public Transform target;

    private void Start() {
        NotificationManager.Instance.AddListener(this, "PlayerChaseAI");
    }

    public void Chase()
    {
        animator.SetTrigger("Chase");
        StartCoroutine(ChasePlayer());
    }

    IEnumerator ChasePlayer() {

        while(true)
        {
            agent.SetDestination(target.position);
        yield return null;}
    }

    public void StopChase()
    {
        animator.SetTrigger("StopChase");
        StopCoroutine(ChasePlayer());
    }
}

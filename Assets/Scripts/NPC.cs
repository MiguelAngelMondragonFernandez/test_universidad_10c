using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{

    public Transform destination;

    private Transform player;

    private SphereCollider detectionVolume;
    private NavMeshAgent agent;

    private Collider[] detectedObjects = new Collider[10];


    public float detectionRadius = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        agent = GetComponent<NavMeshAgent>();
        while(true){
            var numberOfColliders = Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, detectedObjects);
            player = null; //Limpiando la referencia al player
            for(int i = 0; i < numberOfColliders; i++){
                var col = detectedObjects[i];
                if (!col.CompareTag("Player")) continue;
                player = col.transform;
                var vectorToPlayer = player.position - transform.position;
                var dot = Vector3.Dot(vectorToPlayer, transform.forward);
                if (dot < 0) continue; //Primer filtro
                agent.destination = player.position;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
/*
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            destination = player;
            detectionVolume.radius = 20f;
            agent.speed = 6f;
        }
        else
        {
            player = null;
            destination = null;
            detectionVolume.radius = 10f;
            agent.speed = 3.5f;
        }
    }
    */
}

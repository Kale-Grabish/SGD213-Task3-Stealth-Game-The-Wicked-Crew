using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;
public class SentryPatrol : MonoBehaviour
{
    NavMeshAgent Sentry;
    public Transform[] markers;
    int markersIndex;
    Vector3 target;
    public float timer = 0f;
    public float maxTime = 8f;

    private void Start()
    {
        Sentry = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            // If the sentry is on a marker, a timer begins and the sentry stops moving. Once the timer has reached maxTime
            // the sentry resumes movement and continues to the next marker in the index.
            timer += Time.deltaTime;
            if (timer <= maxTime) {
                Sentry.GetComponent<NavMeshAgent>().speed = 0f;
            }
            else
            {
                Sentry.GetComponent<NavMeshAgent>().speed = 3.5f;
                IterateMarkerIndex();
                UpdateDestination();
                timer = 0f;
            }
        }
    }

    void UpdateDestination()
    {
        // sets a new destination from the index
        target = markers[markersIndex].position;
        Sentry.SetDestination(target);
        

    }

    void IterateMarkerIndex()
    {
        // Adds to the index by 1. Resets to 0 once the end of the index has been reached.
        markersIndex++;
        if (markersIndex >= markers.Length)
        {
            markersIndex = 0;
        }
    }
}

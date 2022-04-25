using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Runner : MonoBehaviour
{
    [SerializeField] private float runAnimationSpeed = 1f;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PlayerAnimatorController animatorCtrl;

    public Vector3 destination
    {
        get { return agent.destination; }
        set
        {
            var pos = GetNavMeshSamplePoint(value);
            isNotReached = pos != agent.destination;
            agent.destination = pos;
        }
    }

    public RunEvent onReach = new RunEvent();

    public bool canSetDestination { get { return agent.isOnNavMesh && !agent.isStopped; } }

    public class RunEvent : UnityEvent { }

    private float initialAgentSpeed;
    private Transform mTrans;
    private bool isNotReached = true;

    void Awake()
    {
        OnValidate();
        mTrans = transform;
    }

    void OnValidate()
    {
        if (agent == null) {
            agent = GetComponent<NavMeshAgent>();
        }
        if (animatorCtrl == null) {
            animatorCtrl = GetComponentInChildren<PlayerAnimatorController>();
        }
    }

    void Start()
    {
        initialAgentSpeed = agent.speed;
    }

    public void StartAgent()
    {
        agent.isStopped = false;
    }

    public void StopAgent()
    {
        agent.isStopped = true;
    }

    void Update()
    {
        if (!agent.isOnNavMesh || agent.isStopped) {
            return;
        }

        var spd = agent.velocity.magnitude;
        var moving = agent.velocity.magnitude >= runAnimationSpeed;
        animatorCtrl.Run(moving);

        if (isNotReached && IsReached()) {
            onReach.Invoke();
            isNotReached = false;
        }
    }

    private bool IsReached()
    {
        return Vector3.Distance(mTrans.position, agent.destination) <= agent.stoppingDistance;
    }

    internal void SetSpeedScale(float scale)
    {
        agent.speed = scale * initialAgentSpeed;
    }

    private static Vector3 GetNavMeshSamplePoint(Vector3 pos)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(pos, out hit, 3.0f, 1 << 0)) {
            return hit.position;
        } else {
            return pos;
        }
    }
}

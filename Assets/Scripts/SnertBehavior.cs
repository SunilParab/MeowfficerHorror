using UnityEngine;
using UnityEngine.AI;

namespace Behaviors {

public class SnertBehavior : MonoBehaviour
{
    Transform target;
    [SerializeField]
    NavMeshAgent nav;
    [SerializeField]
    Animator anim;
    [SerializeField]
    float pacifyTime = 5;
    [SerializeField]
    bool friendly = false;
    public static SnertBehavior reference;

    void Awake() {
        reference = this;  
    }

    //Find camera
    void Start()
    {
        target = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!friendly) {
            nav.SetDestination(target.position);
        }
        anim.SetFloat("Velocity", nav.velocity.magnitude);
    }

    public void Pacify() {
        anim.SetBool("Friendly", true);
        friendly = true;
        nav.isStopped = true;
        Invoke("Anger",pacifyTime);
    }

    void Anger() {
        anim.SetBool("Friendly", false);
        friendly = false;
        nav.isStopped = false;
    }

}

}
using UnityEngine;

namespace Behaviors {

public class FaceCamera : MonoBehaviour
{
    Transform targetToLook;

    //Find camera
    void Start()
    {
        targetToLook = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetToLook);
        transform.rotation = Quaternion.LookRotation(-targetToLook.forward, Vector3.up);
        
    }
}

}
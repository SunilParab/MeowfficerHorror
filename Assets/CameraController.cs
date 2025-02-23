using UnityEngine;

namespace PlayerControls {

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float sensitivity = 5;
    float verticalRotation;

    // Update is called once per frame
    void Update()
    {
        verticalRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;

        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.localEulerAngles = new Vector3(verticalRotation, 0, 0);
    }
}

}
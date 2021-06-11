using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAnimatorController : MonoBehaviour
{
    public float speedMinimum;
    [Range(0,1)]
    public float smoothing = 0.3f;
    private Animator animator;
    private Vector3 prevPos;
    private VRRig vrRig;

    // Start is called before the first frame update
    void Start()
    {
        speedMinimum = 0.1f;
        animator = GetComponent<Animator>();
        vrRig = GetComponent<VRRig>();
        prevPos = vrRig.head.vrTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Compute the speed the headset is moving
        Vector3 headsetSpeed = (vrRig.head.vrTarget.position - prevPos) / Time.deltaTime;
        headsetSpeed.y = 0;

        // Local Speed
        Vector3 headsetLocalSpeed = transform.InverseTransformDirection(headsetSpeed);
        prevPos = vrRig.head.vrTarget.position;

        // Set animator values
        float prevDirectionX = animator.GetFloat("DirectionX");
        float prevDirectionY = animator.GetFloat("DirectionY");

        animator.SetBool("isMoving", headsetLocalSpeed.magnitude > speedMinimum);
        animator.SetFloat("DirectionX", Mathf.Lerp(prevDirectionX, Mathf.Clamp(headsetLocalSpeed.x, -1, 1), smoothing));
        animator.SetFloat("DirectionY", Mathf.Lerp(prevDirectionY, Mathf.Clamp(headsetLocalSpeed.z, -1, 1), smoothing));
    }
}

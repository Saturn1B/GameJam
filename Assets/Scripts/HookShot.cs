using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{
    public GameObject PlayerCamera;
    public Movements movements;

    State state;
    enum State {Normal,  Flying}

    public CharacterController characterController;

    public Vector3 HookShotPos;
    public float speedMultiplier;
    public float speedMin;
    public float speedMax;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            default:
            case State.Normal:
                movements.canMove = true;
                HookShotStart();
                break;
            case State.Flying:
                movements.canMove = false;
                HookShotMovement();
                break;
        }

    }

    void HookShotStart()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out RaycastHit hit))
            {
                //hit.point
                HookShotPos = hit.point;
                state = State.Flying;
            }
        }
    }
    
    void HookShotMovement()
    {

        Vector3 dir = (HookShotPos - transform.position);

        float hookSpeed = Mathf.Clamp(Vector3.Distance(transform.position, HookShotPos), speedMin, speedMax);

        characterController.Move(dir * hookSpeed * speedMultiplier * Time.deltaTime);
        Debug.Log("move");

        if (Vector3.Distance(transform.position, HookShotPos) < 2)
        {
            state = State.Normal;
            movements.velocityY = 0f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            state = State.Normal;
            movements.velocityY = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float momentumExtra = 0.75f;
            movements.momentum = dir * hookSpeed * momentumExtra;
            float jumpSpeed = 10f;
            movements.momentum += Vector3.up * jumpSpeed;
            state = State.Normal;
            movements.velocityY = 0f;
        }
    }
}

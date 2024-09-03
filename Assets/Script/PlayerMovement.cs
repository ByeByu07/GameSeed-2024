using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool isUseClickMouse;
    [SerializeField] private float moveSpeed = 10f;
    private NavMeshAgent agent;
    void Start()
    {
        if (isUseClickMouse)
        {
            agent = GetComponent<NavMeshAgent>();
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) & isUseClickMouse)
        {
            Vector3 destination = Utility.MouseToTerrainPosition();
            SetDestination(destination);
        }

        Vector2 moveInput = GameInput.Instance.GetMovementVectorNormalized();

        float moveX = moveInput.x;
        float moveY = moveInput.y;

        Vector3 moveDir = new Vector3(moveX, 0, moveY);

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);
    }

    public void SetDestination(Vector3 destination)
    {
        agent.destination = destination;
    }
}

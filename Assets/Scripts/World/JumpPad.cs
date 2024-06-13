using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10f; 
    public float pushForce = 5f;  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                Vector3 movementDirection = GetMovementDirection(controller);
                StartCoroutine(Jump(controller, movementDirection));
            }
        }
    }

    private Vector3 GetMovementDirection(CharacterController controller)
    {
        Vector3 movementDirection = Vector3.zero;
        if (controller.velocity.magnitude > 0)
        {
            movementDirection = controller.velocity.normalized;
        }
        return movementDirection;
    }

    private IEnumerator Jump(CharacterController controller, Vector3 movementDirection)
    {
        float initialTime = Time.time;
        float duration = 0.2f; 
        Vector3 jumpVelocity = new Vector3(movementDirection.x * pushForce, jumpForce, movementDirection.z * pushForce);

        while (Time.time < initialTime + duration)
        {
            controller.Move(jumpVelocity * Time.deltaTime);
            yield return null;
        }
    }
}

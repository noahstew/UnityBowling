using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        if(triggeredBody.CompareTag("Ball"))
        {
            Debug.Log("Trigger activated by: " + triggeredBody.name);

            Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();

            // Store the velocity magnitude before resetting it
            float velocityMagnitude = 13f;
            Debug.Log("Ball velocity before reset: " + velocityMagnitude);

            // Reset the velocity (both linear and angular)
            ballRigidBody.linearVelocity = Vector3.zero;
            ballRigidBody.angularVelocity = Vector3.zero;

            // Apply force in the forward direction of the gutter
            ballRigidBody.AddForce(transform.up * velocityMagnitude, ForceMode.VelocityChange);
            Debug.Log("Force applied to ball: " + (transform.forward * velocityMagnitude));
        }
    }
}

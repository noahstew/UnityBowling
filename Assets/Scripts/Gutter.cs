using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        Debug.Log("Trigger activated by: " + triggeredBody.name);

        // Get the Rigidbody of the object that entered the trigger
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();

        // If the object does not have a Rigidbody, return early
        if (ballRigidBody == null)
        {
            Debug.Log("No Rigidbody detected on " + triggeredBody.name);
            return;
        }

        // Store the velocity magnitude before resetting it
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;
        Debug.Log("Ball velocity before reset: " + velocityMagnitude);

        // Reset the velocity (both linear and angular)
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        // Apply force in the forward direction of the gutter
        ballRigidBody.AddForce(transform.up * velocityMagnitude, ForceMode.VelocityChange);
        Debug.Log("Force applied to ball: " + (transform.forward * velocityMagnitude));
    }
}

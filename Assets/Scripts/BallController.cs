using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform launchIndicator;

    private Rigidbody ballRB;
    private bool isBallLaunched;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>(); // Grabbing reference for rigidbody

        // Listener
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;

        ResetBall();
    }


    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;
        ballRB.isKinematic = false;
        transform.parent = null;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }

    public void ResetBall()
    {
        isBallLaunched = false;
        ballRB.isKinematic = true;
        ballRB.linearVelocity = Vector3.zero;      
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity; 
    }
}


using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private InputManager inputManager;

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

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;
        ballRB.isKinematic = false;
        transform.parent = null;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}

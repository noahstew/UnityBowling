using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;

    private Rigidbody ballRB;
    private bool isBallLaunched;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>(); // Grabbing reference for rigidbody

        // Listener
        inputManager.OnSpacePressed.AddListener(LaunchBall);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}

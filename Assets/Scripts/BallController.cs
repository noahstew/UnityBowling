using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform launchIndicator;
    [SerializeField] private Transform cameraTransform; // Assign the camera transform in the inspector

    private Rigidbody ballRB;
    private bool isBallLaunched;

    void Start()
    {
        ballRB = GetComponent<Rigidbody>();

        // Listener
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;

        ResetBall();
    }

    void Update()
    {
        if (!isBallLaunched)
        {
            // Align ball with camera rotation while it's still attached
            transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        }
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
        launchIndicator.gameObject.SetActive(true);
        isBallLaunched = false;
        ballRB.isKinematic = true;
        ballRB.linearVelocity = Vector3.zero;
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}

using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    //A reference to our ballController
    [SerializeField] private BallController ball;

    //A reference for our PinCollection prefab we made in Section 2.2
    [SerializeField] private GameObject pinCollection;

    //A reference for an empty GameObject which we'll
    //use to spawn our pin collection prefab
    [SerializeField] private Transform pinAnchor;

    ////A reference for our input manager
    [SerializeField] private InputManager inputManager;

    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;
    private void Start()
    {
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

    private void SetPins()
    {
        if (pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
        }

        pinObjects = Instantiate(pinCollection, pinAnchor.transform.position,Quaternion.identity, transform);

        fallTriggers = FindObjectsOfType<FallTrigger>();
        // Add event listeners to the pins
        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void HandleReset()
    {
        Debug.Log("HandleReset() called!");
        SetPins();
        ball.ResetBall();
    }
}

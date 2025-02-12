using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    //A reference to our ballController
    [SerializeField] private BallController ball;

    ////A reference for our input manager
    [SerializeField] private InputManager inputManager;

    private FallTrigger[] fallTriggers;
    private void Start()
    {
        inputManager.OnResetPressed.AddListener(HandleReset);

        fallTriggers = FindObjectsOfType<FallTrigger>();
        // Add event listeners to the pins
        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

private void HandleReset()
    {
        Debug.Log("HandleReset() called!");

        ball.ResetBall();

    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

[DefaultExecutionOrder(-1)]
// This class runs most of the game logic. It creates components that allow the coder to link behaviors and scripts to those components in Unity.
public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Paddle playerPaddle;
    [SerializeField] private Paddle computerPaddle;
    [SerializeField] private TMP_Text playerScoreText;
    [SerializeField] private TMP_Text computerScoreText;

    // This code adds Audio for the scoring sound.
    [Header("Audio")]
    public AudioClip scoreSound;         
    public float scoreVolume = 0.4f;
    private AudioSource audioSource;

    private int playerScore;
    private int computerScore;

    // Method instantiates the audio component but tells the program to not evoke it on load. Begins new game.
    private void Start()
    {
        // Setup audio source
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;

        NewGame();
    }

    // This code allows the player to press the R key to start a new game at any time, using the new Unity Input System, and it only triggers once per key press.
    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            NewGame();
        }
    }

    // Resets Scores and starts a new game. 
    public void NewGame()
    {
        SetPlayerScore(0);
        SetComputerScore(0);
        NewRound();
    }

    // After scoring this method resets everything to begin the round again.
    public void NewRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();

        CancelInvoke();
        Invoke(nameof(StartRound), 1f);
    }

    // This method adds more force and speed to the ball so that the difficulty increases with each round.
    private void StartRound()
    {
        ball.AddStartingForce();
    }

    // this method increases and displays the player score as well as evokes the score sound when a score is made. Then initiates a new round.
    public void OnPlayerScored()
    {
        SetPlayerScore(playerScore + 1);

        // Play scoring sound
        if (scoreSound != null)
            audioSource.PlayOneShot(scoreSound, scoreVolume);

        Debug.Log(playerScore);

        NewRound();
    }

    // this method increases and displays the computer score as well as evokes the score sound when a score is made. Then initiates a new round.
    public void OnComputerScored()
    {
        SetComputerScore(computerScore + 1);

        // Play scoring sound
        if (scoreSound != null)
            audioSource.PlayOneShot(scoreSound, scoreVolume);

        Debug.Log(computerScore);

        NewRound();
    }

    // Converts the integer player score to a string so that it can be displayed in the text component.
    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }

    // Converts the integer computer score to a string so that it can be displayed in the text component.
    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }

}
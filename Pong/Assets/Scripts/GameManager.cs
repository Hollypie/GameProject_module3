using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Paddle playerPaddle;
    [SerializeField] private Paddle computerPaddle;
    [SerializeField] private TMP_Text playerScoreText;
    [SerializeField] private TMP_Text computerScoreText;

    [Header("Audio")]
    public AudioClip scoreSound;         // Drag your scoring .wav here
    public float scoreVolume = 0.4f;
    private AudioSource audioSource;

    private int playerScore;
    private int computerScore;

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

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        SetPlayerScore(0);
        SetComputerScore(0);
        NewRound();
    }

    public void NewRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();

        CancelInvoke();
        Invoke(nameof(StartRound), 1f);
    }

    private void StartRound()
    {
        ball.AddStartingForce();
    }

    public void OnPlayerScored()
    {
        SetPlayerScore(playerScore + 1);

        // Play scoring sound
        if (scoreSound != null)
            audioSource.PlayOneShot(scoreSound, scoreVolume);

        Debug.Log(playerScore);

        NewRound();
    }

    public void OnComputerScored()
    {
        SetComputerScore(computerScore + 1);

        // Play scoring sound
        if (scoreSound != null)
            audioSource.PlayOneShot(scoreSound, scoreVolume);

        Debug.Log(computerScore);

        NewRound();
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }

    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }

}
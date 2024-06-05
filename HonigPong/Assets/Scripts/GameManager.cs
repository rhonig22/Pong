using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioClip _waitSound;
    [SerializeField] AudioClip _startSound;
    public static GameManager Instance;
    public int PlayerScore { get; private set; } = 0;
    public int ComputerScore { get; private set; } = 0;
    [SerializeField] GameObject _ball;
    [SerializeField] GameObject _computer;
    private float _waitTime = .4f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(StartBall());
    }

    public void PlayerPoint()
    {
        PlayerScore++;
        ResetPositions();
    }

    public void ComputerPoint()
    {
        ComputerScore++;
        ResetPositions();
    }

    private void ResetPositions()
    {
        _computer.transform.position = new Vector2(_computer.transform.position.x, 0);
        _ball.transform.position = Vector3.zero;
        StartCoroutine(StartBall());
    }

    private IEnumerator StartBall()
    {
        yield return new WaitForSeconds(_waitTime);
        SoundManager.Instance.PlaySound(_waitSound, transform.position);
        yield return new WaitForSeconds(_waitTime);
        SoundManager.Instance.PlaySound(_waitSound, transform.position);
        yield return new WaitForSeconds(_waitTime);
        SoundManager.Instance.PlaySound(_startSound, transform.position);
        _ball.GetComponent<BallController>().StartMoving();
    }
}

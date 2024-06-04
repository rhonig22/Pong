using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int PlayerScore { get; private set; } = 0;
    public int ComputerScore { get; private set; } = 0;
    [SerializeField] GameObject _ball;
    private float _waitTime = .5f;

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

    public void PlayerPoint()
    {
        PlayerScore++;
        _ball.transform.position = Vector3.zero;
        StartCoroutine(ResetBall());
    }

    public void ComputerPoint()
    {
        ComputerScore++;
        _ball.transform.position = Vector3.zero;
        StartCoroutine(ResetBall());
    }

    private IEnumerator ResetBall()
    {
        yield return new WaitForSeconds(_waitTime);
        _ball.GetComponent<BallController>().StartMoving();
    }
}

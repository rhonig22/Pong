using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UXManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _playerPoints;
    [SerializeField] TextMeshProUGUI _computerPoints;

    // Update is called once per frame
    void Update()
    {
        _playerPoints.text = GameManager.Instance.PlayerScore.ToString();
        _computerPoints.text = GameManager.Instance.ComputerScore.ToString();
    }
}

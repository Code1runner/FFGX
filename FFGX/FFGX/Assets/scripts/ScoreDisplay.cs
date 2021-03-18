using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public float coins = 0;
    public Transform player;
    public TextMeshProUGUI scoreText;
    
    
    void Update()
    {

        scoreText.text = (player.position.z+coins).ToString("0");
    }
}

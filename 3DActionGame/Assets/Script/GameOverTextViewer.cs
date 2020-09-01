using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverTextViewer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI m_gameOverText = null;

    private string m_gameOverString = "GameOver!";
    
    public void GameOverTextView()
    {
        m_gameOverText.text = m_gameOverString;
    }
}

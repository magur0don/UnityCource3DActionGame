using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPresenter : MonoBehaviour
{
    [SerializeField]
    GameOverTextViewer m_gameOverTextViewer = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        { 
            m_gameOverTextViewer.GameOverTextView();
        }
    }
}

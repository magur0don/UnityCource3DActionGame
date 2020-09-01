﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPresenter : MonoBehaviour
{
    [SerializeField]
    GameClearTextViewer m_gameClearTextViewer = null;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            m_gameClearTextViewer.ClearTextView();
        }
    }
}

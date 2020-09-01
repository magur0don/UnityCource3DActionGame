using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackJudge : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("UnityCource2020")) {
            return;
        }
    }
}

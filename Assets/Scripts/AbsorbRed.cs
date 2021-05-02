using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbRed : MonoBehaviour
{
    public Player player;
    private bool isIn = false;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Red"))
        {
            isIn = true;
            player.IsInsideRed(isIn, other.gameObject);
        }
        else
        {
            isIn = false;
            player.IsInsideRed(isIn, other.gameObject);
        }
    }
}

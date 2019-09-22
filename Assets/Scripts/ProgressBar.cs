using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    /// <summary>
    /// Handles progress bar
    /// </summary>

    #region Variables
    [SerializeField]
    private Slider progressBar;
    private float totalLength;
    [SerializeField]
    private Player player;
    #endregion

    private void Start()
    {
        totalLength = SetTotalLength(player);
    }

    /// <summary>
    /// Get the total length of the level
    /// </summary>
    private float SetTotalLength(Player player)
    {
        float result = 0f;
        for(int i = 1; i < player.positions.Count;i++)
        {
            result += Vector3.Distance(player.positions[i-1], player.positions[i]);
        }
        return result;
    }

    private float GetRemainingLength(Player player)
    {
        if(player.nextPositionId < player.positions.Count)
        {
            float result = Vector3.Distance(player.transform.position, player.positions[player.nextPositionId]);
            if (player.nextPositionId + 1 < player.positions.Count)
            {
                for (int i = player.nextPositionId + 1; i < player.positions.Count; i++)
                {
                    result += Vector3.Distance(player.positions[i - 1], player.positions[i]);
                }
            }
            return result;
        }
        else
        {
            return 0f;
        }
    }

    private void FixedUpdate()
    {
        progressBar.value = 1 - GetRemainingLength(player) / totalLength;
    }
}

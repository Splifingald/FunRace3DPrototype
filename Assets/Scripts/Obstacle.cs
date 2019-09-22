using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Approx;

public class Obstacle : MonoBehaviour
{
    /// <summary>
    /// This script handles obstable positions and rotations
    /// Positions and rotations are handled separateley
    /// </summary>

    #region Variables
    [SerializeField]
    private List<Vector3> positions = new List<Vector3>();
    [SerializeField]
    [Range(0.5f,20.0f)]
    private float speed = 5.0f;
    [SerializeField]
    private bool rotate = false;
    [SerializeField]
    private Vector3 rotationSpeed = new Vector3(1,0,0);
    private Vector3 initialRotation;
    [SerializeField]
    private bool scale;
    [SerializeField]
    private Vector3 initialScale = new Vector3(1,1,1);
    [SerializeField]
    private Vector3 finalScale = new Vector3(3,3,3);
    [SerializeField]
    [Range(0.5f, 100.0f)]
    private float scaleSpeed = 2.0f;

    private int currentTargetPosition = 0;
    private bool isScalingUp = true;
    #endregion

    private void Start()
    {
        //Check parameters issues
        if(transform.localScale != initialScale && scale)
        {
            transform.localScale = initialScale;
        }
        initialRotation = transform.eulerAngles;
        if(positions.Count > 0)
            transform.position = positions[0];
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
        Scale();
    }

    /// <summary>
    /// Moving the obstacle
    /// </summary>
    private void Move()
    {
        int posCount = positions.Count;
        if (posCount > 1)
        {
            if (currentTargetPosition > posCount - 1)
            {
                currentTargetPosition = 0;
            }
            if (Approximation.VectorsEqual(transform.position, positions[currentTargetPosition], 0.05f))
            {
                currentTargetPosition++;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, positions[currentTargetPosition], Time.fixedDeltaTime * speed);
            }
        }
    }

    /// <summary>
    /// Rotating the obstacle
    /// </summary>
    private void Rotate()
    {
        if (rotate)
        {
            initialRotation = initialRotation + rotationSpeed * Time.fixedDeltaTime;
            transform.eulerAngles = initialRotation;
        }
    }

    /// <summary>
    /// Scaling the obstacle
    /// </summary>
    private void Scale()
    {
        if (scale)
        {
            if(Approximation.VectorsEqual(transform.localScale, finalScale, 0.1f))
            {
                isScalingUp = false;
            }
            else if(Approximation.VectorsEqual(transform.localScale, initialScale, 0.1f))
            {
                isScalingUp = true;
            }

            if (isScalingUp)
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, finalScale, scaleSpeed * Time.fixedDeltaTime);
            }
            else
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, initialScale, scaleSpeed * Time.fixedDeltaTime);
            }
        }
    }
}

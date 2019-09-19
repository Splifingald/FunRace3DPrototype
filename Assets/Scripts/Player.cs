using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Approx;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    /// <summary>
    /// This script handles player movement, camera movement and player collision with obstacles
    /// </summary>

    #region Variables
    [SerializeField]
    private List<Vector3> positions = new List<Vector3>(); // First position is start pos, last is finish line
    [SerializeField]
    [Range(1.0f,10.0f)]
    private float speed = 3.0f;
    [SerializeField]
    [Range(5.0f,15.0f)]
    private float cameraSpeed = 7.5f;

    [SerializeField]
    private Transform cam;

    private Animator animator;

    [SerializeField]
    private string nextLevelName;

    private int nextPositionId = 1;
    //Number of elements in positions (so we don't have to calculate every time)
    private int posCount;
    #endregion
    
    private void Start()
    {
        transform.position = positions[0];
        cam.LookAt(transform);
        posCount = positions.Count;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(nextPositionId < posCount)
        {
            // Game in progress
            MovePlayerAndCamera();
        }
        else
        {
            //Finish Line, make player wave and move camera, then start next Level
            cam.position = transform.position + transform.up * 4.0f + transform.forward * 3.0f;
            cam.LookAt(transform.position);
            animator.Play("wave");
            StartCoroutine("GoToNextSceneAfter", 3.0f);
        }
        
    }

    /// <summary>
    /// Go to next scene after some time
    /// </summary>
    /// <param name="f"> time </param>
    /// <returns></returns>
    private IEnumerator GoToNextSceneAfter(float f)
    {
        yield return new WaitForSeconds(f);
        SceneManager.LoadScene(nextLevelName);
    }

    /// <summary>
    /// Collision with an obstacle
    /// </summary>
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            //TODO Animate "death"
            
            //Return to last checkPoint and reset camera
            transform.position = positions[nextPositionId -1];
            cam.position = transform.position + transform.up * 5.0f + transform.forward * -5.0f;
            cam.LookAt(transform.position);
        }
    }

    /// <summary>
    /// Player movement
    /// </summary>
    /// <param name="posCount"> number of positions there is still to go through</param>
    private void MovePlayerAndCamera()
    {
        if ((Input.touches.Length > 0 || Input.GetMouseButton(0)))
        {
            animator.SetBool("isWalking", true);
            if (Approximation.VectorsEqual(transform.position,positions[nextPositionId],0.05f))
            {
                nextPositionId++;
                if (nextPositionId < posCount)
                    transform.LookAt(positions[nextPositionId]);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, positions[nextPositionId], Time.fixedDeltaTime * speed); 
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        MoveCamera();
    }

    /// <summary>
    /// Camera movement
    /// </summary>
    private void MoveCamera()
    {
        cam.position = Vector3.MoveTowards(cam.position, transform.position + transform.up * 5.0f + transform.forward * -5.0f, Time.fixedDeltaTime * cameraSpeed);
        cam.LookAt(transform.position);
    }
}

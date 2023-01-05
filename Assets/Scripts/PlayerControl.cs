using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;

public class PlayerControl : MonoBehaviour
{
    public GameObject playerObject;

    public float distance;
    public float destination;
    public float speed;

    private const float splineLength = 1896;
    private const int noOfStepps = 50;
    private const float stepLenght = splineLength / noOfStepps;

    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = playerObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PseudoRoll()
    {
        StartCoroutine(MovePlayer(Random.Range(1, 7)));
    }

    IEnumerator MovePlayer(int steppsToMove)
    {
        playerAnim.SetFloat("Speed_f", 0.5f);
        destination = distance + steppsToMove * stepLenght;
        while (distance < destination)
        {
            distance += speed * Time.deltaTime;
            Vector3 tangent;
            playerObject.transform.position = GetComponent<BGCcMath>().CalcPositionAndTangentByDistance(distance, out tangent);
            playerObject.transform.rotation = Quaternion.LookRotation(tangent);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        playerAnim.SetFloat("Speed_f", 0.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Horse : MonoBehaviour
{
    private const string runParaname = "run";
    [SerializeField] private Animator horseAnim;
    [SerializeField] private Rigidbody horseRig;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float speed;
    [SerializeField] private Transform finish;
    [SerializeField] private float currentPoint;
    [SerializeField] private bool isfinished;
    public bool Isfinished { get => isfinished; set => isfinished = value; }

    private void Start()
    {
        speed = Random.Range(60, 75);
        currentPoint = transform.position.z;
        moveDirection *= speed;
    }
    public void StartRun()
    {
        horseRig.velocity = moveDirection;
        ChangeSpeed();
        horseAnim.SetBool(runParaname, true);
    }
    public void ChangeSpeed()
    {
        float distance = transform.position.z - currentPoint;
        if (!Isfinished)
        {
            if (distance >= 100f)
            {
                StartCoroutine(RandomSpeed());
                currentPoint = transform.position.z;
                moveDirection = new Vector3(0, 0, 1);
                moveDirection *= speed;
            }
        }
        else
            return;
    }
    private void OnTriggerEnter(Collider horse)
    {
        if (horse.CompareTag("Finish"))
        {
            Isfinished = true;
            StartCoroutine(SlowDown());
        }
    }
    private IEnumerator SlowDown()
    {
        while (speed > 0)
        {
            yield return new WaitForEndOfFrame();
            speed -= 10f * Time.deltaTime;
        }
        if (speed <= 0)
        {
            speed = 0f;
            horseRig.velocity = Vector3.zero;
            horseAnim.SetBool(runParaname, false);
        }
    }
    private IEnumerator RandomSpeed()
    {
         yield return new WaitForEndOfFrame();
         speed = Random.Range(85, 105);  
    }
    private void Update()
    {

    }
}
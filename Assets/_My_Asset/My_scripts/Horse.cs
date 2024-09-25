using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Horse : MonoBehaviour
{
    private const string runParaname = "run";
    [SerializeField] private AudioSource[] horseAudio;
    [SerializeField] private Animator horseAnim;
    [SerializeField] private Rigidbody horseRig;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float speed;
    [SerializeField] private Transform finish;
    [SerializeField] private float currentPoint;
    [SerializeField] private bool isfinished;

    public bool Isfinished { get => isfinished; set => isfinished = value; }
    public float Speed { get => speed; set => speed = value; }

    private void Start()
    {
        Speed = Random.Range(50, 60);
        currentPoint = transform.position.z;
    }
    public void StartRun()
    {
        moveDirection *= speed;
        horseRig.velocity = moveDirection;
        horseAnim.SetBool(runParaname, true);
    }
    public void ChangeSpeed()
    {
        float distance = transform.position.z - currentPoint;
        if (!Isfinished)
        {
            if (distance >= 100)
            {
                StartCoroutine(RandomSpeed());
                currentPoint = transform.position.z;
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
         Speed = Random.Range(50, 70);
    }
    private void Update()
    {
        
    }
}

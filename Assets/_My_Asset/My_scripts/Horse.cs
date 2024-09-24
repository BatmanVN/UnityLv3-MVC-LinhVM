using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Horse : MonoBehaviour
{
    private const string runParaname = "run";
    [SerializeField] private float speed;
    [SerializeField] private AudioSource[] horseAudio;
    [SerializeField] private Animator horseAnim;
    [SerializeField] private Rigidbody horseRig;
    [SerializeField] private Transform finish;
    [SerializeField] private float reachingRadius;

    private void Start()
    {
        speed = Random.Range(80, 85);
    }
    public void StartRun()
    {
        horseRig.velocity = Vector3.forward*speed;
        StartCoroutine(ChangeSpeed());
        horseAnim.SetBool(runParaname, true);
    }
    private IEnumerator ChangeSpeed()
    {
        yield return new WaitForSeconds(2f);
        speed = Random.Range(70 ,100);
    }
    private void Update()
    {
        StartRun();
    }
}

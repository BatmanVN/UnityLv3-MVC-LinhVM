using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HorseManager : MonoBehaviour
{
    [SerializeField] private List<Horse> horses;
    [SerializeField] private DPDistance distance;
    [SerializeField] private LeaderBoard[] leaderBoard;
    [SerializeField] private GameObject[] cameras;
    [SerializeField] private GameObject[] boards;
    [SerializeField] private GameObject vFx;
    [SerializeField] private float time;
    [SerializeField] private UnityEvent onDistance;
    [SerializeField] private int countFinish;
    private void Start()
    {
        StartCoroutine(DelayStart());
        countFinish = horses.Count;
    }
    private IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(time);
        foreach (Horse horse in horses)
        {
            horse.StartRun();
        }
    }
    private void SortLeaderBoard()
    {
        horses.Sort((horses1, horses2) => horses2.transform.position.z.CompareTo(horses1.transform.position.z));
        if (countFinish > 0)
        {
            leaderBoard[0].DisplayLeader(horses);
        }
        else
            return;
    }
    private void IndentifyFirstFinish()
    {
        foreach (Horse horse in horses)
        {
            if (horse.Isfinished)
            {
                cameras[0].SetActive(false);
                cameras[1].SetActive(true);
                vFx.SetActive(true);
                CheckFinish();
                Time.timeScale = 0.5f;
            }
            break;
        }
    }
    private IEnumerator StatusBoard()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i< boards.Length; i++)
        {
            boards[i].SetActive(i == 2);
            leaderBoard[1].DisplayLeader(horses);
        }
    }
    private void ChangeSpeed()
    {
        foreach (Horse horse in horses)
        {
            horse.ChangeSpeed();
        }
    }
    private void CheckFinish()
    {
        foreach (Horse horse in horses)
        {
            if (horse.Isfinished)
            {
                countFinish -= 1;
            }
            else
                return;
        }
        if (countFinish <= 0)
        {
           StartCoroutine(StatusBoard());
        }
    }
    private void Update()
    {
        ChangeSpeed();
        onDistance?.Invoke();
        SortLeaderBoard();
        IndentifyFirstFinish();
    }
}

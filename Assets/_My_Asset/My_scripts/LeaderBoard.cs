using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<Text> nameTexts;
    //[SerializeField] private List<Horse> horses;
    public void DisplayLeader(List<Horse> horses)
    {
        for (int i = 0; i < nameTexts.Count; i++)
        {
            nameTexts[i].text = horses[i].gameObject.name;
        }
    }
    private void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DPDistance : MonoBehaviour
{
    [SerializeField] private Transform firstPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private Text showText;
    [SerializeField] private float metterRemain;
    public void ShowDistance()
    {
        float distance = Vector3.Distance(firstPosition.position,endPosition.position);
        metterRemain -= (metterRemain - distance);
        showText.text = metterRemain.ToString();
    }
}

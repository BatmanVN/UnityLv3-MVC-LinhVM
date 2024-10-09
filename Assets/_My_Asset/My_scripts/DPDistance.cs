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

    public float MetterRemain { get => metterRemain; set => metterRemain = value; }

    public void ShowDistance()
    {
        float distance = Vector3.Distance(firstPosition.position,endPosition.position);
        MetterRemain -= (MetterRemain - distance);
        showText.text = MetterRemain.ToString();
    }
}

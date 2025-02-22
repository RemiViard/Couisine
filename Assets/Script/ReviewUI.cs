using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviewUI : MonoBehaviour
{
    //List<Review> 
    public bool activated;
    [SerializeField] List<Text> textsUI;
    [SerializeField] List<Image> imagesUI;
    [SerializeField] List<Text> nameUI;
    [SerializeField] List<Image> starsUI;

    [SerializeField] List<Sprite> faces;
    [SerializeField] List<string> texts;
    [SerializeField] List<int> starNbs;
    [SerializeField] List<string> names;
    public void Activate()
    {

    }
}

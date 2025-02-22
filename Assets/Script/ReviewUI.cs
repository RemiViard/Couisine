using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ReviewUI : MonoBehaviour
{
    //List<Review> 
    public bool activated;
    [SerializeField] GameObject review;
    [SerializeField] List<Text> textsUI;
    [SerializeField] List<Image> imagesUI;
    [SerializeField] List<Text> nameUI;
    [SerializeField] List<Image> starsUI;
    [SerializeField] List<Sprite> starSprite;

    [SerializeField] List<Sprite> faces;
    [SerializeField] List<string> texts;
    [SerializeField] List<int> starNbs;
    [SerializeField] List<string> names;

    List<int> selectedIds = new List<int>();
    public void Activate(int nbStar)
    {
        review.SetActive(true);
        activated = true;
        for (int i = 0; i < starNbs.Count; i++)
        {
            if (nbStar == 0)
            {
                if (starNbs[i] <= 2)
                    selectedIds.Add(i);
            }
            else if (nbStar == 1)
            {
                if (starNbs[i] >= 2 && starNbs[i] <= 4)
                    selectedIds.Add(i);
            }
            else if (nbStar == 2)
            {
                if (starNbs[i] >= 4)
                    selectedIds.Add(i);
            }
        }
        int removeId = Random.Range(0, selectedIds.Count);
        int id1 = selectedIds[removeId];
        selectedIds.RemoveAt(removeId);
        removeId = Random.Range(0, selectedIds.Count);
        int id2 = selectedIds[removeId];
        selectedIds.RemoveAt(removeId);
        removeId = Random.Range(0, selectedIds.Count);
        int id3 = selectedIds[removeId];
        SetUi(id1, id2, id3);
    }
    void SetUi(int id1, int id2, int id3)
    {
        List<int> ids = new List<int>();
        for (int i = 0; i < faces.Count; i++)
        {
            ids.Add(i);
        }
        int removeId = ids[Random.Range(0, ids.Count)];
        int face1 = ids[removeId];
        ids.RemoveAt(removeId);
        removeId = ids[Random.Range(0, ids.Count)];
        int face2 = ids[removeId];
        ids.RemoveAt(removeId);
        removeId = ids[Random.Range(0, ids.Count)];
        int face3 = ids[removeId];

        starsUI[0].sprite = starSprite[starNbs[id1] - 1];
        textsUI[0].text = texts[id1];
        imagesUI[0].sprite = faces[face1];
        nameUI[0].text = names[face1];

        starsUI[1].sprite = starSprite[starNbs[id2] - 1];
        textsUI[1].text = texts[id2];
        imagesUI[1].sprite = faces[face2];
        nameUI[1].text = names[face2];

        starsUI[2].sprite = starSprite[starNbs[id3] - 1];
        textsUI[2].text = texts[id3];
        imagesUI[2].sprite = faces[face3];
        nameUI[2].text = names[face3];
    }
    public void Desactivate()
    {
        review.SetActive(false);
    }
}

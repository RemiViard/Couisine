using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Stage4 stage4;
    [SerializeField] ReviewUI reviewUI;
    [SerializeField] GameObject scoreUI;
    [SerializeField] List<Sprite> starsSprites;
    [SerializeField] Image stars;
    [SerializeField] Text scoreText;
    int scoreEffect;
    [SerializeField] float effectSpeed;
    [SerializeField] int twoStarsScore;
    [SerializeField] int threeStarsScore;
    float time;
    bool effectActivated;
    public bool active;
    int nbstar;
    public void ShowScore()
    {
        scoreUI.SetActive(true);
        stars.gameObject.SetActive(false);
        time = 0;
        effectActivated = true;
        active = true;
        scoreEffect = 0;
    }
    void ShowStars()
    {
        nbstar = 0;
        if (ScoreManager.score >= threeStarsScore)
            nbstar = 2;
        else if (ScoreManager.score >= twoStarsScore)
            nbstar = 1;
        stars.sprite = starsSprites[nbstar];
        stars.gameObject.SetActive(true);
    }
    void SetScoreUI()
    {
        scoreText.text = scoreEffect.ToString();
    }
    private void Update()
    {
        if(effectActivated)
        {
            time += Time.deltaTime * effectSpeed;
            if (time >= 1)
            {
                time = 1;
                effectActivated = false;
                ShowStars();
            }
            scoreEffect = (int)Mathf.Lerp(0, ScoreManager.score, time);
            SetScoreUI();
        }
    }
    public void ReceaveInput()
    {
        if (effectActivated)
            time = 1;
        else if(!reviewUI.activated)
        {
            scoreUI.SetActive(false);
            reviewUI.Activate(nbstar);
        }
        else
        {
            reviewUI.Desactivate();
            active = false;
            stage4.ReturnMenu();
        }
    }
}

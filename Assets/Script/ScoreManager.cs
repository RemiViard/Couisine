using UnityEngine;

public class ScoreManager 
{
    public static int score;
    public static void AddScore(int value)
    {
        score += value;
    }
    public static void ResetScore()
    {
        score = 0;
    }
}

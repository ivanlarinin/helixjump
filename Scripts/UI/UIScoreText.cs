using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : BallEvents
{
    [SerializeField] private ScoresCollector scoresCollector;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text maxScoreText;

    protected override void Awake()
    {
        base.Awake();
        UpdateMaxScoreDisplay();
    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type != SegmentType.Trap)
        {
            scoreText.text = scoresCollector.Scores.ToString();
        }

        if (type == SegmentType.Finish)
        {
            UpdateMaxScoreDisplay();
        }
    }

    private void UpdateMaxScoreDisplay()
    {
        maxScoreText.text = "Max Score: " + scoresCollector.MaxScores.ToString();
    }
}
using UnityEngine;

public class ScoresCollector : BallEvents
{
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private int scores;

    private int maxScores;
    public int MaxScores => maxScores;

    public int Scores => scores;

    protected override void Awake()
    {
        base.Awake();
        LoadMaxScores();
    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Empty)
        {
            scores += levelProgress.CurrentLevel;
        }
        if (type == SegmentType.Finish)
        {
            maxScores = scores;
            SaveMaxScores();
        }
    }

    private void SaveMaxScores()
    {
        PlayerPrefs.SetInt("MaxScores", maxScores);
    }

    private void LoadMaxScores()
    {
        maxScores = PlayerPrefs.GetInt("MaxScores", 0);
    }
}

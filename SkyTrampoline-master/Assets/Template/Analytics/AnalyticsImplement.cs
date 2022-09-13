using UnityEngine;

public interface IAnalyticsImplement
{
    void Setup();
    void StartStage(int i);
}

public class MockAnalyticsImplement : IAnalyticsImplement
{
    public void Setup()
    {
    }

    public void StartStage(int i)
    {
        Debug.Log($"StartStage: {i}");
    }
}


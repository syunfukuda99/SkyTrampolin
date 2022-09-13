public class AnalyticsManager : SingletonMonoBehaviour<AnalyticsManager>
{
    public IAnalyticsImplement Implement = new MockAnalyticsImplement();

    protected override void Awake()
    {
        base.Awake();
        Implement.Setup();
    }
}

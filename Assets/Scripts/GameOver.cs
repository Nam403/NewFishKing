public class GameOver : NoticeUI
{
    public void Retry()
    {
        LoadUI();
        GameManager.Instance.SetUp(GameManager.Level);
    }
}

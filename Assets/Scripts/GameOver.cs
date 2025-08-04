public class GameOver : NoticeUI
{
    public void Retry()
    {
        LoadUI();
        GameManager.instance.SetUp(GameManager.Level);
    }
}

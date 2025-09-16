public class CompleteLevel : NoticeUI
{
    public void Continue()
    {
        LoadUI();
        GameManager.Instance.SetUp(GameManager.Level + 1);
    }
}
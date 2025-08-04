public class CompleteLevel : NoticeUI
{
    public void Continue()
    {
        LoadUI();
        GameManager.instance.SetUp(GameManager.Level + 1);
    }
}
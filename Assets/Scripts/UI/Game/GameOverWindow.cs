public class GameOverWindow : GameEndWindow
{
    protected override void LoadLevel()
    {
        GameStateMachine.Instance.LoadLevel();
    }
}

public class GameVictoryWindow : GameEndWindow
{
    protected override void LoadLevel()
    {
        GameStateMachine.Instance.GoNextLevel();
    }
}

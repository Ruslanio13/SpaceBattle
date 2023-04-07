using System;

[Serializable]
public class SaveData
{
    public int MaxReachedLevel { get; private set; }
    public void SetMaxReachedLevel(int newMax) => MaxReachedLevel = newMax;
}

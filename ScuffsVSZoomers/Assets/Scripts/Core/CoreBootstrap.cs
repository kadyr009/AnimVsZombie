using UnityEngine;

public class CoreBootstrap : MonoBehaviour
{
    public GameMode gameMode;

    private void Awake()
    {
        gameMode = new GameMode();
    }
}
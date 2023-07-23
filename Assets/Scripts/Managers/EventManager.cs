using System;
using UnityEngine;

public class EventManager
{
    #region Events for CanvasManager
    public static Action OpenEndpanel;
    public static Action CloseEndpanel;
    #endregion

    #region Events for SceneController
    public static Action RestartLevel;
    public static Action NextLevel;
    #endregion
}

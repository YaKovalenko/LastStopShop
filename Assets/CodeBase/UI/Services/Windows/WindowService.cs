namespace CodeBase.UI.Services
{
  public class WindowService : IWindowService
  {
    private IUIFactory _uiFactory;

    private WindowService(IUIFactory uiFactory)
    {
      uiFactory = _uiFactory;
    }

    public void Open(WindowId windowId)
    {
      switch (windowId)
      {
        case WindowId.MiniGame:
          _uiFactory.CreateMiniGame();
          break;
      }
    }
  }
}
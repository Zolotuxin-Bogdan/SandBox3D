using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI randomText;    
    public Image logo;
    public Button singleplayer;
    public Button multiplayer;
    public Button settings;
    public Button quit;

    // Start is called before the first frame update
    private void Start()
    {
        singleplayer.onClick.AddListener(SingleplayerCallback);
        multiplayer.onClick.AddListener(MultiplayerCallback);
        settings.onClick.AddListener(SettingsCallback);
        quit.onClick.AddListener(CloseGame);
        StartCoroutine(Animate());
    }

    protected int counter = 1;
    private IEnumerator Animate()
    {
        while (true)
        {
            if (randomText.fontSize <= 16)
            {
                counter = 1;
            }
            if (randomText.fontSize >= 32)
            {
                counter -= 1;
            }
            randomText.fontSize += counter;
            yield return new WaitForSecondsRealtime(.1f);
        }
    }

    private void CloseGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void SettingsCallback()
    {
        action.Invoke(MenuEvents.OnSettingsClicked);
    }

    private void MultiplayerCallback()
    {
        action.Invoke(MenuEvents.OnMultiplayerClicked);
    }

    private void SingleplayerCallback()
    {
        action.Invoke(MenuEvents.OnSinglePlayerClicked);
    }

    protected UnityAction<MenuEvents> action;
    public void AddListener(UnityAction<MenuEvents> action)
    {
        this.action = action;
    }
}

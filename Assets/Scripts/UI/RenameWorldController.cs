using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RenameWorldController : MonoBehaviour
{
    public Button renameWorld;
    public Button cancel;
    public TMP_InputField worldName;

    public string sourceWorldName;
    void Start()
    {
        renameWorld.onClick.AddListener(RenameWorldCallback);
        cancel.onClick.AddListener(CancelCallback);
        worldName.text = sourceWorldName;
    }

    private void CancelCallback()
    {
        action.Invoke();
    }

    private void RenameWorldCallback()
    {
        System.IO.File.Move(
            Application.dataPath + "\\saves\\" + sourceWorldName,
            Application.dataPath + "\\saves\\" + worldName.text
        );
    }

    protected UnityAction action;
    public void AddListener(UnityAction action)
    {
        this.action = action;
    }
}

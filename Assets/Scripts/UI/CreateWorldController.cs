using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CreateWorldController : MonoBehaviour
{
    public Button cancel;
    public Button create;
    public TextMeshProUGUI worldName;
    public TMP_InputField inputField;
    public bool isRecreate = false;
    public string parentWorldName;
    void Start()
    {
        cancel.onClick.AddListener(CancelCallback);
        create.onClick.AddListener(CreateCallback);
        inputField.onValueChanged.AddListener(InputFieldCallback);
        if (isRecreate)
        {
            inputField.text = $"Copy of {parentWorldName}";    
        }
    }

    private void CancelCallback()
    {
        action.Invoke(CreateWorldEvents.OnCancelClicked); 
    }

    private void CreateCallback()
    {
        action.Invoke(CreateWorldEvents.OnCreateClicked);
    }

    private void InputFieldCallback(string arg0)
    {
        if (arg0 == "")
            worldName.text = "Will be saved in: World";
        else
            worldName.text = "Will be saved in: " + arg0;
    }

    protected UnityAction<CreateWorldEvents> action;
    public void AddListener(UnityAction<CreateWorldEvents> action)
    {
        this.action = action;
    }
}
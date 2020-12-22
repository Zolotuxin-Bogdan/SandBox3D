using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class SingleplayerMenuController : MonoBehaviour
{
    public Button createNewWorld;
    public Button playSelectedWorld;
    public Button cancel;
    public Button reCreate;
    public Button rename;
    public Button delete;
    public ScrollRect worlds;
    public InputField searchField;
    
    int selectedWorld = -1;
    void Start()
    {
        createNewWorld.onClick.AddListener(CreateWorldCallback);
        playSelectedWorld.onClick.AddListener(RunWorldCallback);
        cancel.onClick.AddListener(CancelCallback);
        reCreate.onClick.AddListener(ReCreateCallback);
        rename.onClick.AddListener(RenameCallback);
        delete.onClick.AddListener(DeleteCallback);
    }

    private void DeleteCallback()
    {
        if (selectedWorld > -1)
            Destroy(worlds.content.GetChild(selectedWorld));
    }

    private void RenameCallback()
    {
        // var text = RenameWorld(worlds.content.GetChild(selectedWorld));
        throw new NotImplementedException();
    }

    private void ReCreateCallback()
    {
        // WorldLoader.Remove(worldname);
        // WorldGenerator.Generate();
        // action.Invoke(StartGame);
        throw new NotImplementedException();
    }

    private void CancelCallback()
    {
        action.Invoke();
        throw new NotImplementedException();
    }

    private void RunWorldCallback()
    {
        // WorldLoader.Load(worldname);
        // action.Invoke(StartGame);
        throw new NotImplementedException();
    }

    private void CreateWorldCallback()
    {
        // WorldGenerator.Generate();
        // action.Invoke(StartGame);
        throw new NotImplementedException();
    }

    protected UnityAction action;

    public void AddListener(UnityAction action)
    {
        this.action = action;
    }
}

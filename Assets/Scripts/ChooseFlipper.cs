using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChooseFlipper : MonoBehaviour
{
    public void StartGame() {
        string name =  EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(name);
    }
}

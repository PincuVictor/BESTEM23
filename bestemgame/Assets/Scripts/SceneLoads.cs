using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;
using Object = System.Object;

public class SceneLoads : MonoBehaviour
{
    public void OnClickPlay()
    {
        GameManager.managerInstance.ChangeScene("GameScene");
    }
    public void OnClickTournament()
    {
        GameManager.managerInstance.ChangeScene("TournamentScene");
    }
    public void OnClickMenu()
    {
        GameManager.managerInstance.ChangeScene("MenuScene");
    }
}

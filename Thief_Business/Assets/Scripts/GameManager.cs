using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int money;
    public Text moneyText;

    private void Start()
    {
        money=PlayerPrefs.GetInt("Money", 0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
        Restart();
    }
}

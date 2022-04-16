using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public int money;
    public Text moneyText;
    public Transform mainCamera;
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
    public void Done()
    {
        mainCamera.transform.DOLocalMove(new Vector3(0, 240, 50), 1.5f).OnComplete(() => { Invoke("Restart", 3f); });
        mainCamera.transform.DOLocalRotate(new Vector3(90, 0, 0), 1.5f);
    }
   
}

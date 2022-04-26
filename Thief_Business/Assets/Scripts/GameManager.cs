using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using PathCreation.Examples;

public class GameManager : MonoBehaviour
{
    
    public int money;
    public Text moneyText;
    public Transform mainCamera;
    [Header("START")]
    public Move move;
    public PathFollower businessManFollow;
    public PathFollower thiefFollow;
    public Transform startPanel;
    public Animator businessAnim;
    public Animator thiefAnim;
    public Transform map;
    [Header("MOVE POSITION")]
   
    public Transform businessMan;
    public Transform thief;
    public Transform Lholder;
    public Transform Rholder;

    [Header("MONEY CANVAS")]
    public RectTransform moneyCanvas;
    public Image moneyBack;
    private void Start()
    {
        money=PlayerPrefs.GetInt("Money", 0);
        businessMan.transform.position = Rholder.transform.GetChild(0).transform.position;
        thief.transform.position = Lholder.transform.GetChild(0).transform.position;
        move.transform.position = new Vector3(transform.position.x, transform.position.y, businessMan.transform.position.z);

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
        mainCamera.GetComponent<Camera>().farClipPlane = 1000;
        mainCamera.transform.parent = map;
        mainCamera.transform.DOLocalMove(new Vector3(0,0, -300), 2f).OnComplete(() => { Invoke("Restart", 1f); });
        mainCamera.transform.DOLocalRotate(new Vector3(0, 0, 0), 1.5f);
    }
    public void StartButton()
    {
        startPanel.gameObject.SetActive(false);
        
        thiefAnim.SetBool("Run",true);
        thiefAnim.applyRootMotion = true;
        businessAnim.SetBool("Run",true);
        businessAnim.applyRootMotion = true;
        mainCamera.transform.DOLocalMove(new Vector3(0, 15, -30), 2f);
        mainCamera.transform.DORotate(new Vector3(10, 0, 0), 2f);
        Invoke("RootMotion",2f);
    }
   void RootMotion()
    {
        businessAnim.applyRootMotion = false;
        thiefAnim.applyRootMotion = false;
        thiefFollow.enabled = true;
        businessManFollow.enabled = true;
        move.enabled = true;
    }
    public void MoneyCanvasPunch(bool isGood,float anim)
    {
        moneyCanvas.DOPunchScale(new Vector3(.20f, .20f, .20f), anim).OnComplete(()=> { if (isGood) MoneyBackColorGood(); else MoneyBackColorBad(); });
    }
    public void MoneyBackColorBad()
    {
        moneyBack.color = Color.red;
    }
    public void MoneyBackColorGood()
    {
        moneyBack.color = Color.green;
    }
}

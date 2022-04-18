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

    [Header("MOVE POSITION")]
   
    public Transform businessMan;
    public Transform thief;
    public Transform Lholder;
    public Transform Rholder;
    
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
        mainCamera.transform.DOLocalMove(new Vector3(0, 240, 50), 1.5f).OnComplete(() => { Invoke("Restart", 3f); });
        mainCamera.transform.DOLocalRotate(new Vector3(90, 0, 0), 1.5f);
    }
    public void StartButton()
    {
        startPanel.gameObject.SetActive(false);
        thiefFollow.enabled = true;
        businessManFollow.enabled = true;
        move.enabled = true;
        thiefAnim.SetBool("Run",true);
        businessAnim.SetBool("Run",true);
    }
   
}

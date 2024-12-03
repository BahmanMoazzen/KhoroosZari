using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class scrTitleScreenManager : MonoBehaviour
{
    public PlayableDirector _SecondTimeLine;
    public GameObject _NotConnectedUI;
    public GameObject _RemoveAdUI;
    public GameObject _RemoveAdCountinueUI;
    public GameObject _AdRemovedUI;
    public GameObject _RateUsUI;
    public Text _MessageBox;

    
    private void Start()
    {

        //_CheckInternet();
        
    }
    public void _CheckInternet()
    {
        if (a.IsConnectedtoInternet()) { 
            _NotConnectedUI.SetActive(true);
        }
        
        else
        {
            _NotConnectedUI.SetActive(false);
        }
    }
    
    public void _StartPlay()
    {

        if (PlayerPrefs.GetInt(a.b.IsAdRemovedTag, 0).Equals(0))
        {
            _RemoveAdUI.SetActive(true);
        }
        else
        {
            _RemoveAdUI.SetActive(false);
            _MessageBox.text = a.b.IsLoadingText;
            _GotoScene(a.b.ChapterNames[0]);
            
        }
    }
    public void _CountinuePlay()
    {
        if (PlayerPrefs.GetInt(a.b.IsAdRemovedTag, 0).Equals(0))
        {
            _RemoveAdCountinueUI.SetActive(true);
        }
        else
        {
            _RemoveAdCountinueUI.SetActive(false);
            
            _GotoScene(a.b.ChapterNames[0]);

        }
    }
    private IEnumerator _showMessage(string iMessage)
    {
        yield return 0;
        _MessageBox.text = iMessage;

    }
    public void _GotoScene(string iSceneName)
    {
        StartCoroutine(_GotoSceneCoroutine(iSceneName));
    }
    public IEnumerator _GotoSceneCoroutine(string iSceneName)
    {
        yield return 0;
        StartCoroutine( _showMessage(a.b.IsLoadingText));
        yield return new WaitForFixedUpdate();
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(iSceneName);
    }
    public void _ResumePlay()
    {
        _GotoScene(a.b.ChapterNames[PlayerPrefs.GetInt(a.b.SceneNumberTag,0)]);
    }
    public void _RemoveAd()
    {
        // RemoveAdCycle
        PlayerPrefs.SetInt(a.b.IsAdRemovedTag, 1);
        StartCoroutine(_showMessage(a.b.AdRemovedText));
        _AdRemovedUI.SetActive(true);
    }
    public void _StartSecondTimeLine()
    {
        _SecondTimeLine.Play();
    }
     public void _PlaySongs()
    {
        StartCoroutine(_showMessage(a.b.PlaySongText));
    }

    
}

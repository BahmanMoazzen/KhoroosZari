using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrAdWatcher : MonoBehaviour
{
    public int _ShowAdInterval = 120;
    public Text _MessageBox;

    private void Start()
    {
        StartCoroutine(_AdClock());
    }

    public IEnumerator _AdClock()
    {
        do
        {
            
            if (a.IsConnectedtoInternet())
            {
                _MessageBox.text = "Connected";

            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(a.b.TitleMenuSceneName);
            }
            yield return new WaitForSeconds(_ShowAdInterval);
            _MessageBox.text = "";
            yield return new WaitForSeconds(_ShowAdInterval);
        } while (true);
        
    }
}

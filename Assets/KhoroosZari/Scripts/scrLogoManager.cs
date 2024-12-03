using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrLogoManager : MonoBehaviour
{
    public void gotoNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("scnTitleMenu");
    }
}

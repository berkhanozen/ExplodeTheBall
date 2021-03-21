using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    public void Load(int index)
    {
        SceneManager.LoadScene(index);
    }
}

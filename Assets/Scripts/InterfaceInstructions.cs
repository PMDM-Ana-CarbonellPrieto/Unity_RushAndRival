using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceInstructions : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

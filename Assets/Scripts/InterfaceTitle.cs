using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceTitle : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level1Scene");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("InstructionScene");
    }
}

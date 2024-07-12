using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    public void goToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}

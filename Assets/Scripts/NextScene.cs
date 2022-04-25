using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    [SerializeField] private Button nextSceneBtn;

    private void Awake()
    {
        nextSceneBtn.onClick.AddListener(ChangeToUIScene);
    }

    private void ChangeToUIScene()
    {
        SceneManager.LoadScene("UIScene");
    }
}

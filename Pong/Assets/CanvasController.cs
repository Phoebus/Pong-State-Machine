using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private GameManager gameManager = null;

    private Button playButton = null;
    private Button quitButton = null;

    private void Awake()
    {
        Button[] list = GetComponentsInChildren<Button>();

        for(int i = 0; i < list.Length; i++)
        {
            if (list[i].name == "PlayButton")
            {
                playButton = list[i];
            } else if (list[i].name == "QuitButton")
            {
                quitButton = list[i];
            }
        }
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        playButton.onClick.AddListener(gameManager.PlayButtonClick);
        quitButton.onClick.AddListener(gameManager.QuitApp);
    }
}

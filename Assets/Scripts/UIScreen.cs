using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIScreen : MonoBehaviour
{
    public static UIScreen Instance;
    private Movement movement;
    public GameObject canv;

    private void Start()
    {
        movement = GetComponent<Movement>();
    }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void gameover()
    {
        canv.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

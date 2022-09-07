using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUI : MonoBehaviour
{
    public GameObject menu;
    public GameObject win;
    public GameObject lose;
    public playerStats player;

    // Start is called before the first frame update
    void Awake()
    {
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        player.forwardVelocity = 0;
        win.SetActive(false);
        lose.SetActive(false);
    }

    public void OnStartButtonPressed()
    {
        Debug.Log("ğ");
        Camera.main.GetComponent<CameraFollow>().enabled = true;
        player.forwardVelocity = 3;
        menu.SetActive(false);
    }

    public void OnBankButtonPressed()
    {
        player.dept -= 10;
    }

    public void OnHorButtonPressed()
    {
        player.horizontalVelocity = 4.5f;
    }

    public void OnLuckButtonPressed()
    {
        playerStats.chance = 25;
    }

    public void OnContinuePressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnRestartPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

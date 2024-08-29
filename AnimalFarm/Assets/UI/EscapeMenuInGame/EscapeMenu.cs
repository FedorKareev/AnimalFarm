using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _menuPanel;

    private bool _isOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isOpen)
            {
                OnPanel();
            }
            else
            {
                OffPanel();
            }
        }
    }
    public void ContinueButton()
    {
        OffPanel();
    }
    public void ExitToMainMenuButton()
    {
        OffPanel();
        SceneManager.LoadScene(0);
    }
    private void OnPanel()
    {
        Time.timeScale = 0f;
        _menuPanel.SetActive(true);
        _isOpen = true;
    }
    private void OffPanel()
    {
        Time.timeScale = 1f;
        _menuPanel.SetActive(false);
        _isOpen = false;
    }
}

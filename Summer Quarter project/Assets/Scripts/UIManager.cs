using UnityEngine;
using TMPro;
using System;
public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance {get; private set;}

    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject gameOverPanle;
    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        ToggleGameOverUI(false);
    }

    public void UpdateLives(int lives)
    {
        livesText.text = $"Live: {lives}";
    }
    public void ToggleGameOverUI(bool flag)
    {
        gameOverPanle.SetActive(flag);
    }

}

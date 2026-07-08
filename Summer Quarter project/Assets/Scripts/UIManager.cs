using UnityEngine;
using TMPro;
using System;
public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance {get; private set;}

    [SerializeField] private TextMeshProUGUI livesText;

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
    }

    public void UpdateLives(int lives)
    {
        livesText.text = $"Live: {lives}";
    }
}

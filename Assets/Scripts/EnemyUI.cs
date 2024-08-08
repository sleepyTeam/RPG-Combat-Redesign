using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    public HealthBar healthBar;
    public TextMeshProUGUI enemyName;
    public PlayerController playerController;
    public GameObject selectionIndicator;
    public EnemyBehaviour selectedEnemy;

    private void Start()
    {
        selectionIndicator = playerController.selectionIndicator;
    }
    private void Update()
    {
        selectedEnemy = playerController.SelectedEnemy;
        enemyName.text = selectedEnemy.EnemyStats.EnemyName;
        selectionIndicator.transform.position = selectedEnemy.transform.position;
        
    }
            

}

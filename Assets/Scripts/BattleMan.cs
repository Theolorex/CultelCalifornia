using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMan : MonoBehaviour
{
    
    public Combatant tempEnemy;
    public Combatant player;
    bool playerTurn = false;
    Combatant currentEnemy;
    float distance = 1f;
    float duration = 0.2f;
    public Camera battleCam;
    public Camera winCam;
    public Camera loseCam;

    void BattleStart(Combatant enemy, bool playerStarts)
    {
        currentEnemy = enemy;
        if (playerStarts)
        {
            playerTurn = true;

        }
    }

    void Update()
    {
        if (playerTurn && Input.GetKeyDown(KeyCode.X))
        {
            player.attack.doAttack(currentEnemy);
            playerTurn = false;
        }

        if (!playerTurn)
        {
            StartCoroutine(MoveEnemyDownAndBack());
            playerTurn = true;
        }

    if (player.health <= 0 || currentEnemy.health <= 0)
    {
        if(player.health <= 0)
        {
            Debug.Log("Got");
            battleCam.enabled = false;
            loseCam.enabled = true;
        }
        else
        {
                Debug.Log("Got");
            battleCam.enabled = false;
            winCam.enabled = true;
        }
        StopAllCoroutines();
        enabled = false; 
        Debug.Log("Battle ended!");
        return;
    }
    }

    void Start()
    {
        BattleStart(tempEnemy, true);
    }

    void camChange()
    {

    }

    public IEnumerator MoveEnemyDownAndBack()
    {
        Vector3 originalPosition = currentEnemy.transform.position;
        Vector3 targetPosition = originalPosition + new Vector3(0, -distance, 0);
        float elapsed = 0f;

        yield return new WaitForSeconds(0.5f);
        while (elapsed < duration)
        {
            currentEnemy.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        currentEnemy.transform.position = targetPosition;


        elapsed = 0f;
        while (elapsed < duration)
        {
            currentEnemy.transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        currentEnemy.transform.position = originalPosition;
        currentEnemy.attack.doAttack(player);
    }

    
}

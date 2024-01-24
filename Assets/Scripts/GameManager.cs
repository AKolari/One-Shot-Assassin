using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GamePhase {
    Prep,
    Aim,
    Fire,
    Aftermath

}



public class GameManager : Singleton<GameManager>
{

    public int []EnemyCounts;
    private GamePhase currentPhase;
    private int currentEnemyCount;
    private int staringCash=1000;
    private bool canAdvance = false;
    public int currentCash = 1000;
    // Start is called before the first frame update
    void Start()
    {
        currentPhase = GamePhase.Prep;
        currentEnemyCount = EnemyCounts[0];
        currentCash = 1000;
        staringCash = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            restartLevel();
        }

        if(currentPhase == GamePhase.Prep)
        {
            if(Input.GetKeyDown(KeyCode.F)){
                currentPhase++;
            }
        }
        else if (currentPhase == GamePhase.Aim)
        {
            if (Input.GetKeyDown(KeyCode.F)){
                currentPhase--;
            }
        }
        else if(currentPhase == GamePhase.Aftermath) {
            if (Input.GetKeyDown(KeyCode.F) &&canAdvance) { 
                nextLevel();
            }
            else if(Input.GetKeyDown (KeyCode.E))
            {
                restartLevel();
            }
        }
       
    }


    void nextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        currentPhase = GamePhase.Prep;
        staringCash = currentCash;
        currentEnemyCount = EnemyCounts[nextScene];
        SceneManager.LoadScene(nextScene);
    }


    private void restartLevel()
    {
        currentCash = staringCash;
        currentPhase = GamePhase.Prep;
        currentEnemyCount = EnemyCounts[SceneManager.GetActiveScene().buildIndex];
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 

    }

   
    static public void ADVANCE_PHASE()
    {
        Instance.currentPhase++;
    }




    static public GamePhase CURRENT_PHASE()
    {
        return Instance.currentPhase;
    }


    static public void CRATE_DESTROYED()
    {
        Instance.currentCash += 250;
    }


    static public void ENEMY_KILLED()
    {
        Instance.currentCash += 500;
        Instance.currentEnemyCount--;
        if( Instance.currentEnemyCount == 0 )
        {
            Instance.canAdvance = true;

        }
    }


}

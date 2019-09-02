using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    private float[] respawnTime = null;
    [SerializeField]
    private float[] respawnRangeTime = null;
    [SerializeField]
    private float[] changeWaveTime = null;

    private int waveNum = 0;

    private List<EnemyCreater> enemyCreaters = new List<EnemyCreater>();
    private bool setEnemyCreater = true;
    private GameObject[] enemys = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changeWaveTime.Length == waveNum)
        {
            if (enemys == null)
            {
                // 現在のScene名を取得する
                Scene loadScene = SceneManager.GetActiveScene();
                // Sceneの読み直し
                SceneManager.LoadScene(loadScene.name);
            }
            bool a = true;
            foreach (GameObject enemy in enemys)
            {
                if (enemy != null)
                {
                    a = false;
                }
            }
            if (a)
            {
                // 現在のScene名を取得する
                Scene loadScene = SceneManager.GetActiveScene();
                // Sceneの読み直し
                SceneManager.LoadScene(loadScene.name);
            }
        }
        else
        {
            changeWaveTime[waveNum] -= Time.deltaTime;
            if (setEnemyCreater)
            {
                if (enemys == null)
                {
                    SetEnemyCreater();
                }
                else
                {
                    bool a = true;
                    foreach (GameObject enemy in enemys)
                    {
                        if (enemy != null)
                        {
                            a = false;
                        }
                    }
                    if (a)
                    {
                        SetEnemyCreater();
                        enemys = null;
                    }
                }
            }
            else if (changeWaveTime[waveNum] <= 0.0f)
            {
                //waveNum++;
                setEnemyCreater = true;
                enemys = null;
                enemys = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (EnemyCreater enemy in enemyCreaters)
                {
                    enemy.SetCreating(false);
                }
                //Waveがなくなったら
            }
        }
    }
    void SetEnemyCreater()
    {
        if (changeWaveTime[waveNum] <= 0.0f)
        {
            waveNum++;
        }
        if(changeWaveTime.Length == waveNum)
        {
            return;
        }
        setEnemyCreater = false;
        GameObject[] createrObject = GameObject.FindGameObjectsWithTag("EnemyCreater");
        foreach (GameObject gameObject in createrObject)
        {
            EnemyCreater enemyCreater = gameObject.GetComponent<EnemyCreater>();
            enemyCreaters.Add(enemyCreater);
        }
        foreach (EnemyCreater enemy in enemyCreaters)
        {
            enemy.SetRespawnTime(respawnTime[waveNum]);
            enemy.SetRenpawnTimeRange(respawnRangeTime[waveNum]);
            enemy.SetCreating(true);
        }
    }

}

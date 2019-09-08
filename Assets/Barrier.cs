using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField]
    private int BarrierHP = 5;

    [SerializeField]
    private GameObject GameEndUI = null;

    [SerializeField]
    private GameObject effect = null;

    private AudioSource audioSource;

    private bool enemyDestroy;
    private List<EnemyCreater> enemyCreaters = new List<EnemyCreater>();

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        enemyDestroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BarrierHP <= 0)
        {
            Instantiate(GameEndUI, this.transform);
            if (!enemyDestroy)
            {
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (var gameObject in gameObjects)
                {
                    Enemy enemy = gameObject.transform.parent.GetChild(0).GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.GameEnd();
                    }
                    else
                    {
                        BellEnemy bellEnemy = gameObject.transform.parent.GetChild(0).GetComponent<BellEnemy>();
                        bellEnemy.GAmeEnd();
                    }
                }
                GameObject[] createrObject = GameObject.FindGameObjectsWithTag("EnemyCreater");
                foreach (GameObject gameObject in createrObject)
                {
                    EnemyCreater enemyCreater = gameObject.GetComponent<EnemyCreater>();
                    enemyCreaters.Add(enemyCreater);
                }
                foreach (EnemyCreater enemy in enemyCreaters)
                {
                    enemy.SetCreating(false);
                }
                GameObject.Find("WaveManager").GetComponent<WaveManager>().GameEnd();
                enemyDestroy = true;
            }
        }
    }

    public void AttackedEnemy()
    {
        Instantiate(effect, this.transform);
        BarrierHP--;
        audioSource.Play();
    }
}

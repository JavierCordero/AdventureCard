using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentLevel = 0;
    private List<GameObject> Fences;

    private int numEnemies = 0;
    private int totalCreatedEnemies = 0;
    private int enemiesLeftToCompleteLevel = 0;
    public int maxSceneEnemies = 30;
    private int currentSceneEnemies = 0;

    public GameObject[] enemiesSP;
    public GameObject[] Enemies;

    [HideInInspector]
    public int numberOfWood = 0;
    public int maxNumberOfWood = 3;

    public UnityEngine.UI.Text numberOfWoodText;

    public bool addWood()
    {
        if (numberOfWood + 1 <= maxNumberOfWood)
        {
            numberOfWood++;
            UpdateCanvas();
            return true;
        }

        else return false;
    }

    public void destroyWood()
    {
        numberOfWood--;
        UpdateCanvas();
    }

    public void AddFence(GameObject g)
    {
        Fences.Add(g);
    }

    // Start is called before the first frame update
    void Awake()
    {
        Fences = new List<GameObject>();

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Fence"))
            Fences.Add(g);
    }

    private void Start()
    {
        NextLevel();
    }

    public void UpdateCanvas()
    {
        numberOfWoodText.text = "x" + numberOfWood.ToString();
    }

    private void NextLevel()
    {
        CancelInvoke();

        FindObjectOfType<WoodBehaviour>().restoreWood();

        currentLevel++;
        numEnemies = currentLevel + (int)Random.Range(0, currentLevel / 2);
        enemiesLeftToCompleteLevel = numEnemies;
        totalCreatedEnemies = 0;
        for (int i = 0; i < Random.Range(1, numEnemies); i++)
            createEnemies();

        //dep();


        UpdateCanvas();

        createEnemyOnTime();

    }

    //private void dep()
    //{
    //    Debug.Log("Level: " + currentLevel + " NumEnemiesThisLevel: " + numEnemies + " EnemiesLeft: " + enemiesLeftToCompleteLevel);
    //    Debug.Log("CurrentSceneEnemies: " + currentSceneEnemies + " TotalCreatedEnemies: " + totalCreatedEnemies);
    //}

    private void createEnemies()
    {
        currentSceneEnemies++;
        totalCreatedEnemies++;
        Instantiate(Enemies[Random.Range(0, Enemies.Length)], enemiesSP[Random.Range(0, enemiesSP.Length)].transform.position, Quaternion.identity);
        //dep();
        UpdateCanvas();
    }

    private void createEnemyOnTime()
    {
        if (currentSceneEnemies < maxSceneEnemies && totalCreatedEnemies < numEnemies)
        {
            createEnemies();     
        }

        Invoke("createEnemyOnTime", Random.Range(5, 15));
    }

    public void KillEnemy()
    {
        //numEnemies--;
        currentSceneEnemies--;
        enemiesLeftToCompleteLevel--;
        //dep();

        UpdateCanvas();

        if (enemiesLeftToCompleteLevel <= 0)
        {
            Debug.Log("-----------Next Level-------------");
            NextLevel();
        }
    }

    public GameObject GetClosestFence(Vector3 position)
    {
        float minDist = float.MaxValue;
        GameObject closest = null;


        foreach (GameObject g in Fences)
        {
            float dist = Vector3.Distance(position, g.transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                closest = g;
            }
        }

        if (closest)
            Fences.Remove(closest);

        return closest;
    }

}

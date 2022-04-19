using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    private int coinCount;
    public GameObject gameOverUI;
    public GameObject menuItems;
    public GameObject hitPointPrefab;
    private ArrayList hitpoints;
    private GameObject canvas;
    private RectTransform rect;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject level2Door;
    [SerializeField] GameObject level3Door;

    private static Dictionary<string, string> levelOneObjectives = new Dictionary<string, string>();
    private static Dictionary<string, string> levelTwoObjectives = new Dictionary<string, string>();
    private static Dictionary<string, string> levelThreeObjectives = new Dictionary<string, string>();
    private static Dictionary<string, string> levelFourObjectives = new Dictionary<string, string>();

    private static Dictionary<string, bool> unlockedLevels = new Dictionary<string, bool>();

    ArrayList unlockedLevelKeys = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START");
        Time.timeScale = 1;
        initializeLevelObjectives();

        canvas = GameObject.FindGameObjectWithTag("canvas");
        hitpoints = new ArrayList();
        GameObject hp01 = Instantiate(hitPointPrefab) as GameObject;
        hp01.transform.SetParent(canvas.transform);
        GameObject hp02 = Instantiate(hitPointPrefab) as GameObject;
        hp02.transform.SetParent(canvas.transform);
        GameObject hp03 = Instantiate(hitPointPrefab) as GameObject;
        hp03.transform.SetParent(canvas.transform);
        rect = hp01.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(40, -80);
        rect = hp02.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(70, -80);
        rect = hp03.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(100, -80);

        hitpoints.Add(hp01);
        hitpoints.Add(hp02);
        hitpoints.Add(hp03);

    }

    // Update is called once per frame
    void Update()
    {
        if ((int.Parse(getLevelObjective(1, "coinsCollected")) == 2 && bool.Parse(getLevelObjective(1, "monolithKilled"))) || bool.Parse(getLevelObjective(2, "levelEntered")))
        {
            Destroy(level2Door);
            levelOneObjectives["coinsCollected"] = "3"; // EXEC STOP.
            unlockedLevels["level2"] = true;
            unlockedLevelKeys.Add("level2");

        }
        if ((int.Parse(getLevelObjective(2, "coinsCollected")) == 1 && int.Parse(getLevelObjective(2, "monolithKilled")) == 2) || bool.Parse(getLevelObjective(3, "levelEntered")))
        {
            Destroy(level3Door);
            Destroy(GameObject.FindGameObjectWithTag("level3door2"));
            unlockedLevels["level3"] = true;
            unlockedLevelKeys.Add("level3");
            levelTwoObjectives["coinsCollected"] = "3"; // EXEC STOP.
        }
        if (int.Parse(getLevelObjective(3, "coinsCollected")) == 1 && int.Parse(getLevelObjective(3, "monolithKilled")) == 3)
        {
            Destroy(GameObject.FindGameObjectWithTag("level4door"));
            unlockedLevels["level4"] = true;
            unlockedLevelKeys.Add("level4");
            levelThreeObjectives["coinsCollected"] = "3"; // EXEC STOP.
        }
        if (int.Parse(getLevelObjective(4, "coinsCollected")) == 1)
        {
            Debug.Log("FIN");
            levelFourObjectives["coinsCollected"] = "3"; // EXEC STOP.
            SceneManager.LoadScene(sceneName: "Credits");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                foreach (GameObject menu in GameObject.FindGameObjectsWithTag("pausemenu"))
                {
                    menu.SetActive(false);
                }
                Time.timeScale = 1;
            }
        }
    }

    public void updateScore()
    {
        scoreText.text = "CoinX: " + ++coinCount;
    }

    public void PlayerDeath()
    {
        gameOverUI.SetActive(true);
        menuItems.SetActive(true);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }

    public bool removeHitpoint()
    {
        GameObject toBeDestroyed = hitpoints[hitpoints.Count - 1] as GameObject;
        Destroy(toBeDestroyed);
        hitpoints.RemoveAt(hitpoints.Count - 1);

        if (hitpoints.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void initializeLevelObjectives()
    {
        unlockedLevels.Add("level1", true);
        unlockedLevels.Add("level2", false);
        unlockedLevels.Add("level3", false);
        unlockedLevels.Add("level4", false);
        unlockedLevels.Add("level5", false);

        levelOneObjectives.Add("monolithKilled", "false");
        levelOneObjectives.Add("coinsCollected", "0");
        //levelOneObjectives.Add("levelOneCleared", "false");

        levelTwoObjectives.Add("monolithKilled", "0");
        levelTwoObjectives.Add("coinsCollected", "0");
        levelTwoObjectives.Add("levelEntered", "false");

        levelThreeObjectives.Add("monolithKilled", "0");
        levelThreeObjectives.Add("coinsCollected", "0");
        levelThreeObjectives.Add("levelEntered", "false");

        levelFourObjectives.Add("coinsCollected", "0");
        levelFourObjectives.Add("levelEntered", "false");
    }

    public void setLevelObjective(int levelIndex, string key, string value)
    {
        switch (levelIndex)
        {
            case 1:
                levelOneObjectives[key] = value;
                Debug.Log(levelOneObjectives["monolithKilled"]);
                Debug.Log(levelOneObjectives["coinsCollected"]);
                break;
            case 2:
                Debug.Log("LVL 2 M KILLED: " + levelTwoObjectives["monolithKilled"]);
                Debug.Log("LVL 2 C COL: " + levelTwoObjectives["coinsCollected"]);
                levelTwoObjectives[key] = value;
                break;
            case 3:
                levelThreeObjectives[key] = value;
                Debug.Log(levelThreeObjectives["monolithKilled"]);
                Debug.Log(levelThreeObjectives["coinsCollected"]);
                break;
            case 4:
                levelFourObjectives[key] = value;
                break;
            default:
                break;
        }
    }

    public string getLevelObjective(int levelIndex, string key)
    {
        switch (levelIndex)
        {
            case 1:
                return levelOneObjectives[key];
            case 2:
                return levelTwoObjectives[key];
            case 3:
                return levelThreeObjectives[key];
            case 4:
                return levelFourObjectives[key];
            default:
                break;
        }

        return "";
    }

    public static Dictionary<string, bool> getUnlockedLevels()
    {
        return unlockedLevels;
    }

    public static void eraseLevelObjectives()
    {
        Debug.Log("ERASE PROCESS");

        unlockedLevels.Clear();
        levelOneObjectives.Clear();
        levelTwoObjectives.Clear();
        levelThreeObjectives.Clear();
        levelFourObjectives.Clear();
    }
}

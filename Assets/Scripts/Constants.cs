using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    private static Dictionary<string, Vector3> levelStartingPositions = new Dictionary<string, Vector3>();
    public static Vector3 playerPos = new Vector3(2.3f, 0.0999999f, -1.9f);

    public static Dictionary<string, Vector3> getLevelStartingPositions()
    {
        levelStartingPositions["level1"] = new Vector3(2.3f, 0.0999999f, -1.9f);
        levelStartingPositions["level2"] = new Vector3(-1.96f, 1.467629f, 4.5f);
        levelStartingPositions["level3"] = new Vector3(-7.5f, 2.826822f, 6f);
        levelStartingPositions["level4"] = new Vector3(-9.445f, 5.68f, 15.314f);

        return levelStartingPositions;
    }

}

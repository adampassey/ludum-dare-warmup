using UnityEngine;
using System.Collections;

public class LevelScene : MonoBehaviour {

    public Vector3 doorOffset = new Vector3(30f, 6.5f, 1f);
    public int doorDistance = 50;

    [Range(0.1f, 1f)]
    public float enemyFrequency = 0.1f;

    [Tooltip("Array of enemies that can spawn on a given tile")]
    public GameObject[] enemiesToSpawn;

    public void SpawnDoor(int day) {
        Vector3 position = Vector3.zero;
        position.x = doorDistance * day + 10;
        position += doorOffset;

        GameObject doorObject = GameObject.Instantiate(Resources.Load(Prefabs.DOOR), position, Quaternion.identity) as GameObject;

        //  fill in road tiles to door position
        makeRoadTiles(position);
    }

    private void makeRoadTiles(Vector3 doorPosition) {

        GameObject roadPrefab = Resources.Load(Prefabs.ROAD) as GameObject;
        float lastX = 0;

        for (int i = 0; lastX < doorPosition.x + 30; i ++) {
            Vector3 position = Vector3.zero;
            position.x = i * 7.7f;
            position.y = -2.8f;
            position.z = 1;

            lastX = position.x;

            GameObject.Instantiate(roadPrefab, position, Quaternion.identity);

            //  should we spawn an enemy here?
            if (Random.Range(0f, 1) <= enemyFrequency) {
                GameObject enemy = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)];
                Vector3 enemyPosition = Vector3.zero;
                enemyPosition.x = position.x;
                enemyPosition.y = -0.2f;
                enemyPosition.z = 0.5f;

                GameObject.Instantiate(enemy, enemyPosition, Quaternion.identity);
            }
        }
    }
}

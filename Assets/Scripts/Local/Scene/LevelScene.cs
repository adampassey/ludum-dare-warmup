using UnityEngine;
using System.Collections;

public class LevelScene : MonoBehaviour {

    public Vector3 doorOffset = new Vector3(30f, 6.5f, 0f);
    public int doorDistance = 50;

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

        for (int i = -30; i < doorPosition.x + 30; i++) {
            Vector3 position = doorPosition;
            position.x += i * 7.7f;
            position.y = -2.8f;

            GameObject.Instantiate(roadPrefab, position, Quaternion.identity);
        }
    }
}

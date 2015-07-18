using UnityEngine;
using System.Collections;

public class LevelScene : MonoBehaviour {

    public Vector3 doorOffset = new Vector3(30f, 6.5f, 0f);

    public void SpawnDoor(int day) {
        Vector3 position = Vector3.zero;
        position.x = 5 * day + 10;
        position += doorOffset;

        GameObject doorObject = GameObject.Instantiate(Resources.Load(Prefabs.DOOR), position, Quaternion.identity) as GameObject;
    }
}

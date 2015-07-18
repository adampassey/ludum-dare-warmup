using UnityEngine;
using System.Collections;

public class LevelScene : MonoBehaviour {

    public void SpawnDoor(int day) {
        Vector3 position = Vector3.zero;
        position.x = 5 * day + 10;

        GameObject doorObject = GameObject.Instantiate(Resources.Load(Prefabs.DOOR), position, Quaternion.identity) as GameObject;
    }
}

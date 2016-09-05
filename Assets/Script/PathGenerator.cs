using UnityEngine;
using System.Collections;

public class PathGenerator : MonoBehaviour {

    public GameObject block;
    private float timeTillSecondPath;
    private ArrayList blockPath = new ArrayList();
    private int pathWidth = 7;
    private int offSet = 2;
    private int cubeDistance = 2;
    private float zPosEnd = 15;

    private int currentPath = 1; 

    // Use this for initialization
    void Start () {
        timeTillSecondPath = 10.0f;
        generateStraightPath();

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (playerPosition.z > (zPosEnd - 15)) {
            switch (currentPath) {
                case 1:
                    generateZigZagPath();
                    currentPath = 2;
                    break;
                case 2:
                    generateStraightPath();
                    currentPath = 1;
                    break;
            }
        }

    }

    public void generateStraightPath() {
        pathWidth = 7;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        float playerX = playerPosition.x;
        float playerZ = zPosEnd;
        float playerY = 0;

        float posZ = playerZ;
        float posX = playerX;
        float posY = 0;
        for (int i = 0; i < Constants.WORLD.blockLengthPathStart; i++) {
            posZ += cubeDistance;

            GameObject pathBlockRight = Instantiate(block, new Vector3(posX + pathWidth - offSet, posY, posZ), Quaternion.identity) as GameObject;
            GameObject pathBlockLeft = Instantiate(block, new Vector3(posX - pathWidth - offSet, posY, posZ), Quaternion.identity) as GameObject;

        }
        zPosEnd = posZ;
    }

    public void generateZigZagPath() {
        pathWidth = 10;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        float playerX = playerPosition.x;
        float playerZ = zPosEnd;
        float playerY = 0;

        float posZ = playerZ;
        float posX = playerX;
        float posY = 0;

        //going stright
        for (int i = 0; i < 15; i++) {
            posZ += cubeDistance;
            GameObject pathBlockRight = Instantiate(block, new Vector3(posX + pathWidth - offSet, posY, posZ), Quaternion.identity) as GameObject;
            GameObject pathBlockLeft = Instantiate(block, new Vector3(posX - pathWidth - offSet, posY, posZ), Quaternion.identity) as GameObject;
                    
        }

        //turning right
        for (int i = 0; i < 25; i++) {
            posX ++;
            posZ += cubeDistance;         
            GameObject pathBlockRight = Instantiate(block, new Vector3(posX + pathWidth - offSet, posY, posZ), Quaternion.identity) as GameObject;
            GameObject pathBlockLeft = Instantiate(block, new Vector3(posX - pathWidth - offSet, posY, posZ), Quaternion.identity) as GameObject;
        }

        //turning left
        for (int i = 0; i < 25; i++) {
            posX--;
            posZ += cubeDistance;
            GameObject pathBlockRight = Instantiate(block, new Vector3(posX + pathWidth - offSet, posY, posZ), Quaternion.identity) as GameObject;
            GameObject pathBlockLeft = Instantiate(block, new Vector3(posX - pathWidth - offSet, posY, posZ), Quaternion.identity) as GameObject;
        }
        zPosEnd = posZ;

    }
}

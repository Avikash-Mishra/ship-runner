using UnityEngine;
using System.Collections;

public class PathGenerator : MonoBehaviour {

    public GameObject block;
    private ArrayList blockPath = new ArrayList();
    private int pathWidth = 7;
    private int cubeZDistance = 2;
    private int pathX = 0; 

    // Use this for initialization
    void Start () {
        blockPath = new ArrayList();
        for(int i = 0; i < Constants.WORLD.blockLengthPathStart; i++) {
            var posX = pathX;
            var posZ = (i + 1) * cubeZDistance;
            var posY = 0;

            GameObject pathBlockRight = Instantiate(block, new Vector3(posX + pathWidth, posY, posZ), Quaternion.identity) as GameObject;
            GameObject pathBlockLeft = Instantiate(block, new Vector3(-(posX + pathWidth), posY, posZ), Quaternion.identity) as GameObject;
            if (pathBlockRight != null) {
                blockPath.Add(pathBlockRight);
            }
            if (pathBlockLeft != null) {
                blockPath.Add(pathBlockLeft);
            }

        }   
	}
	
	// Update is called once per frame
	void Update () {
        	
	}
}

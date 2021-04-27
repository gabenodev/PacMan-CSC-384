using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    public Vector2 orientation;
    public float speed = 4.0f;
    private Vector2 direction = Vector2.zero;
    private Vector2 nextDirection;
    private Node currentNode, previousNode ,targetNode;

    // Start is called before the first frame update
    void Start()
    {

        Node node = getNodeAtPostions (transform.localPosition);

        if(node != null)
        {
            currentNode = node;
           // Debug.Log(currentNode);
        }
       
       direction = Vector2.left;
       orientation = Vector2.left;

       changePosition(direction);

    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        Move();
        UpdateOrientation();
        consumePellet();

    }

    void CheckInput ()
    {

        if(Input.GetKeyDown(KeyCode.LeftArrow)){

            changePosition (Vector2.left);

        } else if(Input.GetKeyDown(KeyCode.RightArrow)){

          changePosition (Vector2.right);

        }else if(Input.GetKeyDown(KeyCode.UpArrow)){

            changePosition (Vector2.up);

        }else if(Input.GetKeyDown(KeyCode.DownArrow)){

            changePosition (Vector2.down);

        }

    }

    void changePosition(Vector2 d)
    {

        if(d != direction)
            nextDirection = d;

        if(currentNode != null)
        {
            Node moveToNode = CanMove(d);

            if(moveToNode != null)
            {
                direction = d;
                targetNode = moveToNode;
                previousNode = currentNode;
                currentNode = null;
            }

        }

    }    

    void Move()
    {
        if(targetNode != currentNode && targetNode != null)
        {

            if(nextDirection == direction * - 1)
            {
                direction *= -1;

                Node tempNode = targetNode;
                targetNode = previousNode;
                previousNode = tempNode;
            }    

            if (overShootTarget())
            {
                currentNode = targetNode;

                transform.localPosition = currentNode.transform.position;

                GameObject otherPortal = getPortal(currentNode.transform.position);

                if(otherPortal != null)
                {
                    transform.localPosition = otherPortal.transform.position;
                    currentNode = otherPortal.GetComponent<Node>();
                
                }

                Node moveToNode = CanMove (nextDirection);

                if(moveToNode != null)
                    direction = nextDirection;
            
                if(moveToNode == null)
                moveToNode = CanMove(direction);
                if(moveToNode != null)
                {
                    targetNode = moveToNode;
                    previousNode = currentNode;
                    currentNode = null;
                } else {
                    direction = Vector2.zero;
                }
            } else {

                 transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime;
            }
        }

       

    }

    void MoveToNode(Vector2 d)
    {
        Node moveToNode = CanMove (d);

        if(moveToNode != null)
        {
            transform.localPosition = moveToNode.transform.position;
            currentNode = moveToNode;
        }
    }


    void UpdateOrientation()
    {
        if(direction == Vector2.left){
            
            orientation = Vector2.left;
            transform.localScale = new Vector3(-1,1,1);
            transform.localRotation = Quaternion.Euler(0,0,0);

        } else if(direction == Vector2.right){
            
            orientation = Vector2.right;
            transform.localScale = new Vector3(1,1,1);
            transform.localRotation = Quaternion.Euler(0,0,0);

        }else if(direction == Vector2.up) {

            orientation = Vector2.up;
            transform.localScale = new Vector3(1,1,1);
            transform.localRotation = Quaternion.Euler(0,0,90);

        }else if(direction == Vector2.down){
            
            orientation = Vector2.down;
            transform.localScale = new Vector3(1,-1,1);
            transform.localRotation = Quaternion.Euler(0,0,-90);

        }

    }

    void consumePellet()
    {
        GameObject o = getTileAtPosition(transform.position);

        if(o != null)
        {
            Tile tile = o.GetComponent<Tile>();

            if(tile != null)
            {
                if(!tile.isConsumed && (tile.isPellet || tile.isEnergizer))
                {
                    o.GetComponent<SpriteRenderer>().enabled = false;
                    tile.isConsumed = true;

                    if(tile.isEnergizer) {

                    GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");

                    foreach (GameObject go in ghosts)
                    {
                        go.GetComponent<Ghost>().StartFrightenedMode();
                    }
					
                    }
                }
            }
        }
    }

    Node CanMove (Vector2 d)
    {

        Node moveToNode = null;

        for(int i = 0; i < currentNode.neighbors.Length; i++)
        {
            if(currentNode.validDirections[i]==d)
            {
                moveToNode = currentNode.neighbors[i];
                break;
            }
        }     
        return moveToNode;

    }

    GameObject getTileAtPosition(Vector2 pos)
        {
            int tileX = Mathf.RoundToInt(pos.x);
            int tileY = Mathf.RoundToInt(pos.y);

            GameObject tile = GameObject.Find("Game").GetComponent<GameBoard>().board[tileX,tileY];

			//Debug.Log(tile);

            if(tile != null)
            
                {return tile;}

                return null;
            
        }
    Node getNodeAtPostions (Vector2 pos)
    {
        GameObject tile = GameObject.Find("Game").GetComponent<GameBoard>().board[(int)pos.x,(int)pos.y];

        if(tile != null)
        {
            return tile.GetComponent<Node> ();
        }
        return null;
    }

    bool overShootTarget() 
    {
        float nodeToTarget = lengthFromNode(targetNode.transform.position);
        float nodeToSelf = lengthFromNode (transform.localPosition);
        return nodeToSelf > nodeToTarget;
    }

    float lengthFromNode(Vector2 targetPosition)
    {
        Vector2 vec = targetPosition - (Vector2)previousNode.transform.position;
        return vec.sqrMagnitude;
        
    }

    GameObject getPortal (Vector2 pos)
    {
        GameObject tile = GameObject.Find("Game").GetComponent<GameBoard>().board[(int)pos.x,(int)pos.y];
        if(tile != null)
        {

            if(tile.GetComponent<Tile>() != null) 
            {

                if(tile.GetComponent<Tile>().isPortal)
                {
                    GameObject otherPortal = tile.GetComponent<Tile>().portalReceiver;
                    return otherPortal;
                }
        }
    }

        return null;

    }

}

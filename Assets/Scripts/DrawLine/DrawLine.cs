using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DrawLine : MonoBehaviour
{
    private LineRenderer line;
    private EdgeCollider2D lineCol;
    private bool isMousePressed;
    public List<Vector2> pointsList;
    private Vector2 mousePos;
    public Material m_Material;


    // Structure for line points
    struct myLine
    {
        public Vector3 StartPoint;
        public Vector3 EndPoint;
    };
    //    -----------------------------------    
    void Awake()
    {
      // Create line renderer component and set its property
        line = gameObject.AddComponent<LineRenderer>();
        //m_Material = gameObject.GetComponent<Renderer>().material;
        line.material = m_Material;
        line.SetVertexCount(0);
        line.SetWidth(0.1f, 0.1f);
        line.SetColors(new Color(1f, 1f, 1f, 1f), new Color(0.1f, 0.1f, 1f, 1f));
        line.useWorldSpace = true;
        isMousePressed = false;
        pointsList = new List<Vector2>();
        
    }
    //    -----------------------------------    
    void Update()
    {
        // If mouse button down, remove old line and set its color to green
        if (Input.GetMouseButtonDown(0) )
        {
            isMousePressed = true;
            lineCol = gameObject.AddComponent<EdgeCollider2D>();
            lineCol.offset = new Vector2(-0.04f, -8.8f); // поправка корявости colision
            lineCol.edgeRadius = 0.05f;
            line.SetVertexCount(0);
            pointsList.RemoveRange(0, pointsList.Count);
            line.SetColors(new Color(1f, 1f, 1f, 1f), new Color(0.1f, 0.1f, 1f, 1f));
        }
        if (Input.GetMouseButtonUp(0))
        {

            isMousePressed = false;
            if (lineCol.pointCount > 4)
                Instantiate(line);
            Destroy(lineCol);
        }
        // Drawing line when mouse is moving(presses)
        if (isMousePressed)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //mousePos.z = 0;
            if (!pointsList.Contains(mousePos))
            {
                pointsList.Add(mousePos);
                line.SetVertexCount(pointsList.Count);
                line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);

                lineCol.points = pointsList.ToArray();

                /*if (isLineCollide())
                {
                    isMousePressed = false;
                    line.SetColors(Color.red, Color.red);
                }*/
            }
        }
    }
    //    -----------------------------------   
    //  Following method checks is currentLine(line drawn by last two points) collided with line 
    //    -----------------------------------    
   /* private bool isLineCollide()
    {
        if (pointsList.Count < 2)
            return false;
        int TotalLines = pointsList.Count - 1;
        myLine[] lines = new myLine[TotalLines];
        if (TotalLines > 1)
        {
            for (int i = 0; i < TotalLines; i++)
            {
                lines[i].StartPoint = (Vector3)pointsList[i];
                lines[i].EndPoint = (Vector3)pointsList[i + 1];
            }
        }
        for (int i = 0; i < TotalLines - 1; i++)
        {
            myLine currentLine;
            currentLine.StartPoint = (Vector3)pointsList[pointsList.Count - 2];
            currentLine.EndPoint = (Vector3)pointsList[pointsList.Count - 1];
            if (isLinesIntersect(lines[i], currentLine))
                return true;
        }
        return false;
    }
    //    -----------------------------------    
    //    Following method checks whether given two points are same or not
    //    -----------------------------------    
    private bool checkPoints(Vector3 pointA, Vector3 pointB)
    {
        return (pointA.x == pointB.x && pointA.y == pointB.y);
    }
    //    -----------------------------------    
    //    Following method checks whether given two line intersect or not
    //    -----------------------------------    
    private bool isLinesIntersect(myLine L1, myLine L2)
    {
        if (checkPoints(L1.StartPoint, L2.StartPoint) ||
            checkPoints(L1.StartPoint, L2.EndPoint) ||
            checkPoints(L1.EndPoint, L2.StartPoint) ||
            checkPoints(L1.EndPoint, L2.EndPoint))
            return false;

        return ((Mathf.Max(L1.StartPoint.x, L1.EndPoint.x) >= Mathf.Min(L2.StartPoint.x, L2.EndPoint.x)) &&
            (Mathf.Max(L2.StartPoint.x, L2.EndPoint.x) >= Mathf.Min(L1.StartPoint.x, L1.EndPoint.x)) &&
            (Mathf.Max(L1.StartPoint.y, L1.EndPoint.y) >= Mathf.Min(L2.StartPoint.y, L2.EndPoint.y)) &&
            (Mathf.Max(L2.StartPoint.y, L2.EndPoint.y) >= Mathf.Min(L1.StartPoint.y, L1.EndPoint.y))
               );
    }*/
}

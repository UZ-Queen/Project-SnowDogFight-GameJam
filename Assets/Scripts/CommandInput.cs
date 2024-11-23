using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum Direction
{
    Up, Down, Left, Right
}

public class CommandGame : MonoBehaviour
{
    [SerializeField] private Sprite[] directionSprites;
    [SerializeField] private Image CommandBackground;
    [SerializeField] private GameObject front;
    [SerializeField] private GameObject back;
    [SerializeField] private GameObject command;
    [SerializeField] private Canvas canvas;


    private Queue<GameObject> commandQueue = new Queue<GameObject>();
    private Queue<Direction> directionQueue = new Queue<Direction>();

    private int stage = 3;
    void Start()
    {
        GenerateDirection(stage);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) && directionQueue.Peek() == Direction.Up) ||
                (Input.GetKeyDown(KeyCode.DownArrow) && directionQueue.Peek() == Direction.Down) ||
                (Input.GetKeyDown(KeyCode.LeftArrow) && directionQueue.Peek() == Direction.Left) ||
                (Input.GetKeyDown(KeyCode.RightArrow) && directionQueue.Peek() == Direction.Right))
            {
                CorrectInput();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                IncorrectInput();
        }
    }

    void GenerateDirection(int stage)
    {
        while (commandQueue.Count() > 0)
        {
            Destroy(commandQueue.Dequeue());
            directionQueue.Dequeue();
        }

        for (int i = 0; i < stage; i++)
        {
            Direction currentDirection;
            currentDirection = (Direction)Random.Range(0, 4);
            int index = (int)currentDirection;

            GameObject newCommand = Instantiate(command, canvas.transform);
            Image newCommandImage = newCommand.GetComponent<Image>();
            RectTransform newCommandRectTransform = newCommand.GetComponent<RectTransform>();
            RectTransform frontTransform = front.GetComponent<RectTransform>();
            RectTransform backTransform = back.GetComponent<RectTransform>();


            float xPos = backTransform.anchoredPosition.x - frontTransform.anchoredPosition.x;

            Debug.Log(xPos);

            newCommandRectTransform.anchoredPosition = new Vector2(frontTransform.anchoredPosition.x +
                xPos / stage * (i + 1) - 20, -105);
            newCommandImage.sprite = directionSprites[index];
            directionQueue.Enqueue(currentDirection);
            commandQueue.Enqueue(newCommand);
        }
    }

    void CorrectInput()
    {
        Debug.Log("정답");
        directionQueue.Dequeue();
        Destroy(commandQueue.Dequeue());

        if (directionQueue.Count() == 0)
        {
            stage += 2;
            GenerateDirection(stage);
        }
    }

    void IncorrectInput()
    {
        Debug.Log("오답");
        GenerateDirection(stage);
    }
}

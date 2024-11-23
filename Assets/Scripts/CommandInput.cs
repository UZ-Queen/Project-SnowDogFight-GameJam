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
    [SerializeField] private Image[] directionImage;
    [SerializeField] private Sprite[] directionSprites;
    [SerializeField] private Image CommandBackground;

    private Stack<Image> imageStack = new Stack<Image>();
    private Stack<Direction> directionStack = new Stack<Direction>();

    void Start()
    {
        GenerateDirection();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) && directionStack.Peek() == Direction.Up) ||
                (Input.GetKeyDown(KeyCode.DownArrow) && directionStack.Peek() == Direction.Down) ||
                (Input.GetKeyDown(KeyCode.LeftArrow) && directionStack.Peek() == Direction.Left) ||
                (Input.GetKeyDown(KeyCode.RightArrow) && directionStack.Peek() == Direction.Right))
            {
                CorrectInput();
            }
            else
                IncorrectInput();
        }
    }

    void GenerateDirection()
    {
        for (int i = 0; i < 5; i++)
        {
            Direction currentDirection;
            currentDirection = (Direction)Random.Range(0, 4);
            int index = (int)currentDirection;
            directionImage[i].sprite = directionSprites[index];
            directionStack.Push(currentDirection);
            imageStack.Push(directionImage[i]);
        }
    }

    void CorrectInput()
    {
        directionStack.Pop();
        imageStack.Pop().gameObject.SetActive(false);
        if (directionStack.Count() == 0)
        {
            CommandBackground.gameObject.SetActive(false);
        }
    }

    void IncorrectInput()
    {

    }
}

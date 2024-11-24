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


    private Direction[] Jump = { Direction.Up, Direction.Up };
    private Direction[] HandStand = { Direction.Up, Direction.Down, Direction.Up, Direction.Down };
    private Direction[] Tumble = { Direction.Up, Direction.Up, Direction.Left, Direction.Up, Direction.Right, Direction.Down };

    private int i = 1;

    private Coroutine resetCoroutine;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (resetCoroutine != null)
                StopCoroutine(resetCoroutine);

            if (Input.GetKeyDown(KeyCode.UpArrow))
                GenerateDirection(Direction.Up);

            else if (Input.GetKeyDown(KeyCode.DownArrow))
                GenerateDirection(Direction.Down);

            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                GenerateDirection(Direction.Left);

            else if (Input.GetKeyDown(KeyCode.RightArrow))
                GenerateDirection(Direction.Right);

            resetCoroutine = StartCoroutine(CheckPerformance(0.5f));
        }
    }

    void GenerateDirection(Direction direction)
    {
        int index = (int)direction;

        GameObject newCommand = Instantiate(command, canvas.transform);
        Image newCommandImage = newCommand.GetComponent<Image>();
        RectTransform newCommandRectTransform = newCommand.GetComponent<RectTransform>();
        RectTransform frontTransform = front.GetComponent<RectTransform>();
        RectTransform backTransform = back.GetComponent<RectTransform>();

        float xPos = backTransform.anchoredPosition.x - frontTransform.anchoredPosition.x;


        newCommandRectTransform.anchoredPosition = new Vector2(frontTransform.anchoredPosition.x
            + 50 * i + 40, -105);
        newCommandImage.sprite = directionSprites[index];
        directionQueue.Enqueue(direction);
        commandQueue.Enqueue(newCommand);
        i++;
    }

    IEnumerator CheckPerformance(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (commandQueue.Count() == 2)
            JumpPerformance();

        else if (commandQueue.Count() == 4)
            HandStandPerformance();

        else if (commandQueue.Count() == 6)
            TumblePerformance();

        else
            ClearQueue();
    }

    void JumpPerformance()
    {
        int succeed = 0;
        for (int i = 0; i < 2; i++)
        {
            if (directionQueue.Dequeue() == Jump[i])
                succeed++;
        }
        if (succeed == 2)
        {
            // ���� ����
            Debug.Log("����");
        }
        ClearQueue();
    }

    void HandStandPerformance()
    {
        int succeed = 0;
        for (int i = 0; i < 4; i++)
        {
            if (directionQueue.Dequeue() == HandStand[i])
                succeed++;
        }
        if (succeed == 4)
        {
            // ��������
            Debug.Log("��������");

        }
        ClearQueue();
    }
    void TumblePerformance()
    {
        int succeed = 0;
        for (int i = 0; i < 6; i++)
        {
            if (directionQueue.Dequeue() == Tumble[i])
                succeed++;
        }
        if (succeed == 6)
        {
            // ��������
            Debug.Log("��������");
        }
        ClearQueue();
    }
    void ClearQueue()
    {
        i = 0;
        while (commandQueue.Count > 0)
            Destroy(commandQueue.Dequeue());
        while (directionQueue.Count > 0)
            directionQueue.Dequeue();
    }
}

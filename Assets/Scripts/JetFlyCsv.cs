using UnityEngine;
using System.Collections;
using System.CodeDom;
using System.Net.NetworkInformation;
using System.Linq;
using System;
using System.Text;
using System.IO;


public class JetFlyCsv : MonoBehaviour
{
    private string[] frames;
    private int frame;
    private const string csv_file = "PlanePosition.csv";

    public int getFrameId()
    {
        return frame;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Frame#,X(m),Y(m),Z(m),Heading(Deg),Pitch(Deg),Roll(Deg)
        //This method opens a file, reads each line of the file, then adds each line as an element of a string array. It then closes the file.
        frames = File.ReadAllLines(csv_file);
        frame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (string.IsNullOrEmpty(frames[frame]))
        {
            frame = (frame + 1) % frames.Length;
            return;
        }

        transform.rotation = Quaternion.Euler(IndexToValue(frames[frame], TypeToIndex("Roll(Deg)")),
            IndexToValue(frames[frame], TypeToIndex("Heading(Deg)")),
            IndexToValue(frames[frame], TypeToIndex("Pitch(Deg)")));

        transform.position = new Vector3(IndexToValue(frames[frame], TypeToIndex("X(m)")),
            IndexToValue(frames[frame], TypeToIndex("Z(m)")),
            IndexToValue(frames[frame], TypeToIndex("Y(m)")));

        frame = (frame + 1) % frames.Length;

    }

    public static int TypeToIndex(string type)
    {
        //Frame#,X(m),Y(m),Z(m),Heading(Deg),Pitch(Deg),Roll(Deg)
        switch (type)
        {
            case "Frame#":
                return 0;
            case "X(m)":
                return 1;
            case "Y(m)":
                return 2;
            case "Z(m)":
                return 3;
            case "Heading(Deg)":
                return 4;
            case "Pitch(Deg)":
                return 5;
            case "Roll(Deg)":
                return 6;
            default:
                return -1;
        }
    }

    public static float IndexToValue(string line, int index)
    {
        return float.Parse(line.Split(',')[index]);
    }
}
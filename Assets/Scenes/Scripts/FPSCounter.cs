using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public int frameRange = 60;

    public int AverageFPS { get; private set; }
    int[] FPSBuffer;
    int FPSBufferIndex;

    public int HighestFPS { get; private set; }
    public int LowestFPS { get; private set; }

    void Update()
    {
        if (FPSBuffer == null || FPSBuffer.Length != frameRange)
        {
            InitializeBuffer();
        }
        UpdateBuffer();
        CalculateFPS();
    }

    void InitializeBuffer()
    {
        if (frameRange <= 0)
        {
            frameRange = 1;
        }
        FPSBuffer = new int[frameRange];
        FPSBufferIndex = 0;
    }

    void UpdateBuffer()
    {
        FPSBuffer[FPSBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
        if (FPSBufferIndex >= frameRange)
        {
            FPSBufferIndex = 0;
        }
    }

    void CalculateFPS()
    {
        int sum = 0;
        int highest = 0;
        int lowest = int.MaxValue;
        for (int i = 0; i < frameRange; i++)
        {
            int fps = FPSBuffer[i];
            sum += fps;
            if (fps > highest)
            {
                highest = fps;
            }
            if (fps < lowest)
            {
                lowest = fps;
            }
        }
        AverageFPS = sum / frameRange;
        HighestFPS = highest;
        LowestFPS = lowest;
    }
}
using System;
using System.Collections.Generic;

public class Assistant
{
    private string assistantName;
    private List<Display> assignedDisplays;

    public Assistant(string name)
    {
        assistantName = name;
        assignedDisplays = new List<Display>();
    }

    public void AssignDisplay(Display d)
    {
        assignedDisplays.Add(d);
    }

    public void Assist()
    {
        for (int i = 0; i < assignedDisplays.Count - 1; i++)
        {
            Console.WriteLine($"Comparing Display {i + 1} with Display {i + 2}:");
            assignedDisplays[i].CompareWithMonitor(assignedDisplays[i + 1]);
            Console.WriteLine();
        }
    }

    public Display BuyBestDisplay()
    {
    if (assignedDisplays.Count == 0)
    {
        Console.WriteLine("No displays available to buy.");
        return null;
    }

    Display bestDisplay = assignedDisplays[0]; 

    foreach (Display display in assignedDisplays)
    {
        if (display.GetWidth() * display.GetHeight() > bestDisplay.GetWidth() * bestDisplay.GetHeight())
        {
            bestDisplay = display; 
        }
    }

    assignedDisplays.Remove(bestDisplay);
    Console.WriteLine($"{assistantName} bought the best display: {bestDisplay.GetModel()}");
    return bestDisplay;
    }

}

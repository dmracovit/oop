public class Display
{
    // Attributes
    private int width;  
    private int height; 
    private float ppi;   
    private string model; 

    // Constructor
    public Display(int width, int height, float ppi, string model)
    {
        this.width = width;
        this.height = height;
        this.ppi = ppi;
        this.model = model;
    }

    // Getters
    public int GetWidth() => width;
    public int GetHeight() => height;
    public float GetPPI() => ppi;
    public string GetModel() => model;

    // Method to compare sizes of two displays
    public void CompareSize(Display m)
    {
        int thisArea = width * height;
        int otherArea = m.GetWidth() * m.GetHeight();
        
        if (thisArea > otherArea)
            Console.WriteLine($"{model} is larger than {m.GetModel()}.");
        else if (thisArea < otherArea)
            Console.WriteLine($"{model} is smaller than {m.GetModel()}.");
        else
            Console.WriteLine($"{model} and {m.GetModel()} are the same size.");
    }

    // Method to compare sharpness of two displays
    public void CompareSharpness(Display m)
    {
        if (ppi > m.GetPPI())
            Console.WriteLine($"{model} is sharper than {m.GetModel()}.");
        else if (ppi < m.GetPPI())
            Console.WriteLine($"{model} is less sharp than {m.GetModel()}.");
        else
            Console.WriteLine($"{model} and {m.GetModel()} have the same sharpness.");
    }

    // Method to compare size and sharpness of two displays
    public void CompareWithMonitor(Display m)
    {
        CompareSize(m);
        CompareSharpness(m);
    }
}

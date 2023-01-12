namespace Create.View;






class Infra : Object
{
    public static Infra This { get; } = CreateGlobal();




    private static Infra CreateGlobal()
    {
        Infra global;


        global = new Infra();


        global.Init();


        return global;
    }





    public DrawColor CreateColor(byte alpha, byte red, byte green, byte blue)
    {
        DrawColor color;

        color = new DrawColor();

        color.Init();

        color.Alpha = alpha;

        color.Red = red;

        color.Green = green;

        color.Blue = blue;


        return color;
    }
}
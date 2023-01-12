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





    public DrawPos CreateDrawPos(int left, int up)
    {
        DrawPos pos;

        pos = new DrawPos();

        pos.Init();

        pos.Left = left;

        pos.Up = up;


        return pos;
    }




    public DrawSize CreateDrawSize(int width, int height)
    {
        DrawSize size;

        size = new DrawSize();

        size.Init();

        size.Width = width;

        size.Height = height;


        return size;
    }





    public DrawRect CreateDrawRect(DrawPos pos, DrawSize size)
    {
        DrawRect rect;

        rect = new DrawRect();

        rect.Init();

        rect.Pos = pos;

        rect.Size = size;


        return rect;
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
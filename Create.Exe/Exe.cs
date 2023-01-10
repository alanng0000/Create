namespace Create.Exe;



class Exe : ExeExe
{
    protected override int ExecuteWork()
    {
        Create create;


        create = new Create();


        create.Init();



        int o;


        o = create.Execute();



        return o;
    }





    static int Main()
    {
        Exe exe;


        exe = new Exe();


        exe.Init();



        int o;


        o = exe.Execute();


        return o;
    }
}
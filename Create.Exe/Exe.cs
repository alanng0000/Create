namespace Create.Exe;



class Exe : ExeExe
{
    protected override bool ExecuteMain(string arg)
    {
        M m;


        m = new M();


        m.Init();


        m.Main(arg);



        return true;
    }





    static void Main(string[] args)
    {
        Exe exe;


        exe = new Exe();


        exe.Init();


        exe.Args = args;


        exe.Execute();
    }
}
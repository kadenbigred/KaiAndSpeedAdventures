using System.Windows.Forms;
using System;
using WindowsFormsApp1;

class MyContext : ApplicationContext
{
    
    public MyContext()
    {
        //Instantiate both the windows
        Form form1 = new Form1();
        Form form2 = new Form2();

        // When any window closes, remove it from the context
        form1.FormClosed += (s, e) => ExitThreadIfNoForms();
        form2.FormClosed += (s, e) => ExitThreadIfNoForms();

        //Show both the windows
        form1.Show();
        form2.Show();
    }

    //Stop program if both windows close
    private void ExitThreadIfNoForms()
    {
        if (Application.OpenForms.Count == 0)
            ExitThread();
    }
}

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MyContext());
    }
}

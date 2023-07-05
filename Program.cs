using View;

namespace SistemaAgroPop
{

    public static class Program
    {
        public static MenuPrincipal form = new MenuPrincipal();
        [STAThread]
        static void Main()
        {
            form.Show();
            Application.Run(form);
        }
    }
}

using View;

namespace SistemaAgroPop
{

    static class Program
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

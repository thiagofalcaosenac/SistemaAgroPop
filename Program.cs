using View;

namespace SistemaAgroPop
{

    static class Program
    {
        public static Menu form = new Menu();
        [STAThread]
        static void Main()
        {
            form.FormLayout();
            Application.Run(form);
        }
    }
}

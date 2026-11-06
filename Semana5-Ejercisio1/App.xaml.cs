
using Microsoft.Extensions.DependencyInjection;

namespace Semana5_Ejercisio1
{
    public partial class App : Application
    {
        public static Repositories.PersonRespository PersonRepository { get; private set; }
        public App(Repositories.PersonRespository repo)
        {
            InitializeComponent();
            PersonRepository = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
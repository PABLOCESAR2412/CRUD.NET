using Semana5_Ejercisio1.Models;
using Semana5_Ejercisio1.Repositories;

namespace Semana5_Ejercisio1.Views;

public partial class vPerson : ContentPage
{
    private readonly PersonRespository _repo;
    private Persona? _selected;

    public vPerson()
    {
        InitializeComponent();
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "personas.db3");
        _repo = new PersonRespository(dbPath);
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        var name = NameEntry.Text?.Trim() ?? "";
        _repo.AddNewPerson(name);
        MessageLabel.Text = "dato ingresado";
        NameEntry.Text = "";
    }

    private void OnShowClicked(object sender, EventArgs e)
    {
        PersonsCollection.ItemsSource = _repo.GetAllPersonsList();
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_selected == null)
        {
            MessageLabel.Text = "Selecciona una persona de la lista.";
            return;
        }
        _repo.DeletePerson(_selected.Id);
        MessageLabel.Text = "dato borrado";
        _selected = null;
        NameEntry.Text = "";
        PersonsCollection.ItemsSource = _repo.GetAllPersonsList();
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _selected = e.CurrentSelection.FirstOrDefault() as Persona;
        if (_selected != null)
            NameEntry.Text = _selected.Name;
    }
}

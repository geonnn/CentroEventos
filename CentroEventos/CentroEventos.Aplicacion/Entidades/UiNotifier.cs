namespace CentroEventos.Aplicacion.Entidades;

public class UiNotifier
{
    public event Action? OnChange;
    public void Notify() => OnChange?.Invoke();
}

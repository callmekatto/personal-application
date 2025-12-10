using Microsoft.AspNetCore.Components;
using MyBuddy.Wasm.Client.Navigation;
using MyBuddy.Wasm.Client.Pages;

namespace MyBuddy.Wasm.Client;

public class Entrypoint : IComponent
{
	RenderHandle _renderHandle;


	public Navigator DefaultNavigator { get; set; }

	public Entrypoint(Navigator nav)
	{
		DefaultNavigator = nav;
		DefaultNavigator.Register(Render);
	}
	public void Attach(RenderHandle renderHandle)
	{
		_renderHandle = renderHandle;
	}

	public Task SetParametersAsync(ParameterView parameters)
	{

		Render();
		return Task.CompletedTask;
	}

	internal void Render()
	{
		_renderHandle.Render(b =>
		{
			b.OpenComponent<PageNavigation>(0);
			b.AddComponentParameter(1, "Navigator", DefaultNavigator);
			b.CloseComponent();
			b.OpenComponent(2, DefaultNavigator.GetCurrentPage());
			b.CloseComponent();

		});
	}


}

public class Navigator
{
	Stack<Type> _history = new(5);
	Stack<Type> _forwardComponents = new(5);
	private Action _callback;
	public bool CanGoForwards => _forwardComponents.Count > 0;
	public bool CanGoBackwads => _history.Count > 1;
	public Navigator()
	{
		_history.Push(typeof(Home));
	}
	public void Register(Action callback)
	{
		_callback = callback;
	}
	public void ShowPage<T>() where T : IComponent
	{
		_forwardComponents.Clear();
		_history.Push(typeof(T));
		_callback.Invoke();
	}
	public void Backwards()
	{
		if (!CanGoBackwads) return;
		_forwardComponents.Push(_history.Pop());
		_callback.Invoke();
	}
	public void Forwards()
	{
		if (!CanGoForwards) return;
		_history.Push(_forwardComponents.Pop());
		_callback.Invoke();
	}

	public Type GetCurrentPage() => _history.Peek();
}
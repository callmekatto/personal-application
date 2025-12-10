using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace MyBuddy.Wasm.Components.Core;

public abstract class WasmComponent : IComponent
{
	private RenderHandle _renderHandle;
	protected ParameterView _parameters;
	private RenderFragment _renderedContent;



	protected bool Hidden { get; set; }
	protected WasmComponent()
	{
		_renderedContent = (b) =>
		{
			if (Hidden) return;
		};
	}

	public void Attach(RenderHandle renderHandle)
	{
		if (_renderHandle.IsInitialized)
		{
			throw new InvalidOperationException("The component has already been attached.");
		}
		_renderHandle = renderHandle;
	}

	public Task SetParametersAsync(ParameterView parameters)
	{
		_parameters = parameters;
		throw new NotImplementedException();
	}
	protected abstract void BuildRenderTree(RenderTreeBuilder builder);

	protected void Render()
	{
		_renderHandle.Render();
	}
}

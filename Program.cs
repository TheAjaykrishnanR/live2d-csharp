using Silk.NET.Windowing;
using Silk.NET.OpenGL;

using PersonaEngine.Lib.Live2D.App;
using PersonaEngine.Lib.Live2D.Framework.Rendering;
using PersonaEngine.Lib.Live2D;

class Program
{
	static IWindow window; // silk.NET window
	static GL gl; // GL api ecxtracted from window

	static LAppDelegate? lapp; // live2d app that draws to/through GL

	static void Main()
	{
		WindowOptions options = WindowOptions.Default;
		options.Size = new() { X = 800, Y = 400 };
		options.Title = "Hello";

		window = Window.Create(options);
		window.Load += OnLoad;
		window.Render += OnRender; // frame renderer
		window.Run();
	}

	static void OnLoad()
	{
		gl = GL.GetApi(window);
		lapp = new(new SilkNetApi(gl, 800, 400), _ => { });
		lapp.Live2dManager.LoadModel(
			@"C:\Users\Jayakuttan\dev\csharp-live2d\models\Luna", "Luna"
		);
	}

	static void OnRender(double delta)
	{
		if (lapp == null) return;
		lapp.Update((float)delta);
		lapp.Run();
	}
}

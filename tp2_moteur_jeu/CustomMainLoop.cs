using Godot;

[GlobalClass]
public partial class CustomMainLoop : SceneTree
{
		
	private static CustomMainLoop instance;
	private LevelManager level;
	private SaveManager save;
	
	public CustomMainLoop()
	{
		instance = this;
		level = new LevelManager();
		save = new SaveManager();
	}

	public static CustomMainLoop Get()
	{
		return instance;
	}

	public LevelManager GetLevelManager()
	{
		return level;
	}

	public SaveManager GetSaveManager()
	{
		return save;
	}

	public override void _Initialize()
	{
		base._Initialize();
		GD.Print("Initialized:");
		Get().GetSaveManager().LoadGame();
	}

	public override bool _Process(double delta)
	{
		base._Process(delta);
		//_timeElapsed += delta;
		// Return true to end the main loop.
		return Input.GetMouseButtonMask() != 0 || Input.IsKeyPressed(Key.Escape);
		
	}

	public override void _Finalize()
	{
		GD.Print("Finalized:");
	 	Get().GetSaveManager().SaveGame();
	}
}

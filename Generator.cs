using Godot;
using System;

public class Generator : Spatial
{
    PackedScene dodecahedron;
    bool made = false;
    int loops = 10;
    public override void _Ready()
    {
        dodecahedron = (PackedScene)ResourceLoader.Load("res://Dodecahedron.tscn");
        int radius = 1;
        for (int i = 0; i < loops; i++)
        {
            float numOfScenes = (float)(2.0f * Mathf.Pi * i);
            float theta = Mathf.Pi * (2.0f) / (numOfScenes);
            for (int j = 0; j < numOfScenes; j++)
            {
                float angle = j * theta;
                float x = (radius) * Mathf.Cos(angle) * i;
                float y = (radius) * Mathf.Sin(angle) * i;
                var dodInst = dodecahedron.Instance<MeshInstance>();
                dodInst.Translation = new Vector3(x, y, 0);
                AddChild(dodInst);
            }
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // Rotation += new Vector3(0, 0, 4);
    }
}

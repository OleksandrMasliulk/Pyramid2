using UnityEngine;

public abstract class ItemSoundboardSO : SoundBoardSO {
    [SerializeField] private SoundAudioClip _pickUp;
    public SoundAudioClip PickUpSound => _pickUp;

    public override void Initialize() => _pickUp.Init();

    public override void Dispose() => _pickUp.Dispose();
}

[CreateAssetMenu(fileName = "New Flashlight Soundboard", menuName = "Soundboard/New Flashlight Soundboard")]
public class FlashlightSoundboardSO : ItemSoundboardSO {
    public override void Initialize() => base.Initialize();

    public override void Dispose() => base.Dispose();
}

[CreateAssetMenu(fileName = "New Medkit Soundboard", menuName = "Soundboard/New Medkit Soundboard")]
public class MedkitSoundboardSO : ItemSoundboardSO {
    public override void Initialize() => base.Initialize();

    public override void Dispose() => base.Dispose();
}

[CreateAssetMenu(fileName = "New Paint Soundboard", menuName = "Soundboard/New Paint Soundboard")]
public class PaintSoundboardSO : ItemSoundboardSO {
    public override void Initialize() => base.Initialize();

    public override void Dispose() => base.Dispose();
}

[CreateAssetMenu(fileName = "New Treasure Soundboard", menuName = "Soundboard/New Treasure Soundboard")]
public class TreasureSoundboardSO : ItemSoundboardSO {
    public override void Initialize() => base.Initialize();

    public override void Dispose() => base.Dispose();
}

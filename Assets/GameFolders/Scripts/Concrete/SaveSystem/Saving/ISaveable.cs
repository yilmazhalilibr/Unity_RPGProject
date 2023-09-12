namespace Unity_RPGProject.Concrete
{
    public interface ISaveable
    {
        object CaptureState();
        void RestoreState(object state);
    }
}
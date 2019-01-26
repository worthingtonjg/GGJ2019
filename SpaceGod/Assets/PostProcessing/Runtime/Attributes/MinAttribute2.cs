namespace UnityEngine.PostProcessing
{
    public sealed class MinAttribute2 : PropertyAttribute
    {
        public readonly float min;

        public MinAttribute2(float min)
        {
            this.min = min;
        }
    }
}

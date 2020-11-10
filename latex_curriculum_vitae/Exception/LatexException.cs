namespace latex_curriculum_vitae.Exception
{
    [System.Serializable]
    public class LatexException : System.Exception
    {
        public LatexException() { }
        public LatexException(string message) : base(message) { }
        public LatexException(string message, System.Exception inner) : base(message, inner) { }
        protected LatexException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

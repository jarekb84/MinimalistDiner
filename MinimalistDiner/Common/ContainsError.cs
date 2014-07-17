namespace MinimalistDiner.Common
{
    public abstract class ContainsError
    {
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }
}

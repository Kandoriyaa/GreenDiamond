namespace GreenDiamond.Domain.Interface.GreenDiaiondConnection
{
    public interface IConnection
    {
        string? ConnectionString { get; set; }

        public Task<bool> SetGreenDimoand(string greenDimoand);
    }
}

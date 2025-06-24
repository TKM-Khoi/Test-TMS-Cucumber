namespace Service.DTOs
{
    public class CreateProjectDto
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int SizeInDays { get; set; }
    public string Location { get; set; }
    public string PM { get; set; }
    public string PMFullInfo { get; set; }
    public string DPM { get; set; }
    public string DPMFullInfo { get; set; }
    public string EM { get; set; }
    public string EMFullInfo { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string Technologies { get; set; }
    public string ClientName { get; set; }
    public string ClientIndustrySector { get; set; }
    public string ClientDescription { get; set; }
}
}
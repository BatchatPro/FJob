namespace FJob.Domain;

public class BaseJob: BaseEntity
{
    public string MinSalary { get; set; }
    public string MaxSalary { get; set; }
    public DateTime Deadline { get; set; }
    public string Demand { get; set; }
    public string MoreInfo { get; set; }
    public string WorkingTime { get; set; }
    public string CallTime { get; set; }
    public string Status { get; set; }
}

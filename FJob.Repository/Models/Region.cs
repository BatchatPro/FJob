using FJob.Domain;
using System.Diagnostics.CodeAnalysis;

namespace FJob.Repository.Models;

public class Region:BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    [AllowNull]
    public List<District>? Districts { get; set; }
}

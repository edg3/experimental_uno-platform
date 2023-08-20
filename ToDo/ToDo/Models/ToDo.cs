namespace ToDo.Models;

internal class ToDo
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public DateTime? completedon { get; set; }
}

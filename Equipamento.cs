using System.ComponentModel.DataAnnotations;

public class Equipamento()
{
    [Key]
    public int Codigo { get; set; }
    public  string NomeDescricao { get; set; } = string.Empty;
    public Tipos Tipo { get; set; }
    public string Fabricante { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string? IP { get; set; }
    public string Localizacao { get; set; } = string.Empty;
    public DateTime DataInstalacao { get; set; }
    public Status Statu { get; set; }
    public DateTime? DataUltimaManutencao { get; set; }
    public string Observacao { get; set; } = string.Empty;

}

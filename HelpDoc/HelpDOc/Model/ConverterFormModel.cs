using System.ComponentModel.DataAnnotations;

public class ConverterFormModel
{
    [Required(ErrorMessage = "O caminho dos arquivos DOC/DOCX é obrigatório.")]
    public string? DocPath { get; set; }

    [Required(ErrorMessage = "A pasta de destino dos PDFs é obrigatória.")]
    public string? PdfPath { get; set; }

    public string? LibreOfficePath { get; set; }
}

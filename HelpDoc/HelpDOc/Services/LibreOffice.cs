using System.Diagnostics;

public class LibreOffice {
    public LibreOffice()
    {
    }

    public static void Run(string doc, string pdf, string libre)
    {
        string libreOfficePath = @"C:\Program Files\LibreOffice\program\soffice.exe";
        string docxPath = doc; // @"C:\Projects\Resultado\documento.docx";
        string outputPath = pdf; // @"C:\Projects\Resultado\saida";

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = libreOfficePath,
            Arguments = $"--headless --convert-to pdf \"{docxPath}\" --outdir \"{outputPath}\"",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (Process process = Process.Start(startInfo))
        {
            process.WaitForExit();
            Console.WriteLine("Conversão concluída com sucesso!");
        }
    }
}
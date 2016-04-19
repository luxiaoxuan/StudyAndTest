using iTextSharp.text.pdf;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFSharpTrialConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "aa.pdf");
            //TryITextSharp(pdfPath);
            TryPdfBox(pdfPath);
        }

        private static void TryITextSharp(string pdfPath)
        {
            var pdf = new PdfReader(pdfPath);
            var sb = new StringBuilder();

            var b = pdf.GetPageContent(1);
            for (var i = 0; i < b.Length; i++)
                sb.Append(Convert.ToChar(b[i]));

            var result = sb.ToString();
        }

        private static void TryPdfBox(string pdfPath)
        {
            var doc = PDDocument.load(pdfPath);
            var pdfStripper = new PDFTextStripper();

            var text = pdfStripper.getText(doc);
        }
    }
}

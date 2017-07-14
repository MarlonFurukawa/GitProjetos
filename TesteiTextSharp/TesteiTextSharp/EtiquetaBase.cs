using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TesteiTextSharp
{
    public abstract class EtiquetaBase
    {
        public abstract void ImprimirEtiqueta(InformacoesEtiqueta i, DataRow dr, Document doc, PdfWriter writer);
    }
}

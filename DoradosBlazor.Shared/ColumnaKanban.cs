﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class ColumnaKanban
    {
        public string Nombre { get; set; } = string.Empty;
        public List<ST_S_ProspecFiltrosDTO> Prospectos { get; set; } = new();
    }
}

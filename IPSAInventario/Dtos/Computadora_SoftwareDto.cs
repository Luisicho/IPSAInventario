using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IPSAInventario.Dtos
{
	public class Computadora_SoftwareDto
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int IDSoftware { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(7)]
		public string Codigo_PC { get; set; }

		public string Instalado { get; set; }

		public string Comentarios { get; set; }

		public DateTime? Auditoria_MS { get; set; }

		public bool? Revisado { get; set; }

		//public ComputadoraDto Computadora { get; set; }

		public SoftwareDto Software { get; set; }
	}
}
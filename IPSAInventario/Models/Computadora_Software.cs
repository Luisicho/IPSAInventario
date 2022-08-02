using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IPSAInventario.Models
{
	public class Computadora_Software
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

		public Computadora Computadora { get; set; }

		public Software Software { get; set; }
	}
}
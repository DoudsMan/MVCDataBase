using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databaseAPI.Model
{
	public class PatientView
    {
        public SelectList Doctors{ get; set; }
        public Patient Patient { get; set; }
    }



}
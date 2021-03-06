﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oncology.Model
{
    public class Cycle : IIdentity<Cycle>
    {
        [Key]
        public int Id { get; set; }

        public int DiagnosticId { get; set; }

        [ForeignKey("DiagnosticId")]
        public virtual Diagnostic Diagnostic { get; set; }

        public DateTime StartDate { get; set; }

        public int TreatmentId { get; set; }

        [ForeignKey("TreatmentId")]
        public virtual Treatment Treatment { get; set; }

        public int? SerumCreat { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public IList<CycleItem> CycleItems { get; set; }

        public override bool Equals(object obj)
        {
            Cycle that = obj as Cycle;

            return that != null && that.Id == Id && that.DiagnosticId == DiagnosticId && that.StartDate == StartDate && that.TreatmentId == TreatmentId
                && that.SerumCreat == SerumCreat && that.Height == Height && that.Weight == Weight;
        }

        public override string ToString()
        {
            return $"{Id} - {DiagnosticId} - {TreatmentId} , {StartDate}, {SerumCreat} , {Height} : {Weight}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public void UpdatePropertiesFrom(Cycle that)
        {
            this.DiagnosticId = that.DiagnosticId;
            this.StartDate = that.StartDate;
            this.TreatmentId = that.TreatmentId;
            this.SerumCreat = that.SerumCreat;
            this.Height = that.Height;
            this.Weight = that.Weight;
        }
    }
}

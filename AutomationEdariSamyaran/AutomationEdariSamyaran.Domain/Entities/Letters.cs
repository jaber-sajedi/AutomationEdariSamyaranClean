using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class Letters
    {
        [Key]
        public int Id { get; set; }

        public string? LetterNumber { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? DateOfView { get; set; }

        /// /////////////////////////////////
        // Internal=0 External=1
        public int LetterType { get; set; }

        public int IdLetterSubject { get; set; }

        // Foreign Key به جدول ارسال‌کننده (فرضاً SendLetter می‌تواند یک Person یا Employee باشد)
        public int IdSendLetter { get; set; }
        // Navigation property برای ارسال‌کننده، می‌توانید کلاس مورد نظر را جایگزین کنید
        // public SendLetter? SendLetter { get; set; }

        // Foreign Key به دریافت‌کننده
        public int IdReceiveLetters { get; set; }
        [ForeignKey("IdReceiveLetters")]
        public LetterRecepiant? Recepiant { get; set; }

        public byte[]? AttachedFile { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }

        public bool TemporaryDeletion { get; set; }
    }


}
